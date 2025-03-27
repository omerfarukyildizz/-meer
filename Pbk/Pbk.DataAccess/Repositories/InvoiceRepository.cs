using Pbk.DataAccess.Context;
using Pbk.Entities.Dto.Invoice;
using Pbk.Entities.Dto.InvoiceItem;
using Pbk.Entities.Dto.Voyage;
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
    internal sealed class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        ApplicationDbContext _context;
        public InvoiceRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public List<InvoiceSpDto> GetInvoice(DateTime? StartDate, DateTime? EndDate, int? SelectedDepartmentId, int RoleId, int UserId)
        {
            try
            {
                var invoices = _context.Set<InvoiceSpDto>()
                .FromSqlRaw("EXEC sp_GetInvoiceList @StartDate = {0}, @EndDate = {1}, @SelectedDepartmentId = {2}, @RoleId = {3}, @UserId = {4}",
                 StartDate ?? (object)DBNull.Value,
                 EndDate ?? (object)DBNull.Value,
                 SelectedDepartmentId ?? 0,
                 RoleId,
                 UserId)
     .ToList();



                return invoices;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
