using System;
using System.Collections.Generic;

namespace Pbk.Entities.Models2;

public partial class Translation
{
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
