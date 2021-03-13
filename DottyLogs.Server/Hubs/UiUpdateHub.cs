using DottyLogs.Server.DbModels;
using Google.Protobuf.WellKnownTypes;
using GrpcDottyLogs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DottyLogs.Server.Hubs
{
    public class UiUpdateHub : Hub
    {
        private readonly ILogger<UiUpdateHub> _logger;
        private readonly DottyDbContext _dbContext;

        public UiUpdateHub(ILogger<UiUpdateHub> logger, DottyDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task StartStreamingDetails(string traceIdentifier)
        {
            var trace = await _dbContext.Traces.SingleOrDefaultAsync(t => t.TraceIdentifier == traceIdentifier);
            await Clients.Caller.SendAsync("NewTrace", trace);

            var spans = await _dbContext.Spans.Where(t => t.TraceIdentifier == traceIdentifier).ToListAsync();
            foreach (var span in spans)
            {
                await Clients.Caller.SendAsync("StartSpan", new StartSpanRequest { TraceIdentifier = traceIdentifier, SpanIdentifier = span.SpanIdentifier, RequestUrl = span.RequestUrl, ParentSpanIdentifier = span.ParentSpanIdentifier, ApplicationName = span.ApplicationName, Hostname = span.HostName, Timestamp = DateTime.SpecifyKind(span.StartedAtUtc, DateTimeKind.Utc).ToTimestamp() });
                if (span.StoppedAtUtc.HasValue)
                {
                    await Clients.Caller.SendAsync("StopSpan", new StopSpanRequest { TraceIdentifier = traceIdentifier, SpanIdentifier = span.SpanIdentifier, Timestamp = DateTime.SpecifyKind(span.StoppedAtUtc.Value, DateTimeKind.Utc).ToTimestamp(), WasSuccess = true });
                }
            }

            var logs = await _dbContext.Logs.Where(t => t.TraceIdentifier == traceIdentifier).ToListAsync();
            foreach (var log in logs)
            {
                await Clients.Caller.SendAsync("LogMessage", log);
            }
            
        }
    }
}
