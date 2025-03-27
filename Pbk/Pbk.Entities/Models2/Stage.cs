using System;
using System.Collections.Generic;

namespace Pbk.Entities.Models2;

public partial class Stage
{
    public int StageId { get; set; }

    public int ShipmentId { get; set; }

    public int? VoyageId { get; set; }

    public int StageNumber { get; set; }

    public string StageStatus { get; set; } = null!;

    public int SenderId { get; set; }

    public int ReceiverId { get; set; }

    public DateTime LoadingDateTime { get; set; }

    public DateTime UnloadingDateTime { get; set; }

    public string? LoadingPostCode { get; set; }

    public string? UnloadingPostCode { get; set; }

    public int InsUser { get; set; }

    public DateTime InsTime { get; set; }

    public int? UpdUser { get; set; }

    public DateTime? UpdTime { get; set; }

    public bool IsPassive { get; set; }

    public virtual ICollection<CostItem> CostItems { get; set; } = new List<CostItem>();

    public virtual ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();

    public virtual Shipment Shipment { get; set; } = null!;

    public virtual ICollection<StageLocation> StageLocations { get; set; } = new List<StageLocation>();

    public virtual Voyage? Voyage { get; set; }
}
