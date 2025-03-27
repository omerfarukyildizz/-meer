using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pbk.Entities.Models;

public partial class Location
{
    [Key]
    public int LocationId { get; set; }

    public int DepartmentId { get; set; }

    public string LocationName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int? PlaceId { get; set; }

    public int CountryId { get; set; }

    public string? Phone { get; set; }

    public string PostalCode { get; set; } = null!;

    public string? Latitude { get; set; }

    public string? Longitude { get; set; }

    public bool IsPassive { get; set; }

    public int InsUser { get; set; }

    public DateTime InsTime { get; set; }

    public int? UpdUser { get; set; }

    public DateTime? UpdTime { get; set; }
    public int? PointId { get; set; }


    //public virtual Country Country { get; set; } = null!;
   // public virtual Place Place { get; set; } = null!;

    //public virtual Department Department { get; set; } = null!;

    public virtual ICollection<StageLocation> StageLocations { get; set; } = new List<StageLocation>();
}
