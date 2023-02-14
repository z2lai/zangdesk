using Microsoft.EntityFrameworkCore;
using ZangDesk.Core;

namespace ZangDesk.API.Data
{
    public class IssueDbContext : DbContext
    {
        public IssueDbContext(DbContextOptions<IssueDbContext> options)
            :base(options)
        {
        }

        public DbSet<Issue> Issues { get; set; }
        
    }
}
