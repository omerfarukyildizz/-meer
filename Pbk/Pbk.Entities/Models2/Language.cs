using System;
using System.Collections.Generic;

namespace Pbk.Entities.Models2;

public partial class Language
{
    public int LanguageId { get; set; }

    public string LanguageName { get; set; } = null!;

    public string? LanguageIcon { get; set; }

    public bool IsPassive { get; set; }

    public int InsUserId { get; set; }

    public DateTime InsDate { get; set; }

    public int? UpdUserId { get; set; }

    public DateTime? UpdDate { get; set; }
}
