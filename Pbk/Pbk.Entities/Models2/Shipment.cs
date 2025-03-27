using Pbk.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pbk.Entities.Models2;

public partial class Shipment
{
    [Key]
    public int ShipmentId { get; set; }

    public int? IntegrationId { get; set; }

    public int DepartmentId { get; set; }

    public int StatusTypeId { get; set; }

    public int? DocumentId { get; set; }

    public int ShipmentTypeId { get; set; }

    public string? LoadingDescription { get; set; }

    public int? CustomerId { get; set; }

    public int SectorId { get; set; }

    public int Year { get; set; }

    public int SenderId { get; set; }

    public int ReceiverId { get; set; }

    public DateTime LoadingTime { get; set; }

    public DateTime UnloadingTime { get; set; }

    public int? BarsisAnaYukNo { get; set; }

    public int? BarsisYukNo { get; set; }

    public DateTime InsTime { get; set; }

    public int InsUser { get; set; }

    public int? UpdUser { get; set; }

    public DateTime? UpdTime { get; set; }

    public decimal? Freight { get; set; }

    public decimal? AdditionalFreight { get; set; }

    public int CurrencyId { get; set; }

    public decimal VATRate { get; set; }

    public string? FreightPaymentType { get; set; }

    public string? ReferenceNo { get; set; }

    public int? UnitId { get; set; }

    public int? LoadingPalletExchange { get; set; }

    public int? UnloadingPalletExchange { get; set; }

    public int? PalletsAtLoad { get; set; }

    public int? PalletsAtUnload { get; set; }

    public int? PalletCompanyId { get; set; }

    public int? Pieces { get; set; }

    public decimal? Width { get; set; }

    public decimal? Weight { get; set; }

    public decimal? Length { get; set; }

    public decimal? Height { get; set; }

    public decimal? LDM { get; set; }

    public decimal? Volume { get; set; }

    public string? WarehouseCode { get; set; }

    public string? SenderWarehouseCode { get; set; }

    public string? ReceiverWarehouseCode { get; set; }

    public string? WarehouseHub { get; set; }

    public string? ReferenceShip { get; set; }

    public string? Art { get; set; }

    public string? OrderType { get; set; }

    public string? DeliveryType { get; set; }

    public DateTime? DeliveryDate { get; set; }

    public DateTime? DeliveryTimeBegin { get; set; }

    public DateTime? DeliveryTimeEnd { get; set; }

    public string? ReferenceNoc { get; set; }

    public string? UnloadingType { get; set; }

    public DateTime? UnloadingDate { get; set; }

    public DateTime? UnloadingTimeBegin { get; set; }

    public DateTime? UnloadingTimeEnd { get; set; }

    public string? ValueOfGoods { get; set; }

    public string? CustomerReference { get; set; }

    public string? PublicText { get; set; }

    public string? InternalText { get; set; }

    public bool? VTLBildirildi { get; set; }

    public DateTime? VTLBildirilmeZamani { get; set; }

    public string? ConsignmentNumber { get; set; }

    public DateTime? ConfirmationTime { get; set; }

    public string? Type { get; set; }

    public bool? VTLBildirilecek { get; set; }

    public string? LoadWithT1Text { get; set; }

    public string? CustomerInfoText { get; set; }

    public string? WaybillNumText { get; set; }

    public string? LoadNotificationText { get; set; }

    public string? CustomsInfoText { get; set; }

    public string? IncotermNew { get; set; }

    public bool IsPassive { get; set; }

    public int? IncoTermId { get; set; }

    public string? IntegrationFileName { get; set; }

    public int? PlanningDepartmentId { get; set; }

    public string? UnloadingDescription { get; set; }
    //public virtual ICollection<CostItem> CostItems { get; set; } = new List<CostItem>();

    public virtual Customer Customer { get; set; } = null!;

    public virtual Department Department{ get; set; } = null!;

    //public virtual Document? Document { get; set; }

    //public virtual ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();

    //public virtual EndPoint EndPoint { get; set; } = null!;
    public virtual Currency Currency { get; set; } = null!;
    public virtual StatusType StatusType { get; set; } = null!;
    public virtual ShipmentType ShipmentType { get; set; } = null!;
  

    //public virtual ICollection<Stage> Stages { get; set; } = new List<Stage>();

    //public virtual ICollection<VtlPackage> VtlPackages { get; set; } = new List<VtlPackage>();

    //public virtual ICollection<VtlStatu> VtlStatus { get; set; } = new List<VtlStatu>();
}
