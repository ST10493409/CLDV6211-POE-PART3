using EventEase.Data;
using EventEase.Services;
using Microsoft.AspNetCore.Mvc;
using EventEase.Models;

namespace EventEase.Controllers
{
    public class VenueController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly BlobService _blobService;

        public VenueController(ApplicationDbContext context, BlobService blobService)
        {
            _context = context;
            _blobService = blobService;
        }

        public IActionResult Index()
        {
            return View(_context.Venues.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Venue venue, IFormFile image)
        {
            if (image != null)
            {
                venue.ImageUrl = await _blobService.UploadAsync(image);
            }

            _context.Venues.Add(venue);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
