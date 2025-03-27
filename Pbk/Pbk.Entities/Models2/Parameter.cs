using System;
using System.Collections.Generic;

namespace Pbk.Entities.Models2;

public partial class Parameter
{
    public int ParameterId { get; set; }

    public string ParameterName { get; set; } = null!;

    public string? Description { get; set; }

    public int InsUser { get; set; }

    public DateTime InsTime { get; set; }

    public int? UpdUser { get; set; }

    public DateTime? UpdTime { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<ParameterValue> ParameterValues { get; set; } = new List<ParameterValue>();
}
