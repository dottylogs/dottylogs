using Microsoft.Extensions.Hosting;

namespace DottyLogs.Server.Sqlite
{
    internal class Program
    {
        private static void Main(string[] args)
            => CreateHostBuilder(args).Build().Run();

        #region snippet_CreateHostBuilder
        public static IHostBuilder CreateHostBuilder(string[] args)
            => Host.CreateDefaultBuilder(args)
                .ConfigureServices(
                    (hostContext, services) =>
                    {
                        services.AddDottySqliteDb();
                    });
        #endregion
    }
}
