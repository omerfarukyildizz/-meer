using System;
using System.Collections.Generic;

namespace Pbk.Entities.Models2;

public partial class Project
{
    public int ProjectId { get; set; }

    public string ProjectName { get; set; } = null!;

    public string? Description { get; set; }

    public int InsUser { get; set; }

    public DateTime? InsTime { get; set; }

    public bool IsPassive { get; set; }

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
