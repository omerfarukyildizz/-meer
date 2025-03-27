using System;
using System.Collections.Generic;

namespace Pbk.Entities.Models2;

public partial class Role
{
    public int RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public int InsUser { get; set; }

    public DateTime InsTime { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
