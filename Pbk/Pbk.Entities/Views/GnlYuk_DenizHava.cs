using Pbk.Entities.Abstractions;
using Pbk.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pbk.Entities.Views
{
    [Keyless]
    public class GnlYuk_DenizHava
    {
        public int? seferdeniz { get; set; }
        public int yukno { get; set; }
        public string? Gonderici_Adi { get; set; }
        public string? Alici_Adi { get; set; }
        public int? hacenta { get; set; }
        public string? havaarakonsimento { get; set; }
        public string? arakonsimento { get; set; }
        public string? gteslimsekli { get; set; }
        public string? yuktipi { get; set; }
        public double? kap { get; set; }
        public string? birim { get; set; }
        public double? burutkg { get; set; }
        public double? netkg { get; set; }
        public double? cubic { get; set; }
        public string? salesprice { get; set; }
        public int? dosyadeniz { get; set; }
        public string? ydimex { get; set; }
        public string? yukdepartman { get; set; }
        public string? ExBglFileNo { get; set; }
    }
}
