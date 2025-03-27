using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Dto.Shipment
{
    public class ShipmentDto
    {
        public int ShipmentId { get; set; }
        public int? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public string? DepartmentCode { get; set; }
        public int? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public int? SenderId { get; set; }
        public string? SenderName { get; set; }
        public int? ReceiverId { get; set; }
        public string? ReceiverName { get; set; }
        public DateTime? LoadingTime { get; set; }
        public DateTime? UnloadingTime { get; set; }
        public int? StatusTypeId { get; set; }
        public string? StatusName { get; set; }
        public int? ShipmentTypeId { get; set; }
        public string? ShipmentTypeName { get; set; }
        public decimal? Freight { get; set; }
        public int? CurrencyId { get; set; }
        public string? CurrencyCode { get; set; }
        public string? LoadingDescription { get; set; }
        public string? UnloadingDescription { get; set; }
        public string? FreightPaymentType { get; set; }
        public int? PlanningDepartmentId { get; set; }
        public string? PlanningDepartmentName { get; set; }
        public string? IntegrationFileName { get; set; }
        public int? SectorId { get; set; }
        public string? SectorName { get; set; }
        public int? IncoTermId { get; set; }
        public string? IncoTermCode { get; set; }
        public decimal? AdditionalFreight { get; set; }
        public decimal? VatRate { get; set; }
        public int? Pieces { get; set; }
        public int? UnitId { get; set; }
        public string? UnitName { get; set; }
        public decimal? Length { get; set; }
        public decimal? Height { get; set; }
        public decimal? Width { get; set; }
        public decimal? Weight { get; set; }
        public decimal? LDM { get; set; }
        public int? PalletCompanyId { get; set; }
        public string? PalletCompanyName { get; set; }
        public int? LoadingPalletExchange { get; set; }
        public int? UnloadingPalletExchange { get; set; }
        public int? PalletsAtLoad { get; set; }
        public int? PalletsAtUnload { get; set; }
        public string? ReferenceNo { get; set; }
    }

}
