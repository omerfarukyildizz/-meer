using System;
using System.Collections.Generic;

namespace Pbk.Entities.Models2;

public partial class Sector
{
    public int SectorId { get; set; }

    public string SectorName { get; set; } = null!;

    public string Code { get; set; } = null!;

    public int InsUser { get; set; }

    public DateTime? InsTime { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
