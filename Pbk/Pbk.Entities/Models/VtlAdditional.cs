using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pbk.Entities.Models;

public partial class VtlAdditional
{
    [Key]
    public int ShipmentId { get; set; }

    public int? CreatingNo { get; set; }

    public int? CreatingDetailNo { get; set; }

    public string? PaletType { get; set; }

    public string? PlantCode { get; set; }

    public string? Lkw { get; set; }

    public bool? Adr { get; set; }

    public bool? FreePalet { get; set; }

    public string? CallBeforeLoading { get; set; }

    public string? CallBeforeLoadingDay { get; set; }

    public string? CallBeforeUnloading { get; set; }

    public string? CallDriver { get; set; }

    public string? DeliveryDelayReport { get; set; }

    public string? PaymentType { get; set; }

    public string? Week { get; set; }

    public string? IncoTerms { get; set; }

    public string? PaletReference { get; set; }

    public string? CustomInfo { get; set; }

    public string? CustomDocNo { get; set; }

    public string? WaybillNumber { get; set; }

    public string? CustomerOrderNumber { get; set; }

    public string? EkaerNo { get; set; }

    public string? ShipmentWarehouseCode { get; set; }

    public DateOnly? OrderDate { get; set; }

    public double? NetWeight { get; set; }

    public double? EPTotal { get; set; }

    public double? GPTotal { get; set; }

    public string? OldStatus { get; set; }

    public string? NewStatus { get; set; }

    public string? StatusInfo { get; set; }

    public bool? CadisBildirildi { get; set; }

    public DateTime? CadisBildirilmeZamani { get; set; }

    public bool Flammable { get; set; }

    public bool Frangible { get; set; }

    public bool CustomerSign { get; set; }

    public bool Unstackable { get; set; }

    public bool OnlyHorizontal { get; set; }

    public bool OnlyVertical { get; set; }

    public bool WaybillInLoad { get; set; }

    public bool Routed { get; set; }

    public bool Customs { get; set; }

    public bool LoadWithT1 { get; set; }

    public bool ConfirmationRequired { get; set; }

    public int? ConfirmationUserId { get; set; }

    public bool CustomerInfo { get; set; }

    public bool Waybill { get; set; }

    public bool LoadNotification { get; set; }

    public bool CustomsInfo { get; set; }

    public string? LicencePlate { get; set; }

    public int? CargoGroup { get; set; }

    public int? UnloadingArray { get; set; }

    public bool? SendToBGL { get; set; }

    public string? PlateNumber { get; set; }

    public int? CreatingLoadNo { get; set; }

    public string? OrderingDepot { get; set; }

    public string? OrderService { get; set; }

    public double? CashOnDelivery { get; set; }

    public int? CashOnDeliveryCurrencyId { get; set; }

    public string? CashOnDeliveryPayment { get; set; }

    public double? OtherDelivery { get; set; }

    public int? OtherDeliveryCurrencyId { get; set; }

    public string? OtherDeliveryPayment { get; set; }
}
