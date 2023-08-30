using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PonVenueMobile.Models
{
    public class Lokasi
    {
        public Location Position { get; set; }
        public string? Address { get; set; } = string.Empty;
        public string? Label { get; set; } = string.Empty;

    }
}
