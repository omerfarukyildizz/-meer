using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Views
{
    [Keyless]
    public partial class RevenueAndCostDto
    {
        public int? seferdeniz { get; set; }
        public int yukno { get; set; }
        public string? USA_Fileno { get; set; }
        public int? Dosyaay { get; set; }
        public string? Done { get; set; }
        public string? Gonderici_Adi { get; set; }
        public string? Alici_Adi { get; set; }
        public string? FirmaAdi { get; set; }
        public int? hacenta { get; set; }
        public string? denizarakonsimento { get; set; }
        public string? gteslimsekli { get; set; }
        public string? yuktipi { get; set; }
        public double? kap { get; set; }
        public string? birim { get; set; }
        public double? burutkg { get; set; }
        public double? netkg { get; set; }
        public double? cubic { get; set; }
        public string? salesprice { get; set; }
        public int? dosyadeniz { get; set; }
    }
}
