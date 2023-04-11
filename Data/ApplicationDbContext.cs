using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Itec245_Final.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Models.Shoes> shoes { get; set; }
        public DbSet<Models.CartData> CartData { get; set; }

       public DbSet<Models.OrderHistory> OrderHistories { get; set; }
    }
}