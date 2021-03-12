using Microsoft.EntityFrameworkCore;

namespace DottyLogs.Server.DbModels
{

    public abstract class DottyDbContext : DbContext
    {
        public DbSet<DottyTrace> Traces { get; set; }
        public DbSet<DottySpan> Spans { get; set; }
    }

}
