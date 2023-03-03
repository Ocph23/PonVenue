using System.ComponentModel.DataAnnotations.Schema;

namespace PonVenueMobile.Models
{
    public class Venue
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public int Kapasitas { get; set; }
        public string Alamat { get; set; }
        public string? Latitdue { get; set; } = string.Empty;
        public string? Longitude { get; set; } = string.Empty;
        public string LatLong => $"{Latitdue};{Longitude}";
    }
}
