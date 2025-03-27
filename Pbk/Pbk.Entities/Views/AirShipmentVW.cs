using Pbk.Entities.Abstractions;
using Pbk.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pbk.Entities.Views
{
    [Keyless]
    public class AirShipmentVW
    {
        public int YukNo { get; set; }
        public int? SeferNo { get; set; }
        public int? DosyaNo { get; set; }
        public string? ImEx { get; set; }
        public string? Departman { get; set; }
        public string? KarsilayanDepartman { get; set; }
        public string? YukDepartman { get; set; }
        public int? FirmaKodu { get; set; }
        public string? FirmaAdi { get; set; }
        public int? GondericiKodu { get; set; }
        public string? GondericiAdi { get; set; }
        public int? AliciKodu { get; set; }
        public string? AliciAdi { get; set; }
        public string? FirmaReferans { get; set; }
        public string? TeslimSekli { get; set; }
        public string? HavayoluKodu { get; set; }
        public string? HavayoluAdi { get; set; }
        public string? Departure { get; set; }
        public string? DepartureAdi { get; set; }
        public string? Destination { get; set; }
        public string? DestinationAdi { get; set; }
        public string? UcusNo { get; set; }
        public DateTime? UcusTarihi { get; set; }
        public string? MAWB { get; set; }
        public string? HAWB { get; set; }
        public double? Kap { get; set; }
        public string? Birim { get; set; }
        public double? BurutKg { get; set; }
        public double? NetKg { get; set; }
        public double? MalBedeliDov { get; set; }
        public string? MalBedeliDovTur { get; set; }
        public string? Aciklama { get; set; }
        public string? Durum { get; set; }
        public int? KayitKullaniciKodu { get; set; }
        public string? KayitKullaniciAdi { get; set; }
        public bool? Arsiv { get; set; }
        public DateTime? YukAcilisTarihi { get; set; }
        public int? CustomerShipper { get; set; }
        public int? CustomerConsignee { get; set; }
    }
}
