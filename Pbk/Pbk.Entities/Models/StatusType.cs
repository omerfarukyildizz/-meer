using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pbk.Entities.Models;

public partial class StatusType
{
    [Key]
    public int StatusTypeId { get; set; }

    public string StatusName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime InsTime { get; set; }

    public int InsUser { get; set; }

    //public virtual ICollection<CostItem> CostItems { get; set; } = new List<CostItem>();

    //public virtual ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();

    //public virtual Shipment Shipment { get; set; } = null!;

    //public virtual ICollection<StageLocation> StageLocations { get; set; } = new List<StageLocation>();

    //public virtual Voyage? Voyage { get; set; }
}
