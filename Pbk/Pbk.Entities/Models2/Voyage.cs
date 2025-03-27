using System;
using System.Collections.Generic;

namespace Pbk.Entities.Models2;

public partial class Voyage
{
    public int VoyageId { get; set; }

    public int? CarrierId { get; set; }

    public int TruckId { get; set; }

    public int? TrailerId { get; set; }

    public int DriverId { get; set; }

    public DateTime? DepartureTime { get; set; }

    public DateTime? ArrivalTime { get; set; }

    public string? LoadingPostCode { get; set; }

    public string? UnloadingPostCode { get; set; }

    public decimal? VoyageKM { get; set; }

    public bool Closed { get; set; }

    public int? BarsisSeferNo { get; set; }

    public int InsUser { get; set; }

    public DateTime InsTime { get; set; }

    public int? UpdUser { get; set; }

    public DateTime? UpdTime { get; set; }

    public int Year { get; set; }

    public bool IsPassive { get; set; }

    public virtual Carrier? Carrier { get; set; }

    public virtual ICollection<CostItem> CostItems { get; set; } = new List<CostItem>();

    public virtual Driver Driver { get; set; } = null!;

    public virtual ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();

    public virtual ICollection<Stage> Stages { get; set; } = new List<Stage>();

    public virtual Vehicle? Trailer { get; set; }

    public virtual Vehicle Truck { get; set; } = null!;
}
