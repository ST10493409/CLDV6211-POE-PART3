using EventEase.Data;
using EventEase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace EventEase.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string search)
        {
            var bookings = _context.BookingView.AsQueryable();

            if(!string.IsNullOrEmpty(search))
            {
                bookings = bookings.Where(b =>
                b.VenueName.Contains(search) ||
                b.EventName.Contains(search));
            }
            return View(bookings.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Booking booking)
        {
            var exists = _context.Booking.Any(b =>
            b.VenueId == booking.VenueId &&
            b.StartDate < booking.EndDate &&
            booking.StartDate < b.EndDate);

            if (exists)
            {
                ModelState.AddModelError("", "Venue already booked.");
                return View(booking);
            }

            _context.Booking.Add(booking);
            _context.SaveChanges();

            return RedirectToAction("Index");
                
        }

    }
}
