using Pbk.Entities.Dto.InvoiceItem;
using Pbk.Entities.Dto.Stage;
using Pbk.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Repositories
{
    public interface IInvoiceItemRepository : IRepository<InvoiceItem>
    {
        public List<InvoiceItemSpDto> GetInvoiceItem(DateTime? StartDate, DateTime? EndDate, int? SelectedDepartmentId, int RoleId, int UserId, bool ShowInvoiced);
        public List<InvoiceItemByParamSpDto> GetInvoiceItemByParam(int? shipmentId, int? stageId, int? voyageId);
        public List<InvoiceItemDetailsSpDto> GetInvoiceItemDetails(int customerId);

    }
}
