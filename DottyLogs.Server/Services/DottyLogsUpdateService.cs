using DottyLogs.Server.Hubs;
using Grpc.Core;
using GrpcDottyLogs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
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
            await _uiUpdateHub.Clients.All.SendAsync("RequestLifecycle", request);
            return new Empty();
        }

        public override async Task<Empty> StopSpan(StopSpanRequest request, ServerCallContext context)
        {
            await _uiUpdateHub.Clients.All.SendAsync("RequestLifecycle", request);
            return new Empty();
        }

        public override async Task<Empty> MetricsUpdate(IAsyncStreamReader<MetricsUpdateRequest> requestStream, ServerCallContext context)
        {
            await foreach (var message in requestStream.ReadAllAsync())
            {
                _logger.LogInformation("Got metrics update");
            }
            
            return new Empty();
        }

        public override async Task<Empty> PushLogMessage(LogRequest request, ServerCallContext context)
        {
            _logger.LogInformation($"Got log update: {request.Message}, {request.SpanIdentifier}");
            return new Empty();
        }
    }
}
