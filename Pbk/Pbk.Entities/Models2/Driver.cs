using System;
using System.Collections.Generic;

namespace Pbk.Entities.Models2;

public partial class Driver
{
    public int DriverId { get; set; }

    public int? VehicleId { get; set; }

    public string DriverName { get; set; } = null!;

    public int DepartmentId { get; set; }

    public string? EdiCode { get; set; }

    public string IntegratedAccountCode { get; set; } = null!;

    public int InsUser { get; set; }

    public DateTime InsTime { get; set; }

    public int? UpdUser { get; set; }

    public DateTime? UpdTime { get; set; }

    public bool IsPassive { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<Voyage> Voyages { get; set; } = new List<Voyage>();
}
