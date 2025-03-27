using Pbk.Entities.Dto.Voyage;
using Pbk.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Repositories
{
    public interface IVoyageRepository : IRepository<Voyage>
    {
        public List<VoyageSpDto> GetVoyage(DateTime? StartDate, DateTime? EndDate, int? SelectedDepartmentId, int RoleId, int UserId, bool ShowCompleted);
        public List<VoyagePlanningOverviewSpDto> GetPlanningOverview(int? SelectedDepartmentId, int RoleId, int UserId);
    }
}
