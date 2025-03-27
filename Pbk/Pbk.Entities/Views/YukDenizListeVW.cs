using Microsoft.EntityFrameworkCore;


namespace Pbk.Entities.Views
{
    [Keyless]
    public class YukDenizListeVW
    {



        public int? yukno { get; set; }




        public string? Gonderici_Adi { get; set; }



        public string? Alici_Adi { get; set; }
        public string? denizarakonsimento { get; set; }
        public string? CikisLimanAdi { get; set; }
        public string? VarisLimanAdi { get; set; }
        public double? kap { get; set; }

        public string? birim { get; set; }

        public double? burutkg { get; set; }
        public double? cubic { get; set; }
        public string? yukdepartman { get; set; }
        public string? karsilayandepartman { get; set; }
        public DateTime? cutoff { get; set; }
        public string? DnCikisLiman { get; set; }
        public string? DnVarisLiman { get; set; }
        public string? BglTrFileNo { get; set; }
        public string? dnacenta_adi { get; set; }
        public string? ydimex { get; set; }
        public string? yiimex { get; set; }
        public string? FirmaAdi { get; set; }
        public string? dnGemiAcentaAdi { get; set; }
        public string? dnLinerAd { get; set; }
        public int? sirket { get; set; }
        public int? yil { get; set; }
        public string? insuserAdi { get; set; }
        public DateTime? instime { get; set; }
        public string? inshafta { get; set; }
        public string? DurumAdi { get; set; }
        public string? OzelDurum { get; set; }
        public string? salesprice { get; set; }
        public string? dnKonteynerBilgi { get; set; }

        public string? Manufactureradi { get; set; }
        public bool? Naksekd { get; set; }

        public int? Seferdeniz { get; set; }

        public string? arakonsimento { get; set; }

        public string? FaturaAciklama { get; set; }

        public string? MasrafAciklama { get; set; }
        public string? VarisYerAdi { get; set; }
        public string? Detay { get; set; }




    }
}
