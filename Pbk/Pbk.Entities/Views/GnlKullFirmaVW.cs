using Pbk.Entities.Abstractions;
using Pbk.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pbk.Entities.Views
{
    [Keyless]
    public class GnlKullFirmaVW
    {
        public int kullkodu { get; set; }
        public int? firma { get; set; }
        public bool? sorumlu { get; set; }
        public bool? fatkesim { get; set; }
        public string? srctype { get; set; }
    }
}
