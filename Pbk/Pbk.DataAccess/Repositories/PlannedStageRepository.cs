using Pbk.DataAccess.Context;
using Pbk.Entities.Dto.Stage;
using Pbk.Entities.Models;
using Pbk.Entities.Models2;
using Pbk.Entities.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.DataAccess.Repositories
{
    internal sealed class PlannedStageRepository : Repository<PlannedStage>, IPlannedStageRepository
    {
        ApplicationDbContext _context;

        public PlannedStageRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public string GetCheckStagePlanningByVehicleId(int stageId, int vehicleId)
        {
            try
            {
                var check = _context.Database.SqlQueryRaw<string>(
      "DECLARE @ResultMessage NVARCHAR(255); EXEC sp_CheckStagePlanningOwned @StageId = @p0, @VehicleId = @p1, @ResultMessage = @ResultMessage OUTPUT; SELECT @ResultMessage;",
      stageId,
      vehicleId
  ).AsEnumerable().FirstOrDefault();



                return check;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string GetCheckStagePlanningByCarrierId(int stageId, int carrierId)
        {
            try
            {
                var check = _context.Database.SqlQueryRaw<string>(
      "DECLARE @ResultMessage NVARCHAR(255); EXEC sp_CheckStagePlanningRented @StageId = @p0, @CarrierId = @p1, @ResultMessage = @ResultMessage OUTPUT; SELECT @ResultMessage;",
      stageId,
      carrierId
  ).AsEnumerable().FirstOrDefault();

                return check;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
