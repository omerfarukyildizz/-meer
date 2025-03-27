using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Dto.CostItem
{
    public class CostItemByParamSpDto
    {
        public int? CostItemId { get; set; }
        public string? Vendor { get; set; }
        public string? ExpenseCodeName { get; set; }
        public int? ExpenseCodeId { get; set; }
        public string? SectorName { get; set; }
        public int? SectorId { get; set; }
        public decimal? Amount { get; set; }
        public string? CurrencyCode { get; set; }
        public int? CurrencyId { get; set; }
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
