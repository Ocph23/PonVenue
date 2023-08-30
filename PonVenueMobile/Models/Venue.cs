using System.ComponentModel.DataAnnotations.Schema;

namespace PonVenueMobile.Models
{
    public class Venue
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public Kota Kota { get; set; }
        public int Kapasitas { get; set; }
        public string Alamat { get; set; }
        public double Latitdue { get; set; } 
        public double Longitude { get; set; }
        public string LatLong => $"{Latitdue};{Longitude}";
    }
}
