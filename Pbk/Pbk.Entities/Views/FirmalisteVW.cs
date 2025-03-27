using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Views
{
    [Keyless]
    public class FirmalisteVW
    {
        public string? departman { get; set; }
        public int kodu { get; set; }
        public string? adi { get; set; }
        public string? grup { get; set; }
        public int? yd { get; set; }
        public string? Mtgrup { get; set; }
        public string? SapFirmaNo { get; set; }
        public int? musterisahibi { get; set; }
        public int? onay { get; set; }
        public bool? antrepomusteri { get; set; }
        public bool? yuktekullanilamaz { get; set; }
        public bool? BolgeMasrafFirmasi { get; set; }
        public DateTime? instime { get; set; }
        public string? sektor { get; set; }
        public int? dvalor { get; set; }
        public string? Ydacente { get; set; }
        public string? trdepartman { get; set; }
        public string? yddepartman { get; set; }
      
    }
}