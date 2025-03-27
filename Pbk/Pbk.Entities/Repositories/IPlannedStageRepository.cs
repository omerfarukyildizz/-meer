using Pbk.Entities.Dto.Stage;
using Pbk.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Repositories
{
    public interface IPlannedStageRepository : IRepository<PlannedStage>
    {
        public string GetCheckStagePlanningByVehicleId(int stageId,int vehicleId);
        public string GetCheckStagePlanningByCarrierId(int stageId,int carrierId);

    }
}
