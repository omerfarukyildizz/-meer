using Pbk.DataAccess.Context;
using Pbk.Entities.Dto.Shipment;
using Pbk.Entities.Dto.Stage;
using Pbk.Entities.Models;
using Pbk.Entities.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.DataAccess.Repositories
{
    internal sealed class ShipmentRepository : Repository<Shipment>, IShipmentRepository
    {
        ApplicationDbContext _context;
        public ShipmentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public List<ShipmentSpDto> GetShipment(DateTime? StartDate, DateTime? EndDate, int? SelectedDepartmentId, int RoleId, int UserId, bool ShowCompleted, int planning, bool isVTL)
        {
            try
            {
                List<ShipmentSpDto> liste = new List<ShipmentSpDto>();

                if (isVTL)
                {

                    var filePat = planning == 2 ?  "'%_de%,%_da%'" : "'%_dv%,%_db%'";

                    liste = _context.Set<ShipmentSpDto>()
             .FromSqlRaw("EXEC sp_GetVTLList   @RoleId = {0}, @SelectedDepartmentId ={1}, @UserId = {2}, @ShowCompleted = {3}, @StartDate = {4}, @EndDate = {5}, @IntegrationFilePattern = "+ filePat,
              RoleId,
                SelectedDepartmentId,
                   UserId,
                      ShowCompleted,
             StartDate  ?? (object)DBNull.Value,
              EndDate ?? (object)DBNull.Value,
            planning)
              .ToList();

                }
                else
                {
                    liste = _context.Set<ShipmentSpDto>()
                                 .FromSqlRaw("EXEC sp_GetShipmentList @StartDate = {0}, @EndDate = {1}, @SelectedDepartmentId = {2}, @RoleId = {3}, @UserId = {4}, @ShowCompleted = {5}, @planning = {6}",
                                  StartDate ?? (object)DBNull.Value,
                                  EndDate ?? (object)DBNull.Value,
                                  SelectedDepartmentId,
                                  RoleId,
                                  UserId,
                                  ShowCompleted, planning)
                                  .ToList();

                }

             



                return liste;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
