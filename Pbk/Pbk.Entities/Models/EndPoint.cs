using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pbk.Entities.Models;

public partial class EndPoint
{
    [Key]
    public int PointId { get; set; }
    public int DepartmentId { get; set; }
    public string PointName { get; set; } = null!;
    public string? Address { get; set; }
    public int? PlaceId { get; set; }
    public int? CountryId { get; set; }
    public string? Phone { get; set; }
    public string? PostalCode { get; set; }
    public string? RelatedPerson { get; set; }
    public string? Email { get; set; }
    public string? Reference { get; set; }
    public int? BarsisAdrBankCode { get; set; }
    public int? LocationId { get; set; }
    public string? Latitude { get; set; }
    public string? Longitude { get; set; }
    public bool IsPassive { get; set; }
    public int InsUser { get; set; }
    public DateTime InsTime { get; set; }
    public int? UpdUser { get; set; }
    public DateTime? UpdTime { get; set; }

    public virtual Department Department { get; set; } = null!;

    //public virtual ICollection<Invoice> InvoiceReceivers { get; set; } = new List<Invoice>();

    //public virtual ICollection<Invoice> InvoiceSenders { get; set; } = new List<Invoice>();
}
