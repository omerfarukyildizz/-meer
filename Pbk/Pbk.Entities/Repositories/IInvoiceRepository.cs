using Pbk.Entities.Dto.Invoice;
using Pbk.Entities.Dto.Voyage;
using Pbk.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Repositories
{
    public interface IInvoiceRepository : IRepository<Invoice>
    {
        public List<InvoiceSpDto> GetInvoice(DateTime? StartDate, DateTime? EndDate, int? SelectedDepartmentId, int RoleId, int UserId);
    }
}
