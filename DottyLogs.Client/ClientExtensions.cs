using DottyLogs.Client;
using DottyLogs.Client.BackgroundServices;
using DottyLogs.Client.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace DottyLogs
{
    public static class ClientExtensions
    {
        public static IServiceCollection AddDottyRequestTracing(
            this IServiceCollection builder,
            Action<DottyLogLoggerConfiguration> configure)
        {
            var config = new DottyLogLoggerConfiguration();
            configure(config);

            builder.Configure(configure);
            builder.Configure<DottyLogLoggerConfiguration>(o => o.DottyAddress = config.DottyAddress);

            return builder.AddDottyRequestTracing(config);
        }

        private static IServiceCollection AddDottyRequestTracing(this IServiceCollection services, DottyLogLoggerConfiguration config)
        {
            services.AddHostedService(c => new MetricsAndHeartbeatBackgroundService(c.GetRequiredService<ILogger< MetricsAndHeartbeatBackgroundService>>(), config));

            var sink = new DottyLogSink(config);

            services.AddLogging(
                b => b.AddProvider(new DottyLogLoggerProvider(config, sink)));

            services.AddScoped<DottyLogsScopedContext>();
            services.AddSingleton<UpdatePusherService>();
            services.AddScoped<DottyHeaderMessageHandler>();
            services.AddHttpContextAccessor();
            services.AddHttpClient(Microsoft.Extensions.Options.Options.DefaultName).AddDottyLog();
            
            return services;
        }

        public static IApplicationBuilder UseDottyLogs(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DottyRequestTracingMiddleware>();
        }

        public static DottyLogLoggerProvider CreateProvider(DottyLogLoggerConfiguration config)
        {
            var sink = new DottyLogSink(config);

            return new DottyLogLoggerProvider(config, sink);
        }

        public static IHttpClientBuilder AddDottyLog(this IHttpClientBuilder builder)
        {
            builder.AddHttpMessageHandler<DottyHeaderMessageHandler>();
            return builder;
        }
    }
}
