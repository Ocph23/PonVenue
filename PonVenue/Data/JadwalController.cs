using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PonVenue.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PonVenue.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class JadwalController : ControllerBase
    {
        // GET: api/<JadwalController>

        private ApplicationDbContext _context;

        public JadwalController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.DataJadwal.Include(x => x.Venue).ThenInclude(x=>x.Kota)
                .Include(x => x.Cabor).ToList().Where(x => x.StartDate.Value.Ticks >= DateTime.Now.Ticks));
        }

        // GET api/<JadwalController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_context.DataJadwal
                .Include(x => x.Venue).ThenInclude(x => x.Kota)
                .Include(x => x.Cabor)
                .FirstOrDefault(x => x.Id == id));
        }

        [HttpPost("bydate")]
        public IActionResult PostByDate(Jadwalrequest date)
        {
            var data = _context.DataJadwal
                 .Include(x => x.Venue)
                 .ThenInclude(x => x.Kota)
                 .Include(x => x.Cabor)
                 .Where(x=>x.StartDate.Value >= date.StartDate.Value && x.EndDate <= date.EndDate.Value);

            return Ok(data);
        }

    }
}
