using System;
using System.Collections.Generic;

namespace Pbk.Entities.Models2;

public partial class Invoice
{
    public int InvoiceId { get; set; }

    public int InvoiceItemId { get; set; }

    public int CustomerId { get; set; }

    public int? SenderId { get; set; }

    public int? ReceiverId { get; set; }

    public string Department { get; set; } = null!;

    public string? InvoiceNo { get; set; }

    public DateTime? InvoiceDate { get; set; }

    public string? IntegrationNo { get; set; }

    public int Amount { get; set; }

    public int CurrencyId { get; set; }

    public decimal? VATRate { get; set; }

    public DateTime? DueDate { get; set; }

    public string? Description { get; set; }

    public int Year { get; set; }

    public int InsUser { get; set; }

    public DateTime InsTime { get; set; }

    public int? UpdUser { get; set; }

    public DateTime? UpdTime { get; set; }

    public virtual Currency Currency { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual Department DepartmentNavigation { get; set; } = null!;

    public virtual ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();

    public virtual EndPoint? Receiver { get; set; }

    public virtual EndPoint? Sender { get; set; }
}
