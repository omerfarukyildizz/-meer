using System;
using System.Collections.Generic;

namespace Pbk.Entities.Models2;

public partial class Document
{
    public int DocumentId { get; set; }

    public int PageId { get; set; }

    public string? FilePath { get; set; }

    public string FileName { get; set; } = null!;

    public int ArchiveTypeId { get; set; }

    public int InsUser { get; set; }

    public DateTime InsTime { get; set; }

    public int? UpdUser { get; set; }

    public DateTime? UpdTime { get; set; }

    public int SourceId { get; set; }

    public virtual ICollection<Carrier> Carriers { get; set; } = new List<Carrier>();

    public virtual Page Page { get; set; } = null!;

    public virtual ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
