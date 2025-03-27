using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pbk.Entities.Models;

public partial class Stage
{
    [Key]
    public int StageId { get; set; }

    public int ShipmentId { get; set; }

    public int? VoyageId { get; set; }

    public int StageNumber { get; set; }

    public int StatusTypeId { get; set; }

    public int SourceLocationId { get; set; }

    public int TargetLocationId { get; set; }

    public DateTime LoadingTime { get; set; }

    public DateTime UnloadingTime { get; set; }

    public int? VoyageSequence { get; set; }

    public bool IsPassive { get; set; }

    public int InsUser { get; set; }

    public DateTime InsTime { get; set; }

    public int? UpdUser { get; set; }

    public DateTime? UpdTime { get; set; }

    [Column(TypeName = "decimal(7, 2)")]
    public decimal? StageKM { get; set; }

    //public virtual ICollection<CostItem> CostItems { get; set; } = new List<CostItem>();

    //public virtual ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();

    //public virtual Shipment Shipment { get; set; } = null!;

    //public virtual ICollection<StageLocation> StageLocations { get; set; } = new List<StageLocation>();

    //public virtual Voyage? Voyage { get; set; }
}
