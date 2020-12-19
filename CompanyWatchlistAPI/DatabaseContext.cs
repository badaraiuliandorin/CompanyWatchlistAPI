using CompanyWatchlistAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CompanyWatchlistAPI
{
    public class DatabaseContext : DbContext
    {
        private readonly DbContextOptions _dbContextOptions;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DatabaseContext(DbContextOptions<DatabaseContext> options, IConfiguration configuration, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _dbContextOptions = options;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Watchlist> Watchlist { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.UseLazyLoadingProxies();
    }
}
