using Pbk.Entities.Abstractions;
using Pbk.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pbk.Entities.Editors
{
    [Keyless]
    public class GnlYukEditor
    {
        public int yukno { get; set; }
        public int sirket { get; set; }
        public int yil { get; set; }
    }
}
