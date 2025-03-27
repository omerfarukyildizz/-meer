using System;
using System.Collections.Generic;

namespace Pbk.Entities.Models;

public partial class ParameterValue
{
    public int ParameterValueId { get; set; }

    public int ParameterId { get; set; }

    public string? Code { get; set; }

    public string? CustomField1 { get; set; }

    public string? CustomField2 { get; set; }

    public string? CustomField3 { get; set; }

    public string? CustomField4 { get; set; }

    public string? CustomField5 { get; set; }

    public int InsUser { get; set; }

    public DateTime InsTime { get; set; }

    public int? UpdUser { get; set; }

    public DateTime? UpdTime { get; set; }

    public virtual Parameter Parameter { get; set; } = null!;
}
