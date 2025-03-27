 
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pbk.Entities.Models;

public partial class Customer
{
    [Key] 
    public int CustomerId { get; set; }

    public int DepartmentId { get; set; }

    public string CustomerName { get; set; } = null!;

    public string Adress { get; set; } = null!;

    public string? AdressDetail { get; set; }

    public int PlaceId { get; set; }

    public int CountryId { get; set; }

    public string PostalCode { get; set; } = null!;

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Fax { get; set; }

    public bool IsPassive { get; set; }

    public string? ContactName { get; set; }

    public string? ContactEmail { get; set; }

    public string? ContactPhone { get; set; }

    public string? ContactPosition { get; set; }

    public string? SAPCompanyCode { get; set; } 

    public int? PaymentTerms { get; set; }

    public decimal? VATRate { get; set; }

    public int? SectorId { get; set; }
    public int? BarsisCustomerId { get; set; }

    public decimal? Freight { get; set; }

    public int? PaymentTypeId { get; set; }

    public string? InvoiceEmail { get; set; }

    public string? Description { get; set; }

    public int InsUser { get; set; }

    public DateTime InsTime { get; set; }

    public DateTime? UpdTime { get; set; }

    public int? UpdUser { get; set; }




    public virtual Place Place { get; set; } = null!;

    public virtual Country Country { get; set; } = null!;

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual Sector? Sector { get; set; }

    public virtual ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();
}
