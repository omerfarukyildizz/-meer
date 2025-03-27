using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Dto
{
    public class GetVehicleDto
    {
        public int VehicleId { get; set; }

        public string VehicleTypeName { get; set; } = null!;

        public string Plate { get; set; } = null!;
        
    }
}
