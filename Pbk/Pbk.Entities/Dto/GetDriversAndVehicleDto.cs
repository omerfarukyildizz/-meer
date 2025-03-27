using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Dto
{
    public class GetDriversAndVehicleDto
    {
        public int? DriverId { get; set; }

        public int? VehicleId { get; set; }

        public int? VehicleTypeId { get; set; }
        public string? VehicleTypeName { get; set; } = null!;

        public string? Plate { get; set; } = null!;
        public string? DriverName { get; set; } = null!;

        public int? DepartmentId { get; set; }
        public string? DepartmentName { get; set; } = null!;

        public string? EdiCode { get; set; }

        public string? IntegratedAccountCode { get; set; } = null!;

        public bool? IsPassive { get; set; }
        public int? InsUser { get; set; }

        public DateTime? InsTime { get; set; }

        public int? UpdUser { get; set; }

        public DateTime? UpdTime { get; set; }

    }
}
