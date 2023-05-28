using AwesomeDevEvents.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace AwesomeDevEvents.Api.Persistence
{
    public class DevEventsDbContext : DbContext
    {
        public DbSet<DevEvent> DevEvents { get; set; }
        public DbSet<DevEventSpeaker> DevEventSpeakers { get; set; }

        public DevEventsDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DevEvent>(e =>
            {
                e.HasKey(e => e.Id);
                e.Property(e => e.Title).IsRequired();
                e.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");
                e.Property(e => e.StartDate)
                .HasColumnName("Start_Date");   
                e.Property(e => e.EndDate)
                .HasColumnName("End_Date");
                
                e.HasMany(e => e.Speakers)
                .WithOne()
                .HasForeignKey(e => e.DevEventId);
            });

            modelBuilder.Entity<DevEventSpeaker>(e =>
            {
                e.HasKey(e => e.Id);

            });
        }
    }
}
