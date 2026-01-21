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
        public DbSet<Schedule> Schedules { get; set; } = null!;
        public DbSet<Reservation> Reservations { get; set; } = null!;
        public DbSet<ReservationSchedule> ReservationSchedules { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Composite Primary Key за many-to-many таблицата
            builder.Entity<ReservationSchedule>()
                .HasKey(rs => new { rs.ReservationId, rs.ScheduleId });

            builder.Entity<ReservationSchedule>()
       .HasOne(rs => rs.Reservation)
       .WithMany(r => r.ReservationSchedules)
       .HasForeignKey(rs => rs.ReservationId)
       .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ReservationSchedule>()
                .HasOne(rs => rs.Schedule)
                .WithMany(s => s.ReservationSchedules)
                .HasForeignKey(rs => rs.ScheduleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
