using Grpc.Core;
using Grpc.Net.Client;
using GrpcDottyLogs;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DottyLogs.Client.BackgroundServices
{
    /// <summary>
    /// MetricsAndHeartbeatBackgroundService connects to the Dotty Server and provides heartbeat and metrics. It also funnels all client updates there through the update stream.
    /// </summary>
    public class MetricsAndHeartbeatBackgroundService : IHostedService, IDisposable
    {
        private float _cpu;
        private float _memory;
        private ILogger<MetricsAndHeartbeatBackgroundService> _logger;
        private Timer _timer;
        private GrpcChannel _channel;
        private AsyncClientStreamingCall<MetricsUpdateRequest, Empty> _metricsUpdateChannel;

        public MetricsAndHeartbeatBackgroundService(ILogger<MetricsAndHeartbeatBackgroundService> logger)
        {
            _logger = logger;
        }

        public void MetricEventCallback(float cpu, float memory)
        {
            _cpu = cpu;
            _memory = memory;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");

            _channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new GrpcDottyLogs.DottyLogs.DottyLogsClient(_channel);

            _metricsUpdateChannel = client.MetricsUpdate(cancellationToken: stoppingToken);

            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(1));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            _ = DoAsyncWork();
        }

        private async Task DoAsyncWork()
        {
            await _metricsUpdateChannel.RequestStream.WriteAsync(new GrpcDottyLogs.MetricsUpdateRequest { Cpu = _cpu, Memory = _memory });
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);
            _metricsUpdateChannel?.RequestStream.CompleteAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            _channel.ShutdownAsync().ConfigureAwait(false).GetAwaiter().GetResult();

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
            _metricsUpdateChannel?.RequestStream.CompleteAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            _metricsUpdateChannel?.Dispose();
            _channel.ShutdownAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            _channel.Dispose();
        }
    }

    internal class DottyEventListener : EventListener
    {
        private readonly EventLevel _level = EventLevel.Verbose;

        public int EventCount { get; private set; } = 0;

        private int _intervalSec;
        private Action<float, float> _metricEventCallback;

        public DottyEventListener(Action<float, float> metricEventCallback)
        {
            _metricEventCallback = metricEventCallback;
        }

        protected override void OnEventSourceCreated(EventSource source)
        {
            if (source.Name.Equals("System.Runtime"))
            {
                var refreshInterval = new Dictionary<string, string>();
                refreshInterval.Add("EventCounterIntervalSec", "1");
                EnableEvents(source, _level, (EventKeywords)(-1), refreshInterval);
            }
        }

        private (string Name, string Value) GetRelevantMetric(IDictionary<string, object> eventPayload)
        {
            string counterName = "";
            string counterValue = "";

            foreach (KeyValuePair<string, object> payload in eventPayload)
            {
                string key = payload.Key;
                string val = payload.Value.ToString();

                if (key.Equals("DisplayName"))
                {
                    counterName = val;
                }
                else if (key.Equals("Mean") || key.Equals("Increment"))
                {
                    counterValue = val;
                }
            }
            return (counterName, counterValue);
        }

        protected override void OnEventWritten(EventWrittenEventArgs eventData)
        {
            if (eventData.EventName.Equals("EventCounters"))
            {
                float memory = 0;
                float cpu = 0;
                for (int i = 0; i < eventData.Payload.Count; i++)
                {
                    IDictionary<string, object> eventPayload = eventData.Payload[i] as IDictionary<string, object>;

                    if (eventPayload != null)
                    {
                        var counterKV = GetRelevantMetric(eventPayload);
                        if (counterKV.Name == "CPU Usage")
                        {
                            cpu = float.Parse(counterKV.Value);
                        }
                        if (counterKV.Name == "Working Set")
                        {
                            memory = float.Parse(counterKV.Value);
                        }
                    }
                }
                _metricEventCallback(cpu, memory);
            }
        }
    }
}
