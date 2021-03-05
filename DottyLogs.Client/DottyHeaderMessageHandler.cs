using DottyLogs.Client;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DottyLogs
{
    public class DottyHeaderMessageHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DottyHeaderMessageHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Always send trace identifier - TODO change this to something less http dependent
            request.Headers.Add("X-TRACE-IDENTIFIER", _httpContextAccessor.HttpContext.TraceIdentifier);

            if (DottyLogsScopedContextAccessor.IsInSpan)
            {
                request.Headers.Add("X-PARENT-SPANID", DottyLogsScopedContextAccessor.DottyLogsScopedContext.SpanId);
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}