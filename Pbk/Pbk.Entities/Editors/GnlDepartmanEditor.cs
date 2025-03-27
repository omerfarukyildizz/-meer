using Pbk.Entities.Abstractions;
using Pbk.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pbk.Entities.Editors
{
    [Keyless]
    public class GnlDepartmanEditor
    {
        public int Sirket { get; set; }
        public string Kodu { get; set; } = null!;
        public string Adi { get; set; } = null!;
    }
}
