using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pbk.Entities.Models;

public partial class Invoice
{
    [Key]
    public int InvoiceId { get; set; }
    public int CustomerId { get; set; }
    public int? SenderId { get; set; }
    public int? ReceiverId { get; set; }
    public int? TruckId { get; set; }
    public int? TrailerId { get; set; }
    public int DepartmentId { get; set; }
    public string? InvoiceNo { get; set; }
    public DateTime? InvoiceDate { get; set; }
    public string? IntegrationNo { get; set; }
    public decimal Amount { get; set; }
    public int CurrencyId { get; set; }
    public decimal? VATAmount { get; set; }
    public DateTime? DueDate { get; set; }
    public string? Description { get; set; }
    public int Year { get; set; }
    public int InsUser { get; set; }
    public DateTime InsTime { get; set; }
    public int? UpdUser { get; set; }
    public DateTime? UpdTime { get; set; }
    public int? BarsisInvoiceId { get; set; }
    public bool IsPassive { get; set; }
    public int SectorId { get; set; }
    public string? CustomerReference { get; set; }
    public string? BGLReference { get; set; }


    //public virtual Customer Customer { get; set; } = null!;

    //public virtual Department DepartmentNavigation { get; set; } = null!;

    //public virtual ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();

    //public virtual EndPoint? Receiver { get; set; }

    //public virtual EndPoint? Sender { get; set; }
}
