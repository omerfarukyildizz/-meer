using Pbk.DataAccess.Context;
using Pbk.Entities.Dto.Voyage;
using Pbk.Entities.Models;
using Pbk.Entities.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.DataAccess.Repositories
{
    internal sealed class VoyageRepository : Repository<Voyage>, IVoyageRepository
    {
        ApplicationDbContext _context;
        public VoyageRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public List<VoyageSpDto> GetVoyage(DateTime? StartDate,DateTime? EndDate, int? SelectedDepartmentId,int RoleId,int UserId, bool ShowCompleted)
        {
            try
            {
                var voyages = _context.Set<VoyageSpDto>()
     .FromSqlRaw("EXEC sp_GetVoyageList @StartDate = {0}, @EndDate = {1}, @SelectedDepartmentId = {2}, @RoleId = {3}, @UserId = {4}, @ShowCompleted = {5}",
                 StartDate ?? (object)DBNull.Value,
                 EndDate ?? (object)DBNull.Value,
                 SelectedDepartmentId ?? 0,
                 RoleId,
                 UserId,
                 ShowCompleted)
     .ToList();



                return voyages;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<VoyagePlanningOverviewSpDto> GetPlanningOverview(int? SelectedDepartmentId, int RoleId, int UserId)
        {
            try
            {
                var PlanningOverviews = _context.Set<VoyagePlanningOverviewSpDto>()
               .FromSqlRaw("EXEC sp_GetPlanningOverview @RoleId = {0}, @SelectedDepartmentId = {1}, @UserId = {2}",
                   RoleId,
                   SelectedDepartmentId,
                   UserId
               )
               .ToList();

                return PlanningOverviews;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
