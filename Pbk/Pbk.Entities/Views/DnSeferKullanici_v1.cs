using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Views
{
    [Keyless]
    public class DnSeferKullanici_v1
    {
        public int? insuser { get; set; }
        public string? adi { get; set; }
        public string? departman { get; set; }
    }
}
