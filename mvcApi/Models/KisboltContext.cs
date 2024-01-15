using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace mvcApi.Models
{
    public class KisboltContext: DbContext
    {
        public readonly string connStr = "server=localhost;userid=root;password=;database=kisboltapi";

        public KisboltContext(DbContextOptions<KisboltContext> options)
            : base(options)
        {
        }

        public DbSet<Kisbolt> Kisboltok { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connStr,ServerVersion.AutoDetect(connStr));   
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
