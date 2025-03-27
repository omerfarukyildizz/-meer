using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Dto.Invoice
{
    public class InvoiceSpDto
    {
        public int? InvoiceId { get; set; }
        public string? InvoiceNo { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public int? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? DepartmentCode { get; set; }
        public int? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public string? SenderName { get; set; }
        public int? SenderId { get; set; }
        public int? ReceiverId { get; set; }
        public string? ReceiverName { get; set; }
        public string? BGLFinanceTransactionNo { get; set; }
        public decimal? Amount { get; set; }
        public string? CurrencyCode { get; set; }
        public int? CurrencyId { get; set; }
        public string? SectorName { get; set; }
        public int? SectorId { get; set; }
        public decimal? VATAmount { get; set; }
        public decimal? TotalAmount { get; set; }
        public DateTime? DueDate { get; set; }
        public string? Description { get; set; }
        public int? BarsisInvoiceNo { get; set; }
        public string? CustomerReference { get; set; }
        public string? BGLReference { get; set; }
        public string? TruckPlate { get; set; }
        public int? TruckId { get; set; }
        public int? TrailerId { get; set; }
        public string? TrailerPlate { get; set; }
        public string? Document { get; set; }
        public string? InsertUser { get; set; }
        public DateTime? InsTime { get; set; }
    }
}
