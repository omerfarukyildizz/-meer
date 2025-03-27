using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Dto.InvoiceItem
{
    public class InvoiceItemDetailsSpDto
    {
        public int? InvoiceItemId { get; set; }
        public int? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public int? ShipmentId { get; set; }
        public int? StageId { get; set; }
        public int? VoyageId { get; set; }
        public int? RevenueCodeId { get; set; }
        public string? RevenueCodeName { get; set; }
        public decimal? Amount { get; set; }
        public decimal? VATRate { get; set; }
        public decimal? VATAmount { get; set; }
        public decimal? TotalAmount { get; set; }
        public string? Description { get; set; }
        public string? ReferenceNo { get; set; }
        public int? SenderId { get; set; }
        public int? ReceiverId { get; set; }
        public string? SenderPointName { get; set; }
        public string? SenderPostalCode { get; set; }
        public string? ReceiverPostalCode { get; set; }
        public string? ReceiverPointName { get; set; }
        public int? TruckId { get; set; }
        public string? TruckPlate { get; set; }
        public int? TrailerId { get; set; }
        public string? TrailerPlate { get; set; }


    }
}
