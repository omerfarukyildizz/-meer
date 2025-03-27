using Microsoft.EntityFrameworkCore;

namespace Pbk.Entities.Views
{
    [Keyless]
    public class ContainerList
    {
        public int? id { get; set; }
        public int? sirket { get; set; }
        public int? yil { get; set; }
        public int? yukno { get; set; }
        public string? konteynerno { get; set; }
        public string? konteynertipi { get; set; }
        public string? varisyeradi { get; set; }
        public string? sealno { get; set; }
        public int? adet { get; set; }
        public string? birim { get; set; }
        public int? parca { get; set; }
        public string? parcabirim { get; set; }
        public double? brutkg { get; set; }
        public double? m3 { get; set; }
        public string? aciklama { get; set; }
        public string? pono { get; set; }
        public string? htsno { get; set; }
        public string? vesselname { get; set; }
        public string? voyagenumber { get; set; }
        public string? Ieventcode { get; set; }
        public string? Ilocation { get; set; }
        public DateTime? Istatuschangedate { get; set; }
        public int? labelpieces { get; set; }
        public double? paletkgs { get; set; }
        public double? paletlbs { get; set; }
        public string? available { get; set; }
        public string? yardlocation { get; set; }
        public string? freight { get; set; }
        public string? line { get; set; }
        public string? terminal { get; set; }
        public string? customs { get; set; }
        public string? exam { get; set; }
        public string? usda { get; set; }
        public string? misc { get; set; }
        public string? hazards { get; set; }
        public DateTime? discharges { get; set; }
        public DateTime? lastfreedays { get; set; }
        public string? demurrageamount { get; set; }
        public string? demurragedue { get; set; }
        public string? outgate { get; set; }
        public DateTime? outgatedates { get; set; }
        public string? Ingate { get; set; }
        public DateTime? Ingatedates { get; set; }
        public DateTime? portlfds { get; set; }
    }
}
