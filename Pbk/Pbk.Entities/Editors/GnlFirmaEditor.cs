using Pbk.Entities.Abstractions;
using Pbk.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pbk.Entities.Editors
{
    [Keyless]
    public class GnlFirmaEditor
    {
        public string Departman { get; set; } = null!;
        public int Kodu { get; set; }
        public string? Adi { get; set; }

        //public GnlFirma GnlFirma { get; set; }
    }
}
