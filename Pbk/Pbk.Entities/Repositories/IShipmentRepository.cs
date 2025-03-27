using Pbk.Entities.Dto.Shipment;
using Pbk.Entities.Dto.Stage;
using Pbk.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Repositories
{
    public interface IShipmentRepository : IRepository<Shipment>
    {
        public List<ShipmentSpDto> GetShipment(DateTime? StartDate, DateTime? EndDate, int? SelectedDepartmentId, int RoleId, int UserId, bool ShowCompleted, int planning, bool isVTL);
        
    }
}
