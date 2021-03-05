using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DottyLogs
{
    public static class UiExtensions
    {
        public static IServiceCollection AddDottyUi(this IServiceCollection services)
        {
            services.AddSpaStaticFiles(c => c.RootPath = "/");

            return services;
        }
        public static IApplicationBuilder UseDottyUi(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSpaStaticFiles();
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "client-app";
                if (env.IsDevelopment())
                {
                    // Launch development server for Vue.js
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:3000");
                }
            });

            return app;
        }
    }
}
