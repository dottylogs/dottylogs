using DottyLogs.Server.DbModels;
using Microsoft.EntityFrameworkCore;

namespace DottyLogs.Server.Sqlite
{
    public class SqliteDottyDbContext : DottyDbContext
    {
        private readonly string _connectionString;

        public SqliteDottyDbContext()
            : base()
        {
            _connectionString = @"Data Source=DottyLogs.db";
        }

        public SqliteDottyDbContext(string connectionString)
            : base()
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite(_connectionString);
        }
    }

    public class SqliteContextFactory
    {
        private readonly string _connectionString;

        public SqliteContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DottyDbContext Build()
        {
            return new SqliteDottyDbContext(_connectionString);
        }
    }
}
