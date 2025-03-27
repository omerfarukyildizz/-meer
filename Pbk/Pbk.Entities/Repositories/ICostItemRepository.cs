using Pbk.Entities.Dto.CostItem;
using Pbk.Entities.Dto.InvoiceItem;
using Pbk.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Repositories
{
    public interface ICostItemRepository : IRepository<CostItem>
    {
        public List<CostItemByParamSpDto> GetCostItemByParam(int? shipmentId, int? stageId, int? voyageId);
        public List<CostItemListSpDto> GetCostItemList(DateTime? StartDate, DateTime? EndDate, int? SelectedDepartmentId, int RoleId, int UserId, bool ShowIntegrated);

        public List<YdNakMasrafHesapPlani> GetVendor(string? search);


    }
}
