using System;
using System.Collections.Generic;

namespace Pbk.Entities.Models2;

public partial class Authority
{
    public int AuthorityID { get; set; }

    public int UserID { get; set; }

    public int DepartmentId { get; set; }

    public int PageId { get; set; }

    public int PagePermissionId { get; set; }

    public bool HasPermission { get; set; }

    public int InsUser { get; set; }

    public DateTime InsTime { get; set; }

    public int? UpdUser { get; set; }

    public DateTime? UpdTime { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual Page Page { get; set; } = null!;

    public virtual PagePermission PagePermission { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
