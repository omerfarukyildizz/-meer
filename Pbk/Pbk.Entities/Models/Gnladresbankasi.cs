using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Models
{
    public partial class Gnladresbankasi
    {
        [Key]
        public int kodu { get; set; }
        public string? vergikodu { get; set; }
        public string? vergidairesi { get; set; }
        public string? adi { get; set; }
        public string? adres1 { get; set; }
        public string? adres2 { get; set; }
        public string? il { get; set; }
        public string? ulke { get; set; }
        public string? postakodu { get; set; }
        public string? telefon { get; set; }
        public string? fax { get; set; }
        public string? ilgili { get; set; }
        public string? mail { get; set; }
        public string? url { get; set; }
        public int? upduser { get; set; }
        public DateTime? updtime { get; set; }
        public DateTime? instime { get; set; }
        public int? insuser { get; set; }
        public string? ydisiacente { get; set; }
        public bool? gonderici_alici { get; set; }
        public bool? nakliyeci { get; set; }
        public bool? BarsanFirma { get; set; }
        public bool? yiciAcente { get; set; }
        public bool? DenizAcenteListesindeGozuksun { get; set; }
        public bool? acente { get; set; }
        public string? TedarikciKod { get; set; }
        public string? YurtDisiBglDepartman { get; set; }
        public int? TerminSure { get; set; }
        public string? TedarikciBolge { get; set; }
        public string? TedarikciMailGrup { get; set; }
        public int? IhbarGecmeSure { get; set; }
        public int? SaatFarki { get; set; }
        public int? webgroup { get; set; }
        public bool? CrfOfShpGonder { get; set; }
        public bool? altnakliyeci { get; set; }
        public bool? altacente { get; set; }
        public string? ilce { get; set; }
        public string? telefon2 { get; set; }
        public string? fax2 { get; set; }
        public string? genelemail { get; set; }
        public string? pozisyon { get; set; }
        public string? ilgili2 { get; set; }
        public string? pozisyon2 { get; set; }
        public string? mail2 { get; set; }
        public bool? tarifeprogrami { get; set; }
        public bool? ForwarderMusterisi { get; set; }
        public int? kompleterminsure { get; set; }
        public string? yetkili2 { get; set; }
        public string? yetkili2email { get; set; }
        public bool? masraffirma { get; set; }
        public string? division { get; set; }
        public string? sehirkodu { get; set; }
        public string? musterikodu { get; set; }
        public bool? Bshsecim { get; set; }
        public int? freetime { get; set; }
        public bool? AltUretici { get; set; }
        public bool? gaonay { get; set; }
        public string? CustPlant { get; set; }
        public double? latitude { get; set; }
        public double? longitude { get; set; }
        public string? mbtAddrNo { get; set; }
        public bool? denizInUse { get; set; }
        public bool? havaInUse { get; set; }
        public string? firmatipi { get; set; }
        public bool? onay1 { get; set; }
        public bool? onay2 { get; set; }
        public string? iptalnedeni { get; set; }
        public bool? onayagonderildi { get; set; }
        public string? EoriNo { get; set; }
        public string? kayityeri { get; set; }
        public bool? karaInUse { get; set; }
        public string? mtgrubu { get; set; }
        public bool? gmasrafinUse { get; set; }
        public string? sbankaadi { get; set; }
        public string? sbankaSube { get; set; }
        public string? sbankasubekod { get; set; }
        public string? sbankaibantl { get; set; }
        public string? sbankaibanusd { get; set; }
        public string? sbankaibaneur { get; set; }
        public string? sbankaibangbp { get; set; }
        public string? SmAddrNo { get; set; }
        public string? MersisNo { get; set; }
        public string? depo { get; set; }
        public string? iiksno { get; set; }
        public double? TaramaOpsiyon { get; set; }
        public bool OzmalNakliyeci { get; set; }
        public bool TmcNakliyeci { get; set; }
        public string? vergikodu_Sifreli { get; set; }
        public string? telefon_Sifreli { get; set; }
        public string? mail_Sifreli { get; set; }
        public string? telefon2_Sifreli { get; set; }
        public string? yetkili2email_Sifreli { get; set; }
        public string? vk { get; set; }
        public string? mbotAddrNo { get; set; }
    }

}
