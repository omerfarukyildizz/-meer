using System;
using System.Collections.Generic;

namespace Pbk.Entities.Models2;

public partial class ViewSetting
{
    public int SettingId { get; set; }

    public int UserId { get; set; }

    public int PageId { get; set; }

    public string FieldsSettings { get; set; } = null!;

    public DateTime InsTime { get; set; }

    public DateTime? UpdTime { get; set; }

    public virtual User User { get; set; } = null!;
}
