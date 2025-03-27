using System;
using System.Collections.Generic;

namespace Pbk.Entities.Models2;

public partial class Country
{
    public int CountryId { get; set; }

    public string Code2 { get; set; } = null!;

    public string Code3 { get; set; } = null!;

    public string CountryName { get; set; } = null!;

    public string Continent { get; set; } = null!;

    public string ContinentCode { get; set; } = null!;

    public int InsUser { get; set; }

    public DateTime InsTime { get; set; }

    public string? UpdUser { get; set; }

    public DateTime? UpdTime { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

    public virtual ICollection<EndPoint> EndPoints { get; set; } = new List<EndPoint>();

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();

    public virtual ICollection<Place> Places { get; set; } = new List<Place>();

    public virtual ICollection<PostalCode> PostalCodes { get; set; } = new List<PostalCode>();
}
