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

        public override async Task<StartSpanResponse> StartSpan(StartSpanRequest request, ServerCallContext context)
        {
            await _uiUpdateHub.Clients.All.SendAsync("RequestLifecycle", request);
            return new StartSpanResponse
            {
                Message = "Processed"
            };
        }
    }
}
