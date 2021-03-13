using DottyLogs.Models;
using DottyLogs.Server.DbModels;
using DottyLogs.Server.Hubs;
using Grpc.Core;
using GrpcDottyLogs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DottyLogs.Server.Services
{
    public class DottyLogsUpdateService : GrpcDottyLogs.DottyLogs.DottyLogsBase
    {
        private readonly ILogger<DottyLogsUpdateService> _logger;
        private readonly IHubContext<UiUpdateHub> _uiUpdateHub;
        private readonly DottyDbContext _dbContext;

        public DottyLogsUpdateService(ILogger<DottyLogsUpdateService> logger, IHubContext<UiUpdateHub> uiUpdateHub, DottyDbContext dbContext)
        {
            _logger = logger;
            _uiUpdateHub = uiUpdateHub;
            _dbContext = dbContext;
        }
         
        public override async Task<Empty> StartSpan(StartSpanRequest request, ServerCallContext context)
        {
            await _uiUpdateHub.Clients.All.SendAsync("StartSpan", request);

            var trace = await _dbContext
                .Traces
                .SingleOrDefaultAsync(t => t.TraceIdentifier == request.TraceIdentifier);

            var span = new DottySpan
            {
                ApplicationName = request.ApplicationName,
                HostName = request.Hostname,
                ParentSpanIdentifier = request.ParentSpanIdentifier,
                RequestUrl = request.RequestUrl,
                SpanIdentifier = request.SpanIdentifier,
                StartedAtUtc = DateTime.UtcNow,
                TraceIdentifier = request.TraceIdentifier
            };

            if (trace == null)
            {
                _logger.LogInformation($"Creating new  trace for { request.TraceIdentifier}");

                trace = new DottyTrace();
                trace.RequestUrl = request.RequestUrl;
                trace.StartedAtUtc = DateTime.UtcNow;
                trace.TraceIdentifier = request.TraceIdentifier;

                trace.SpanData = span;

                _dbContext.Traces.Add(trace);
            }
            else
            {
                var parentSpan = await _dbContext.Spans.SingleOrDefaultAsync(s => s.SpanIdentifier == request.ParentSpanIdentifier);
                parentSpan.ChildSpans.Add(span);
            }

            await _dbContext.SaveChangesAsync();

            return new Empty();
        }

        public override async Task<Empty> StopSpan(StopSpanRequest request, ServerCallContext context)
        {
            await _uiUpdateHub.Clients.All.SendAsync("StopSpan", request);
            var span = await _dbContext.Spans.SingleOrDefaultAsync(s => s.SpanIdentifier == request.SpanIdentifier);
            
            if (span == null)
            {
                _logger.LogWarning($"No span for { request.SpanIdentifier}, skipping");
                return new Empty();
            }

            span.StoppedAtUtc = DateTime.UtcNow;

            var ongoingSpans = await _dbContext.Spans.AnyAsync(s => s.TraceIdentifier == request.TraceIdentifier && s.StoppedAtUtc != null);
            if (!ongoingSpans)
            {
                var trace = await _dbContext.Traces.SingleOrDefaultAsync(t => t.TraceIdentifier == request.TraceIdentifier);
                trace.StoppedAtUtc = DateTime.UtcNow;
            }

            await _dbContext.SaveChangesAsync();

            return new Empty();
        }

        private bool StopSpanRecursive(DottySpan spanData, string spanIdentifier)
        {
            if (spanData.SpanIdentifier == spanIdentifier)
            {
                spanData.StoppedAtUtc = DateTime.UtcNow;
                return true;
            }
            else
            {
                foreach (var span in spanData.ChildSpans)
                {
                    if (StopSpanRecursive(span, spanIdentifier))
                    {
                        return true;
                    }
                }
            }
            return false;
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

            var span = await _dbContext.Spans.SingleOrDefaultAsync(t => t.SpanIdentifier == request.SpanIdentifier);
            var logLine = new DottyLogLine { Message = request.Message, DateTimeUtc = DateTime.UtcNow, TraceIdentifier = span.TraceIdentifier, SpanIdentifier = span.SpanIdentifier };
            
            span.Logs.Add(logLine);
            await _dbContext.SaveChangesAsync();

            await _uiUpdateHub.Clients.All.SendAsync("LogMessage", logLine);
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
