using System;
using System.Collections.Generic;

namespace Pbk.Entities.Models2;

public partial class ArchiveType
{
    public int ArchiveTypeId { get; set; }

    public string ArchiveType1 { get; set; } = null!;

    public bool? IsPassive { get; set; }

    public int InsUser { get; set; }

    public DateTime? InsTime { get; set; }
}
