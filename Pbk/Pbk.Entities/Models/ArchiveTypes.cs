using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Models
{
    public class ArchiveTypes
    {
        [Key]
        public int ArchiveTypeId { get; set; }
        public string ArchiveType { get; set; } = null!;
        public bool? IsPassive { get; set; }
        public int InsUser { get; set; }
        public DateTime? InsTime { get; set; }
    }
}
