using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Dto.Shipment
{
    public class ShipmentSpDto
    {
        public int? ShipmentId { get; set; }
        public string? DepartmentName { get; set; }
        public int? DepartmentId { get; set; }
        public string? PlanningDepartmentName { get; set; }
        public int? PlanningDepartmentId { get; set; }
        public string? Status { get; set; }
        public string? ShipmentTypeName { get; set; }
        public int? ShipmentTypeId { get; set; }
        public int? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? SectorName { get; set; }
        public int? SectorId { get; set; }
        public string? SenderName { get; set; }
        public int? SenderId { get; set; }
        public string? ReceiverName { get; set; }
        public int? ReceiverId { get; set; }
        public DateTime? LoadingTime { get; set; }
        public DateTime? UnloadingTime { get; set; }
        public int? BarsisAnaYukNo { get; set; }
        public int? BarsisYukNo { get; set; }
        public DateTime? InsTime { get; set; }
        public string? InsertUser { get; set; }
        public decimal? Freight { get; set; }
        public decimal? AdditionalFreight { get; set; }
        public int? CurrencyId { get; set; }
        public string? CurrencyCode { get; set; }
        public decimal? VATRate { get; set; }
        public string? FreightPaymentType { get; set; }
        public string? VTLReferenceNo { get; set; }
        public string? LoadingDescription { get; set; }
        public string? UnloadingDescription { get; set; }
        public string? Unit { get; set; }
        public string? IntegrationFileName { get; set; }
        public decimal? Expense { get; set; }
        public decimal? Revenue { get; set; }
        public string? Document { get; set; }
        public string? PalletCompany { get; set; }
        public int? PalletsAtLoad { get; set; }
        public int? PalletsAtUnload { get; set; }
        public string? LoadingPalletExchangeType { get; set; }
        public string? UnloadingPalletExchangeType { get; set; }
        public int? Pieces { get; set; }
        public decimal? Width { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Length { get; set; }
        public decimal? Height { get; set; }
        public decimal? LDM { get; set; }
        public decimal? Volume { get; set; }
        public string? IncoTerm { get; set; }
    }
}
