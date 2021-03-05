using DottyLogs.Client.BackgroundServices;
using Microsoft.Extensions.DependencyInjection;

namespace DottyLogs
{
    public static class ClientExtensions
    {
        public static IServiceCollection AddDottyRequestTracing(this IServiceCollection services)
        {
            services.AddHostedService<MetricsAndHeartbeatBackgroundService>();

            return services;
        }
    }
}
