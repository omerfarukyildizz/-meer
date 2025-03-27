using Pbk.Entities.Abstractions;
using Pbk.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pbk.Entities.Views
{
    [Keyless]
    public class DenizFaturaMasrafListe
    {
        public string? durum { get; set; }
        public DateTime? faturatarihi { get; set; }
        public string? faturano { get; set; }
        public int faturahrkid { get; set; }
        public int sirket { get; set; }
        public int yil { get; set; }
        public string? departman { get; set; }
        public string? sektor { get; set; }
        public int? yukno { get; set; }
        public int? seferno { get; set; }
        public string? firmano { get; set; }
        public string? firmatipi { get; set; }
        public string? BedelAciklama { get; set; }
        public string? aciklamaturu { get; set; }
        public string? giderkodu { get; set; }
        public double? beklenendoviztutar { get; set; }
        public string? beklenendoviztur { get; set; }
        public string? yukdepartman { get; set; }
        public string? karsilayandepartman { get; set; }
        public string? prefix { get; set; }
        public bool? kesilmeyecek { get; set; }
        public bool? beklenenonay { get; set; }
        public string? TabloAdi { get; set; }
        public string? satici { get; set; }
        public string? gelirkodu { get; set; }
        public double? doviztutar { get; set; }
        public string? doviztur { get; set; }
        public double? tltutar { get; set; }
        public string? aciklama { get; set; }
        public string? entegreno { get; set; }
        public double? kdvorani { get; set; }
        public string? firmcode { get; set; }
        public string? firmname { get; set; }
        public string? Item { get; set; }
        public string? Itemcode { get; set; }
    }
}
