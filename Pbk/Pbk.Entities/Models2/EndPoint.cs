using System;
using System.Collections.Generic;

namespace Pbk.Entities.Models2;

public partial class EndPoint
{
    public int PointId { get; set; }

    public int DepartmentId { get; set; }

    public string PointName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int? PlaceId { get; set; }

    public int CountryId { get; set; }

    public string? Phone { get; set; }

    public string PostalCode { get; set; } = null!;

    public string? RelatedPerson { get; set; }

    public string? Email { get; set; }

    public string? Reference { get; set; }

    public string? BarsisAdrBankCode { get; set; }

    public string? Latitude { get; set; }

    public string? Longitude { get; set; }

    public bool IsPassive { get; set; }

    public int InsUser { get; set; }

    public DateTime InsTime { get; set; }

    public int? UpdUser { get; set; }

    public DateTime? UpdTime { get; set; }

    public virtual Country Country { get; set; } = null!;

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<Invoice> InvoiceReceivers { get; set; } = new List<Invoice>();

    public virtual ICollection<Invoice> InvoiceSenders { get; set; } = new List<Invoice>();
}
