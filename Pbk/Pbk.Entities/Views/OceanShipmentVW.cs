using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Views
{
    [Keyless]
    public class OceanShipmentVW
    {
        public int YukNo { get; set; }
        public int? Deviryukno { get; set; }
        public string? Departman { get; set; }
        public string? KarsilayanDepartman { get; set; }
        public string? YukDepartman { get; set; }
        public string? FirmaAdi { get; set; }
    
        public string? HBLtype { get; set; }
        public string? Denizarakonsimento { get; set; }
     
         public string? DnYuklemeTipi { get; set; }
        public DateTime? Dnets { get; set; }
        public string? Dnyuklemeyeri { get; set; }
        public string? Loadingacentaadi { get; set; }
    
        public double? Cubic { get; set; }
        public float? Lademetre { get; set; }
         public int? YuklemeHafta { get; set; }
         public int? seferkara { get; set; }

        public DateTime? yuklentarih { get; set; }

        public string? YuklenUlkeAdi { get; set;    }
        public string? ExBglFileNo { get; set;    }
        public string? ImBglFileNo { get; set;    }
        public string? Manufactureradi { get; set;    }

        public bool? Naksekd { get; set; }
        public long? isemrino { get; set; }
        public string? BglTrFileNo { get; set; }
        public int? dosyadeniz { get; set; }
        public bool? denetimOK { get; set; }
        public string? denetimaciklama { get; set; }
        public string? FaturaAciklama { get; set; }
        public string? MasrafAciklama { get; set; }
        public DateTime? Cutoff { get; set;     }
        public string? DnAnaKonsimentoNo { get; set; }
        public string? Bosalulke { get; set; }
        public string? BosalulkeAdi { get; set; }
        public string? Malturkadi { get; set; }
        public int? sirket { get; set; }
        public int? yil { get; set; }
        public string? CikisYerAdi { get; set;  }
        public string? VarisYerAdi { get; set;  }
        public string? Gteslimsekli { get; set;  }
        public int? SeferDeniz { get; set; }
        public int? SeferHava { get; set; }
        public string? DurumAdi { get; set; }
        public int? Exyuksira { get; set; }
        public string? nteslimsekli { get; set; }
 
 
   
        public double? Kap { get; set; }
        public string? Birim { get; set; }
        public double? BurutKg { get; set; }
        public double? NetKg { get; set; }
        public double? MalBedeliDov { get; set; }
        public string? MalBedeliDovTur { get; set; }
        public string? Durum { get; set; }
        public int? insuser { get; set; }
        public string? insuserAdi { get; set; }
        public bool? Arsiv { get; set; }
        public DateTime? instime { get; set; }
        public int? CustomerShipper { get; set; }
        public int? CustomerConsignee { get; set; }
        public string? CustomBroker { get; set; }
        public string? DeliveryName { get; set; }
        public string? EmserStatus { get; set; }
        public string? Gonderici_Adi { get; set; }
        public string? Alici_Adi { get; set; }
        public string? dnacenta_adi { get; set; }

    }
}
