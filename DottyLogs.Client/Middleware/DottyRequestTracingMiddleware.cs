using DottyLogs.Client.BackgroundServices;
using Google.Protobuf.WellKnownTypes;
using GrpcDottyLogs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Net;
using System.Reflection;
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
            var dottyContext = new DottyLogsScopedContext { SpanId = spanIdentifier };
            
            // First, check if we have something in headers already
            if (context.Request.Headers.TryGetValue("X-TRACE-IDENTIFIER", out StringValues traceIdentifer))
            {
                if (traceIdentifer.Count == 1)
                {
                    context.TraceIdentifier = traceIdentifer[0];
                }
            }

            if (context.Request.Headers.TryGetValue("X-PARENT-SPANID", out StringValues parentSpanId))
            {
                if (parentSpanId.Count == 1)
                {
                    dottyContext.ParentSpanId = parentSpanId[0];
                }
            }

            DottyLogsScopedContextAccessor.DottyLogsScopedContext = dottyContext;


            // Tell hub we started
            var requestUpdate = new StartSpanRequest
            {
                TraceIdentifier = context.TraceIdentifier,
                ThreadId = Thread.CurrentThread.ManagedThreadId,
                RequestUrl = context.Request.Path.ToString(),
                SpanIdentifier = spanIdentifier,
                ParentSpanIdentifier = DottyLogsScopedContextAccessor.DottyLogsScopedContext.ParentSpanId,
                Timestamp = DateTime.UtcNow.ToTimestamp(),
                Hostname = Dns.GetHostName(), //TODO move to lazy property
                ApplicationName = Assembly.GetEntryAssembly().GetName().Name
            };

            await _updatePusherService.StartSpan(requestUpdate);

            try
            {
                await _next(context);
            }
            finally
            {
                await _updatePusherService.StopSpan(new StopSpanRequest { SpanIdentifier = spanIdentifier, WasSuccess = true, TraceIdentifier = context.TraceIdentifier });
            }
        }
    }
}
