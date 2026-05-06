using EventEase.Models;
using Microsoft.EntityFrameworkCore;

namespace EventEase.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Venue> Venues { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<BookingView> BookingView { get; set; }


    }
}
