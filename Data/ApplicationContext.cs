using Microsoft.EntityFrameworkCore;

namespace net_shop_back.Data
{
    public class ApplicationContext : DbContext
    {
        private readonly IConfiguration _config;
        
        public ApplicationContext(DbContextOptions<ApplicationContext> options, IConfiguration config)
            : base(options)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connStr = _config.GetConnectionString("MySQL")
                         ?? throw new InvalidOperationException("Connection string not found");
            optionsBuilder.UseMySql(connStr, ServerVersion.AutoDetect(connStr));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly).HasCharSet("utf8mb4");
            base.OnModelCreating(modelBuilder);
        }
    }
}
