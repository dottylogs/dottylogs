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
        public static IServiceCollection AddDottyRequestTracing(this IServiceCollection services)
        {
            services.AddHostedService<MetricsAndHeartbeatBackgroundService>();
            var config = new DottyLogLoggerConfiguration();

            var sink = new DottyLogSink();

            services.AddLogging(
                b => b.AddProvider(new DottyLogLoggerProvider(config, sink)));

            services.AddScoped<DottyLogsScopedContext>();
            services.AddSingleton<UpdatePusherService>();
            return services;
        }

        public static IApplicationBuilder UseDottyLogs(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DottyRequestTracingMiddleware>();
        }

        public static DottyLogLoggerProvider CreateProvider(DottyLogLoggerConfiguration config)
        {
            var sink = new DottyLogSink();

            return new DottyLogLoggerProvider(config, sink);
        }

        //public static ILoggingBuilder AddDottyLogRequestTracer(
        //this ILoggingBuilder builder) =>
        //builder.AddDottyLogRequestTracer(
        //    new DottyLogLoggerConfiguration());

        //public static ILoggingBuilder AddDottyLogRequestTracer(
        //    this ILoggingBuilder builder,
        //    Action<DottyLogLoggerConfiguration> configure)
        //{
        //    var config = new DottyLogLoggerConfiguration();
        //    configure(config);

        //    return builder.AddDottyLogRequestTracer(config);
        //}

        //public static ILoggingBuilder AddDottyLogRequestTracer(
        //    this ILoggingBuilder builder,
        //    DottyLogLoggerConfiguration config)
        //{
        //    builder.AddProvider(new DottyLogLoggerProvider(config));
        //    return builder;
        //}
    }
}
