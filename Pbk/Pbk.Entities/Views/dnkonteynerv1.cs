using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Views
{
    [Keyless]
    public class dnkonteynerv1
    {
        public int? sirket { get; set; }
        public int? yil { get; set; }
        public int? dseferno { get; set; }
        public string? konteynertipi { get; set; }
        public string? konteynerno { get; set; }
        public int? yukno { get; set; }
        public int? adet { get; set; }
        public string? birim { get; set; }
        public int? parca { get; set; }
        public string? parcabirim { get; set; }
        public double? brutkg { get; set; }
        public double? m3 { get; set; }
        public string? aciklama { get; set; }
        public string? MalzemeAdi { get; set; }
        public string? sealno { get; set; }
        public string? POno { get; set; }
        public string? HTSno { get; set; }
        public string? YerliYabanci { get; set; }
        public double? ucretagirligi { get; set; }
        public string? VesselName { get; set; }
        public string? VoyageNumber { get; set; }
        public int? KonyetnerID { get; set; }
        public int? ESSITYEntegrasyonStatu { get; set; }
    }
}
