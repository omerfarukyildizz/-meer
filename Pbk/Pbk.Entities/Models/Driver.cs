using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pbk.Entities.Models;

public partial class Driver
{
    [Key]
    public int DriverId { get; set; }
    public int? VehicleId { get; set; }
    public string DriverName { get; set; } = null!;
    public int DepartmentId { get; set; }
    public string? EdiCode { get; set; }
    public string IntegratedAccountCode { get; set; } = null!;
    public bool IsPassive { get; set; }
    public int InsUser { get; set; }
    public DateTime InsTime { get; set; }
    public int? UpdUser { get; set; }
    public DateTime? UpdTime { get; set; }

    //public virtual Department DepartmentNavigation { get; set; } = null!;

    //public virtual ICollection<Voyage> Voyages { get; set; } = new List<Voyage>();
}
