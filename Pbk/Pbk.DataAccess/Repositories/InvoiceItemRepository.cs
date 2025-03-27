using Pbk.DataAccess.Context;
using Pbk.Entities.Dto.InvoiceItem;
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
    internal sealed class InvoiceItemRepository : Repository<InvoiceItem>, IInvoiceItemRepository
    {

        ApplicationDbContext _context;
        public InvoiceItemRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public List<InvoiceItemSpDto> GetInvoiceItem(DateTime? StartDate, DateTime? EndDate, int? SelectedDepartmentId, int RoleId, int UserId, bool ShowInvoiced)
        {
            try
            {
                var invoiceItems = _context.Set<InvoiceItemSpDto>()
                .FromSqlRaw("EXEC sp_GetInvoiceItemsList @StartDate = {0}, @EndDate = {1}, @SelectedDepartmentId = {2}, @RoleId = {3}, @UserId = {4}, @ShowInvoiced = {5}",
                 StartDate ?? (object)DBNull.Value,
                 EndDate ?? (object)DBNull.Value,
                 SelectedDepartmentId ?? 0,
                 RoleId,
                 UserId,
                 ShowInvoiced)
                 .ToList();



                return invoiceItems;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<InvoiceItemByParamSpDto> GetInvoiceItemByParam(int? shipmentId, int? stageId, int? voyageId)
        {
            try
            {
                var invoiceItemsByParam = _context.Set<InvoiceItemByParamSpDto>()
                .FromSqlRaw("EXEC sp_GetInvoiceItemsByParam @ShipmentId = {0}, @StageId = {1}, @VoyageId = {2}",
                 shipmentId ,
                 stageId ,
                 voyageId )
                 .ToList();



                return invoiceItemsByParam;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public List<InvoiceItemDetailsSpDto> GetInvoiceItemDetails(int customerId)
        {
            try
            {
                var invoiceItemDetails = _context.Set<InvoiceItemDetailsSpDto>()
                .FromSqlRaw("EXEC sp_GetInvoiceItemDetails @CustomerId = {0}",
                 customerId)
                 .ToList();

                return invoiceItemDetails;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
