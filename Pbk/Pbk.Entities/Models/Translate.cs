using System;
using System.Collections.Generic;

namespace Pbk.Entities.Models;

public partial class Translate
{

    public int TranslateId { get; set; }

    public int LanguageId { get; set; }

    public int ServiceId { get; set; }

    public string TranslateKey { get; set; } = null!;

    public string TranslateValue { get; set; } = null!;

    public bool? IsActive { get; set; }

    public int InsUserId { get; set; }

    public DateTime InsDate { get; set; }

    public int? UpdUserId { get; set; }

    public DateTime? UpdDate { get; set; }

    public bool? IsDeleted { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }
}
