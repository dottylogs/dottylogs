using DottyLogs.Client.BackgroundServices;
using GrpcDottyLogs;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DottyLogs.Client.Middleware
{
    public class DottyRequestTracingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly UpdatePusherService _updatePusherService;

        public DottyRequestTracingMiddleware(RequestDelegate next, UpdatePusherService updatePusherService)
        {
            _next = next;
            _updatePusherService = updatePusherService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var spanIdentifier = Guid.NewGuid().ToString();
            DottyLogsScopedContextAccessor.DottyLogsScopedContext = new DottyLogsScopedContext { SpanId = spanIdentifier };

            // Tell hub we started
            var requestUpdate = new StartSpanRequest
            {
                TracingIdentifier = context.TraceIdentifier,
                ThreadId = Thread.CurrentThread.ManagedThreadId,
                RequestUrl = context.Request.Path.ToString(),
                SpanIdentifier = spanIdentifier
            };

            await _updatePusherService.StartSpan(requestUpdate);

            try
            {
                await _next(context);
            }
            finally
            {
                await _updatePusherService.StopSpan(new StopSpanRequest { SpanIdentifier = spanIdentifier, WasSuccess = true, TracingIdentifier = context.TraceIdentifier });
            }
        }
    }
}
