using System;
using System.Collections.Generic;

namespace Pbk.Entities.Models2;

public partial class PaymentType
{
    public int PaymentTypeId { get; set; }

    public string PaymentType1 { get; set; } = null!;

    public string? Description { get; set; }

    public int InsUser { get; set; }

    public DateTime InsTime { get; set; }
}
