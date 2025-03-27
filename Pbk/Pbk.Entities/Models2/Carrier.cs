using System;
using System.Collections.Generic;

namespace Pbk.Entities.Models2;

public partial class Carrier
{
    public int CarrierId { get; set; }

    public int DepartmentId { get; set; }

    public string CarrierName { get; set; } = null!;

    public string SAPAccountCode { get; set; } = null!;

    public int? PaymentTerms { get; set; }

    public int? DocumentId { get; set; }

    public string? ContactPerson { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public bool IsPassive { get; set; }

    public int InsUser { get; set; }

    public DateTime InsTime { get; set; }

    public int? UpdUser { get; set; }

    public DateTime? UpdTime { get; set; }

    public virtual ICollection<CostItem> CostItems { get; set; } = new List<CostItem>();

    public virtual Department Department { get; set; } = null!;

    public virtual Document? Document { get; set; }

    public virtual ICollection<Voyage> Voyages { get; set; } = new List<Voyage>();
}
