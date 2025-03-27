using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Views
{
    [Keyless]
    public partial class NB_HavaSeferListe_vw
    {
        public int sirket { get; set; }

        public int yil { get; set; }

        public int hseferno { get; set; }

        public string? imex { get; set; }

        public string? ydimex { get; set; }

        public string? havayolu { get; set; }

        public string? havayoluadi { get; set; }

        public string? anakonsimento { get; set; }

        public string? departure { get; set; }

        public string? departureadi { get; set; }

        public string? destination { get; set; }

        public string? destinationadi { get; set; }

        public int? acenta { get; set; }

        public string? acentaadi { get; set; }

        public string? to1 { get; set; }

        public string? to2 { get; set; }

        public string? to3 { get; set; }

        public string? by1 { get; set; }

        public string? by2 { get; set; }

        public string? by3 { get; set; }

        public string? ucusno1 { get; set; }

        public string? ucusno2 { get; set; }

        public string? ucusno3 { get; set; }

        public DateTime? ucustarihi1 { get; set; }

        public DateTime? ucustarihi2 { get; set; }

        public DateTime? ucustarihi3 { get; set; }

        public string? seferaciklama1 { get; set; }

        public string? seferaciklama2 { get; set; }

        public string? seferaciklama3 { get; set; }

        public DateTime? updtime { get; set; }

        public int? upduser { get; set; }

        public string? upduseradi { get; set; }

        public int? insuser { get; set; }

        public string? insuseradi { get; set; }

        public DateTime? instime { get; set; }

        public bool? arsiv { get; set; }

        public string? Departman { get; set; }

        public string? KarsilayanDepartman { get; set; }

        public int? arsivuser { get; set; }

        public DateTime? arsivtime { get; set; }

        public string? arsivuseradi { get; set; }

        public string Durum { get; set; } = null!;
    }

}
