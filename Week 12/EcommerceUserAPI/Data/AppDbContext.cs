using Microsoft.EntityFrameworkCore;
using EcommerceUserAPI.Models;

namespace EcommerceUserAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}