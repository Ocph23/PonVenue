using System.ComponentModel.DataAnnotations.Schema;

namespace PonVenue.Models
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
        public string LatLong => Latitdue ==0 || Longitude==0 ? string.Empty : $"{Latitdue};{Longitude}";
    }
}
