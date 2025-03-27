using System;
using System.Collections.Generic;

namespace Pbk.Entities.Models2;

public partial class PagePermission
{
    public int PagePermissionId { get; set; }

    public int PageId { get; set; }

    public string PermissionType { get; set; } = null!;

    public int InsUser { get; set; }

    public DateTime InsTime { get; set; }

    public virtual ICollection<Authority> Authorities { get; set; } = new List<Authority>();

    public virtual Page Page { get; set; } = null!;
}
