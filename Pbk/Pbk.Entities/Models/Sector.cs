using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Models
{
    public class Sector
    {
        [Key]
        public int SectorId { get; set; }
        public string SectorName { get; set; } = null!;
        public string Code { get; set; } = null!;
        public int InsUser { get; set; }
        public DateTime? InsTime { get; set; }
    }
}
