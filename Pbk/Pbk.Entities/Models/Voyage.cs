using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pbk.Entities.Models;

public  class Voyage
{
    [Key]
    public int VoyageId { get; set; }

    public int? CarrierId { get; set; }

    public int TruckId { get; set; }
    public int? TrailerId { get; set; }

    public int? DriverId { get; set; }

    public bool IsPassive { get; set; }

    public int Year { get; set; }

    public int StatusTypeId { get; set; }

    public int? BarsisSeferNo { get; set; }

    public int InsUser { get; set; }

    public DateTime InsTime { get; set; }

    public int? UpdUser { get; set; }

    public DateTime? UpdTime { get; set; }

    public int DepartmentId { get; set; }

    public decimal? TransportPrice { get; set; }

    public int? CurrencyId { get; set; }

    public string? Description { get; set; }

    public decimal EmptyKm { get; set; }

    //public virtual Carrier? Carrier { get; set; }

    //public virtual ICollection<CostItem> CostItems { get; set; } = new List<CostItem>();

    //public virtual Driver Driver { get; set; } = null!;

    //public virtual ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();

    //public virtual ICollection<Stage> Stages { get; set; } = new List<Stage>();

    public virtual Vehicle? Trailer { get; set; }

    public virtual Vehicle Truck { get; set; } = null!;
}
