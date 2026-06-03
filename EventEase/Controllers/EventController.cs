using EventEase.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventEase.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(
            string search,
            int? eventTypeId)
        {
            var events = _context.Events
                .Include(e => e.EventType)
                .AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                events = events.Where(e =>
                    e.Name.Contains(search));
            }

            if (eventTypeId.HasValue)
            {
                events = events.Where(e =>
                    e.EventTypeId == eventTypeId);
            }

            return View(events.ToList());
        }
    }
}
