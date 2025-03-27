using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pbk.Entities.Models;

public partial class InvoiceItem
{
    [Key]
    public int InvoiceItemId { get; set; }
    public int? InvoiceId { get; set; }
    public int CustomerId { get; set; }
    public int? ShipmentId { get; set; }
    public int? StageId { get; set; }
    public int? VoyageId { get; set; }
    public int DepartmentId { get; set; }
    public int RevenueCodeId { get; set; }
    public int SectorId { get; set; }
    public decimal Amount { get; set; }
    public int CurrencyId { get; set; }
    public decimal? VATRate { get; set; }
    public string? Description { get; set; }
    public int Year { get; set; }
    public int InsUser { get; set; }
    public DateTime InsTime { get; set; }
    public int? UpdUser { get; set; }
    public DateTime? UpdTime { get; set; }
    public int? BarsisInvoiceItemId { get; set; }
    public bool IsPassive { get; set; }

    //public virtual Customer Customer { get; set; } = null!;

    //public virtual Department DepartmentNavigation { get; set; } = null!;

    //public virtual Invoice? Invoice { get; set; }

    //public virtual Shipment Shipment { get; set; } = null!;

    //public virtual Stage Stage { get; set; } = null!;

    //public virtual Voyage Voyage { get; set; } = null!;
}
