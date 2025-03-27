using System;
using System.Collections.Generic;

namespace Pbk.Entities.Models2;

public partial class Currency
{
    public int CurrencyId { get; set; }

    public string CurrencyCode { get; set; } = null!;

    public string? Description { get; set; }

    public int InsUser { get; set; }

    public DateTime? InsTime { get; set; }

    public virtual ICollection<CostItem> CostItems { get; set; } = new List<CostItem>();

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

    public virtual ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();
}
