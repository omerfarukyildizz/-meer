using Pbk.Entities.Dto.Stage;
using Pbk.Entities.Dto.Voyage;
using Pbk.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Repositories
{
    public interface IStageRepository : IRepository<Stage>
    {
        public List<StageSpDto> GetStage(DateTime? StartDate, DateTime? EndDate, int? SelectedDepartmentId, int RoleId, int UserId, bool ShowCompleted);
        public  Task<decimal> getKm(int StageId);
        public Task<decimal> getDynamicKM(int VehicleId);

    }
}
