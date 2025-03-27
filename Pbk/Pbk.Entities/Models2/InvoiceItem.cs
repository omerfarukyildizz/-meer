using System;
using System.Collections.Generic;

namespace Pbk.Entities.Models2;

public partial class InvoiceItem
{
    public int InvoiceItemId { get; set; }

    public int? InvoiceId { get; set; }

    public int CustomerId { get; set; }

    public int ShipmentId { get; set; }

    public int StageId { get; set; }

    public int VoyageId { get; set; }

    public string Department { get; set; } = null!;

    public string? Revenue { get; set; }

    public string? Sector { get; set; }

    public int Amount { get; set; }

    public int CurrencyId { get; set; }

    public decimal? VATRate { get; set; }

    public string? Description { get; set; }

    public int Year { get; set; }

    public int InsUser { get; set; }

    public DateTime InsTime { get; set; }

    public int? UpdUser { get; set; }

    public DateTime? UpdTime { get; set; }

    public virtual Currency Currency { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual Department DepartmentNavigation { get; set; } = null!;

    public virtual Invoice? Invoice { get; set; }

    public virtual Shipment Shipment { get; set; } = null!;

    public virtual Stage Stage { get; set; } = null!;

    public virtual Voyage Voyage { get; set; } = null!;
}
