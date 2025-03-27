using Microsoft.EntityFrameworkCore;

namespace Pbk.Entities.Views
{
    [Keyless]
    public class dnseferV0
    {
        public int? dseferno { get; set; }
        public string? konsimentono { get; set; }
        public string? imex { get; set; }
        public string? ydimex { get; set; }
        public string? departman { get; set; }
        public string? gemiacentaadi { get; set; }
        public string? cikisliman { get; set; }
        public string? cikislimanadi { get; set; }
        public string? varisliman { get; set; }
        public string? varislimanadi { get; set; }
        public string? gemiadi { get; set; }
        public string? lineradi { get; set; }
        public string? gemiseferno { get; set; }
        public DateTime? cikistarihi { get; set; }
        public DateTime? varistarihi { get; set; }
        public string? cutoff { get; set; }
        public bool? arsiv { get; set; }
        public string? yuklemetipi { get; set; }
        public string? gemikodu { get; set; }
    }
}