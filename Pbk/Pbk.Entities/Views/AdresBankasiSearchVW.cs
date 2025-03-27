using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Views
{
    [Keyless]
    public class AdresBankasiSearchVW
    {
        public int Kodu { get; set; }

        public string? Adi { get; set; }

        public string? il { get; set; }

        public string? Ulke { get; set; }

        public string? Telefon { get; set; }

        public string? ilgili { get; set; }

        public string Adres { get; set; } = null!;
    }
     
}
