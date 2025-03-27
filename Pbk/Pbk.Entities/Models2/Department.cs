using System;
using System.Collections.Generic;

namespace Pbk.Entities.Models2;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string Code { get; set; } = null!;

    public string DepartmentName { get; set; } = null!;

    public string? InvoiceCurrency { get; set; }

    public string? CommercialAccount { get; set; }

    public string? BlockedAccount { get; set; }

    public string? OverdraftAccount { get; set; }

    public string? Director { get; set; }

    public string? DirectorEmail { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public int? PlaceId { get; set; }

    public int? CountryId { get; set; }

    public string? PostalCode { get; set; }

    public string? SAPCompanyCode { get; set; }

    public bool? IsPassive { get; set; }

    public int? CurrencyId { get; set; }

    public int? YdInvoiceNo { get; set; }

    public string? YdInvoicePrefix { get; set; }

    public int? InsUser { get; set; }

    public DateTime InsTime { get; set; }

    public int? UpdUser { get; set; }

    public DateTime? UpdTime { get; set; }

    public string? Phone { get; set; }

    public virtual ICollection<Authority> Authorities { get; set; } = new List<Authority>();

    public virtual ICollection<Carrier> Carriers { get; set; } = new List<Carrier>();

    public virtual ICollection<CostItem> CostItems { get; set; } = new List<CostItem>();

    public virtual Country? Country { get; set; }

    public virtual Currency? Currency { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Driver> Drivers { get; set; } = new List<Driver>();

    public virtual ICollection<EndPoint> EndPoints { get; set; } = new List<EndPoint>();

    public virtual ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();

    public virtual ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
