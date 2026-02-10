using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VsProdsWebShop.Infrastructure.Data.Entities;


namespace VsProdsWebShop.Infrastucture.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<ServiceAvailable> ServicesAvailable { get; set; } = null!;
        public DbSet<Reservation> Reservations { get; set; } = null!;
        

    }
}
