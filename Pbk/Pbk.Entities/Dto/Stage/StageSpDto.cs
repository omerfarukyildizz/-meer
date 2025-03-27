using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Dto.Stage
{
    public class StageSpDto
    {
        public int? StageId { get; set; }
        public int? ShipmentId { get; set; }
        public int? VoyageId { get; set; }
        public int? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public int? PlanningDepartmentId { get; set; }
        public string? PlanningDepartmentName { get; set; }
        public int? StageNumber { get; set; }
        public DateTime? LoadingTime { get; set; }
        public DateTime? UnloadingTime { get; set; }
        public decimal? StageKM { get; set; }
        public int? VoyageSequence { get; set; }
        public string? StatusType { get; set; }
        public string? SourceLocationName { get; set; }
        public int? SourceLocationId { get; set; }
        public string? TargetLocationName { get; set; }
        public int? TargetLocationId { get; set; }
        public string? InsertUser { get; set; }
        public DateTime? InsertTime { get; set; }

    }

  

}

