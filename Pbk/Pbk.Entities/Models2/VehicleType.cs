using System;
using System.Collections.Generic;

namespace Pbk.Entities.Models2;

public partial class VehicleType
{
    public int VehicleTypeId { get; set; }

    public string VehicleTypeName { get; set; } = null!;

    public string? Description { get; set; }

    public int InsUser { get; set; }

    public DateTime? InsTime { get; set; }

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
