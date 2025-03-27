using System;
using System.Collections.Generic;

namespace Pbk.Entities.Models2;

public partial class StageLocation
{
    public int StageLocationId { get; set; }

    public int StageId { get; set; }

    public int LocationId { get; set; }

    public string LoadingType { get; set; } = null!;

    public int SequenceNumber { get; set; }

    public int InsUser { get; set; }

    public DateTime InsTime { get; set; }

    public int? UpdUser { get; set; }

    public DateTime? UpdTime { get; set; }

    public virtual Location Location { get; set; } = null!;

    public virtual Stage Stage { get; set; } = null!;
}
