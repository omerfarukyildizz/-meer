using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Dto.Voyage
{
    public class VoyagePlanningOverviewSpDto
    {
        public string? Plate { get; set; }
        public int? VoyageId { get; set; }
        public int? TrailerId { get; set; }
        public string? VoyageStatus { get; set; }
        public DateTime? DepartureTime { get; set; }
        public DateTime? ArrivalTime { get; set; }
        public string? LoadingPostCode { get; set; }
        public string? UnloadingPostCode { get; set; }
        public decimal? DynamicEmptyKmCalculation { get; set; }
        public int? VehicleId { get; set; }
      
    }
}
