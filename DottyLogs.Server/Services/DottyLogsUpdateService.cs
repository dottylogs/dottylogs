using DottyLogs.Models;
using DottyLogs.Server.Hubs;
using Grpc.Core;
using GrpcDottyLogs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DottyLogs.Server.Services
{
    public class DottyLogsUpdateService : GrpcDottyLogs.DottyLogs.DottyLogsBase
    {
        private readonly ILogger<DottyLogsUpdateService> _logger;
        private readonly IHubContext<UiUpdateHub> _uiUpdateHub;
        public DottyLogsUpdateService(ILogger<DottyLogsUpdateService> logger, IHubContext<UiUpdateHub> uiUpdateHub)
        {
            _logger = logger;
            _uiUpdateHub = uiUpdateHub;
        }

        public override async Task<Empty> StartSpan(StartSpanRequest request, ServerCallContext context)
        {
            await _uiUpdateHub.Clients.All.SendAsync("StartSpan", request);
            return new Empty();
        }

        public override async Task<Empty> StopSpan(StopSpanRequest request, ServerCallContext context)
        {
            await _uiUpdateHub.Clients.All.SendAsync("StopSpan", request);
            return new Empty();
        }

        public override async Task<Empty> MetricsUpdate(IAsyncStreamReader<MetricsUpdateRequest> requestStream, ServerCallContext context)
        {
            try
            {
                await foreach (var message in requestStream.ReadAllAsync())
                {
                    _logger.LogInformation("Got metrics update");
                }
            } 
            catch (System.IO.IOException)
            {
                // This means the server shut down really fast, without closing connection.
                _logger.LogInformation($"Server with trace {context.GetHttpContext().TraceIdentifier} lost connection down unexpectedly");
            }

            return new Empty();
        }

        public override async Task<Empty> PushLogMessage(LogRequest request, ServerCallContext context)
        {
            _logger.LogInformation($"Got log update: {request.Message}, {request.SpanIdentifier}");
            await _uiUpdateHub.Clients.All.SendAsync("LogMessage", request);
            return new Empty();
        }

        public override async Task<Empty> Heartbeat(IAsyncStreamReader<HeartbeatRequest> requestStream, ServerCallContext context)
        {
            try
            {
                await foreach (var message in requestStream.ReadAllAsync())
                {
                    // We're alive! Server sends us one message. We use the hostname as reported as this should work well on k8s.
                    await _uiUpdateHub.Clients.All.SendAsync("ServerConnected", new ServerConnectedEvent { TraceIdentifier = context.GetHttpContext().TraceIdentifier, HostName = message.Hostname, ApplicationName = message.ApplicationName });
                }
            }
            catch (Exception)
            {
                // We're dead!
                await _uiUpdateHub.Clients.All.SendAsync("ServerDisconnected", new ServerDisconnectedEvent { TraceIdentifier = context.GetHttpContext().TraceIdentifier });
            }

            // We're shut down happily.
            await _uiUpdateHub.Clients.All.SendAsync("ServerDisconnected", new ServerDisconnectedEvent { TraceIdentifier = context.GetHttpContext().TraceIdentifier });

            return new Empty();
        }
    }
}
