using DottyLogs.Server.DbModels;
using DottyLogs.Server.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DottyLogs
{
    public static class DottySqliteExtensions
    {
        public static IServiceCollection AddDottySqliteDb(this IServiceCollection services)
        {
            services.AddDbContext<DottyDbContext, SqliteDottyDbContext>(opt => opt.UseSqlite(@"Data Source=DottyLogs.db"));
            
            return services;
        }
    }
}
