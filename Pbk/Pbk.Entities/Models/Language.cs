using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pbk.Entities.Models;

public partial class Language
{
    [Key]
    public int LanguageId { get; set; }

    public string LanguageName { get; set; } = null!;

    public string? LanguageIcon { get; set; }

    public bool IsPassive { get; set; }

    public int InsUserId { get; set; }

    public DateTime InsDate { get; set; }

    public int? UpdUserId { get; set; }

    public DateTime? UpdDate { get; set; }
}
