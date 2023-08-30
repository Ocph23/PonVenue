using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PonVenue.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenueController : ControllerBase
    {
        // GET: api/<JadwalController>

        private ApplicationDbContext _context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
        public VenueController(ApplicationDbContext context, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.DataVenue.Include(x=>x.Kota).ToList());
        }


        [HttpGet("download")]
        public FileResult downloadFile()
        {
            string wwwrootPath =Path.Combine(_hostingEnvironment.WebRootPath,"files");
            string fileName = @"com.ocph23.ponvenuemobileSigned.apk";
            FileStream fileStream = new FileStream(Path.Combine(wwwrootPath, fileName), FileMode.Open, FileAccess.Read);
            return File(fileStream, "application/octet-stream", "com.ocph23.ponvenuemobileSigned.apk");
        }



    }
}
