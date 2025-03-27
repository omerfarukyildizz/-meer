using System;
using System.Collections.Generic;

namespace Pbk.Entities.Models2;

public partial class CostItem
{
    public int CostItemId { get; set; }

    public int ShipmentId { get; set; }

    public int StageId { get; set; }

    public int VoyageId { get; set; }

    public string Department { get; set; } = null!;

    public int? CarrierId { get; set; }

    public string? CostCode { get; set; }

    public string? Sector { get; set; }

    public int Amount { get; set; }

    public int CurrencyId { get; set; }

    public decimal? VATRate { get; set; }

    public int? PaymentTerms { get; set; }

    public string? IntegrationNo { get; set; }

    public string? InvoiceNo { get; set; }

    public DateTime? InvoiceDate { get; set; }

    public string? SAPDocumentNo { get; set; }

    public string? Description { get; set; }

    public int Year { get; set; }

    public int InsUser { get; set; }

    public DateTime InsTime { get; set; }

    public int? UpdUser { get; set; }

    public DateTime? UpdTime { get; set; }

    public virtual Carrier? Carrier { get; set; }

    public virtual Currency Currency { get; set; } = null!;

    public virtual Department DepartmentNavigation { get; set; } = null!;

    public virtual Shipment Shipment { get; set; } = null!;

    public virtual Stage Stage { get; set; } = null!;

    public virtual Voyage Voyage { get; set; } = null!;
}
