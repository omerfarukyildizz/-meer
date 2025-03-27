using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Dto.CostItem
{
    public class CostItemListSpDto
    {
        public int? CostItemId { get; set; }
        public int? ShipmentId { get; set; }
        public int? StageId { get; set; }
        public int? VoyageId { get; set; }
        public int? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public string? Vendor { get; set; }
        public string? VendorName { get; set; }
        public int? ExpenseCodeId { get; set; }
        public string? ExpenseCodeName { get; set; }
        public int? SectorId { get; set; }
        public string? SectorName { get; set; }
        public decimal? Amount { get; set; }
        public int? CurrencyId { get; set; }
        public string? CurrencyCode { get; set; }
        public int? BarsisCostId { get; set; }
        public decimal? VATRate { get; set; }
        public int? PaymentTerms { get; set; }
        public string? IntegrationNo { get; set; }
        public string? InvoiceNo { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string? SAPDocumentNo { get; set; }
        public string? Document { get; set; }
        public string? Description { get; set; }
        public string? InsertUser { get; set; }
        public DateTime? InsTime { get; set; }
    }
}
