using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pbk.Entities.Models;

public partial class CostItem
{
    [Key]
    public int CostItemId { get; set; }
    public int? ShipmentId { get; set; }
    public int? StageId { get; set; }
    public int? VoyageId { get; set; }
    public int DepartmentId { get; set; }
    public string? Vendor { get; set; }  
    public int ExpenseCodeId { get; set; }
    public int SectorId { get; set; }
    public decimal Amount { get; set; }
    public int CurrencyId { get; set; }
    public decimal? VATRate { get; set; }
    public int? PaymentTerms { get; set; }
    public string? IntegrationNo { get; set; }
    public string InvoiceNo { get; set; } = null!;
    public DateTime? InvoiceDate { get; set; }
    public string? SAPDocumentNo { get; set; }
    public string? Description { get; set; }
    public int Year { get; set; }
    public int InsUser { get; set; }
    public DateTime InsTime { get; set; }
    public int? UpdUser { get; set; }
    public DateTime? UpdTime { get; set; }
    public int? BarsisCostId { get; set; }
    public bool IsPassive { get; set; }


    /* public virtual Carrier? Carrier { get; set; }

     public virtual Department DepartmentNavigation { get; set; } = null!;

     public virtual Shipment Shipment { get; set; } = null!;

     public virtual Stage Stage { get; set; } = null!;

     public virtual Voyage Voyage { get; set; } = null!;*/
}
