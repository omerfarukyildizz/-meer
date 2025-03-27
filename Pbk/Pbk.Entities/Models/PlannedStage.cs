using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Models
{
    public class PlannedStage
    {
        [Key]
        public int PlannedStageId { get; set; }
        public int? VehicleId { get; set; }  
        public int StageId { get; set; }
        public DateTime InsTime { get; set; } = DateTime.Now;
        public int InsUser { get; set; }
        public int? CarrierId { get; set; }
        public bool IsPassive { get; set; } = false;
        public int? PlanningSequence { get; set; }
    }
}
