using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pbk.Entities.Models;

public partial class Department
{
    [Key]
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
    public int? DocumentId { get; set; }

    public int? YdInvoiceNo { get; set; }

    public string? YdInvoicePrefix { get; set; }

    public int? InsUser { get; set; }

    public DateTime InsTime { get; set; }

    public int? UpdUser { get; set; }

    public DateTime? UpdTime { get; set; }

    public string? Phone { get; set; }

    public virtual Document Document { get; set; } = null!;


}
