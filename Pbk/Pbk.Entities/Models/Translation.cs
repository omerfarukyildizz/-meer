using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pbk.Entities.Models;

public partial class Translation
{
    [Key]
    public int TranslateId { get; set; }

    public int LanguageId { get; set; }

    public int ServiceId { get; set; }

    public string TranslateKey { get; set; } = null!;

    public string TranslateValue { get; set; } = null!;

    public bool? IsPassive { get; set; }

    public int InsUserId { get; set; }

    public DateTime InsDate { get; set; }

    public int? UpdUserId { get; set; }

    public DateTime? UpdDate { get; set; }
}
