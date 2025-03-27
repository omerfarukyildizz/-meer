using System;
using System.Collections.Generic;

namespace Pbk.Entities.Models2;

public partial class Vehicle
{
    public int VehicleId { get; set; }

    public int? VehicleTypeId { get; set; }

    public string Plate { get; set; } = null!;

    public int DepartmentId { get; set; }

    public bool? IsPassive { get; set; }

    public bool? IsRented { get; set; }

    public int? ProjectId { get; set; }

    public int? DocumentId { get; set; }

    public int InsUser { get; set; }

    public DateTime InsTime { get; set; }

    public int? UpdUser { get; set; }

    public DateTime? UpdTime { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual Document? Document { get; set; }

    public virtual Project? Project { get; set; }

    public virtual VehicleType? VehicleType { get; set; }

    public virtual ICollection<Voyage> VoyageTrailers { get; set; } = new List<Voyage>();

    public virtual ICollection<Voyage> VoyageTrucks { get; set; } = new List<Voyage>();
}
