using PonVenue.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PonVenue.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Cabor> DataCabor{ get; set; }
        public DbSet<Kota> DataKota{ get; set; }
        public DbSet<Jadwal> DataJadwal{ get; set; }
        public DbSet<Venue> DataVenue{ get; set; }
    }
}