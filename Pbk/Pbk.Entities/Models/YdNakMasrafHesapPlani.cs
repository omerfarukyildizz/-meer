using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Models
{
    [Keyless]
    public class YdNakMasrafHesapPlani
    {
        public string? SapSirketKodu { get; set; }
        public string? HesapKodu { get; set; }
        public string? HesapAdi { get; set; }
        public string? SapFirmaNo { get; set; }
        public string? Adres { get; set; }
    }
}
