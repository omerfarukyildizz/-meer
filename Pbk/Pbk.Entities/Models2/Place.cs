using System;
using System.Collections.Generic;

namespace Pbk.Entities.Models2;

public partial class Place
{
    public int PlaceId { get; set; }

    public int CountryId { get; set; }

    public string PlaceName { get; set; } = null!;

    public string? State { get; set; }

    public string? StateCode { get; set; }

    public string? Province { get; set; }

    public string? ProvinceCode { get; set; }

    public string? Community { get; set; }

    public string? CommunityCode { get; set; }

    public int InsUser { get; set; }

    public DateTime InsTime { get; set; }

    public string? UpdUser { get; set; }

    public DateTime? UpdTime { get; set; }

    public virtual Country Country { get; set; } = null!;

    public virtual ICollection<PostalCode> PostalCodes { get; set; } = new List<PostalCode>();
}
