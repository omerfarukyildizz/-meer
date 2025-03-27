using System;
using System.Collections.Generic;

namespace Pbk.Entities.Models2;

public partial class VtlStatu
{
    public int StatuId { get; set; }

    public int? ShipmentId { get; set; }

    public string? StatuCode { get; set; }

    public string? StatuDescription { get; set; }

    public DateTime? StatuTime { get; set; }

    public DateTime? InsTime { get; set; }

    public int InsUser { get; set; }

    public int? AnaYukNo { get; set; }

    public string? ReferenceNo { get; set; }

    public virtual Shipment? Shipment { get; set; }
}
