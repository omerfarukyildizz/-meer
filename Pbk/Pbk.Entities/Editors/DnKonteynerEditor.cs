using Pbk.Entities.Abstractions;
using Pbk.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pbk.Entities.Editors
{
    [Keyless]
    public class DnKonteynerEditor
    {
        public string? konteynertipi { get; set; }
        public string konteynerno { get; set; } = null!;
        public int? adet { get; set; }
        public string? birim { get; set; }
        public double? brutkg { get; set; }
        public double? m3 { get; set; }
    }
}
