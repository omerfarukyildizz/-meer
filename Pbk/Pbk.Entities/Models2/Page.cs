using System;
using System.Collections.Generic;

namespace Pbk.Entities.Models2;

public partial class Page
{
    public int PageId { get; set; }

    public string PageName { get; set; } = null!;

    public int? ParentPageId { get; set; }

    public int InsUser { get; set; }

    public DateTime InsTime { get; set; }

    public virtual ICollection<Authority> Authorities { get; set; } = new List<Authority>();

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    public virtual ICollection<PagePermission> PagePermissions { get; set; } = new List<PagePermission>();
}
