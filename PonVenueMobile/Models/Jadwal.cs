namespace PonVenueMobile.Models
{
    public class Jadwal
    {
        public int Id { get; set; }
        public DateTime? StartDate { get; set; } = DateTime.Now;
        public DateTime? EndDate { get; set; } = DateTime.Now;
        public string? Keterangan { get; set; }
        public Cabor Cabor { get; set; }
        public Venue Venue { get; set; }
    }
}
