using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Views
{
    [Keyless]
    public partial class USAExportliste
    {
        public string? YDImex { get; set; }
        public int Yukno { get; set; }
        public string? USA_Fileno { get; set; }
        public int? Dosyaay { get; set; }
        public bool ydisibitmis { get; set; }
    }
}
