using EventEase.Models;
using Microsoft.EntityFrameworkCore;

namespace EventEase.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Venue> Venues { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingView> BookingView { get; set; }
        public DbSet<BookingView> Bookingview { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
          {
             base.OnModelCreating(modelBuilder);
             modelBuilder.Entity<BookingView>()
                .HasNoKey()
                .ToView("BookingView");

            modelBuilder.Entity<EventType>().HasData(
        new EventType
        {
            EventTypeId = 1,
            Name = "Conference"
        },
        new EventType
        {
            EventTypeId = 2,
            Name = "Concert"
        },
        new EventType
        {
            EventTypeId = 3,
            Name = "Sports"
        },
        new EventType
        {
            EventTypeId = 4,
            Name = "Festival"
        }
    );
        }


    }
}
