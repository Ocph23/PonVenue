using Microsoft.AspNetCore.Mvc;
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
            return Ok(_context.DataJadwal.ToList().Where(x=>x.StartDate.Value.Ticks >= DateTime.Now.Ticks));
        }

        // GET api/<JadwalController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_context.DataJadwal.FirstOrDefault(x=>x.Id==id));
        }

        [HttpGet("bydate/{startdate}/{enddate}")]
        public IActionResult GetByDate(long startdate, long enddate)
        {
           var data = _context.DataJadwal.ToList().Where(x => x.StartDate.Value.Ticks >= startdate && x.EndDate.Value.Ticks <= enddate);
           return Ok(data);
        }

    }
}
