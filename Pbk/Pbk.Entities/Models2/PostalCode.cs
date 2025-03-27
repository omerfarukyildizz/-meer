using System;
using System.Collections.Generic;

namespace Pbk.Entities.Models2;

public partial class PostalCode
{
    public int PostalCodeId { get; set; }

    public string? PostalCode1 { get; set; }

    public int PlaceId { get; set; }

    public int CountryId { get; set; }

    public string? Latitude { get; set; }

    public string? Longitude { get; set; }

    public int InsUser { get; set; }

    public DateTime InsTime { get; set; }

    public string? UpdUser { get; set; }

    public DateTime? UpdTime { get; set; }

    public virtual Country Country { get; set; } = null!;

    public virtual Place Place { get; set; } = null!;
}
