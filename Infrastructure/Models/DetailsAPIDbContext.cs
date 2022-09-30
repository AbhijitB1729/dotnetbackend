using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace RegisterAPI.Models
{
    public class DetailsAPIDbContext : DbContext
    {
        public DetailsAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Detail> Details { get; set; }
        public DbSet<GrantDetail> GrantDetails { get; set; }

    }
}
