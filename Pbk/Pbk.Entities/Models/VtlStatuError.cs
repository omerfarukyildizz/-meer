using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pbk.Entities.Models;

public partial class VtlStatuError
{
    [Key]
    public int StatuErrorId { get; set; }

    public string? ReferenceNo { get; set; }

    public string? FileName { get; set; }

    public string? Description { get; set; }

    public DateTime? InsTime { get; set; }

    public int InsUser { get; set; }

    public string? StatuCode { get; set; }

    public bool? Statu { get; set; }

    public DateTime? StatuTime { get; set; }
}
