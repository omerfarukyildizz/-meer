using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Dto.InvoiceItem
{
    public class InvoiceItemSpDto
    {
        public int? InvoiceItemId { get; set; }
        public string? InvoiceNo { get; set; }
        public string? CustomerName { get; set; }
        public int? CustomerId { get; set; }
        public string? DepartmentCode { get; set; }
        public string? DepartmentName { get; set; }
        public int? DepartmentId { get; set; }
        public int? ShipmentId { get; set; }
        public int? StageId { get; set; }
        public int? VoyageId { get; set; }
        public string? RevenueCodeName { get; set; }
        public int? RevenueCodeId { get; set; }
        public string? SectorName { get; set; }
        public int? SectorId { get; set; }
        public decimal? Amount { get; set; }
        public string? CurrencyCode { get; set; }
        public int? CurrencyId { get; set; }
        public decimal? VATRate { get; set; }
        public int? BarsisInvoiceItemId { get; set; }
        public string? Document { get; set; }
        public string? Description { get; set; }
        public string? InsertUser { get; set; }
        public DateTime? InsTime { get; set; }
    }
}
