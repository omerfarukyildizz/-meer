using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Models
{
    public class VehicleType
    {
        [Key]
        public int VehicleTypeId { get; set; }

        public string VehicleTypeName { get; set; } = null!;
        public string? Description { get; set; }
        public int InsUser { get; set; }
        public DateTime? InsTime { get; set; }
    }
}
