using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pbk.Entities.Models;

public partial class User
{
    [Key]
    public int UserId { get; set; }

    public int DepartmentId { get; set; } 

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Position { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public bool? IsPassive { get; set; }
    public int BarsisUserId { get; set; }
    public int RoleId { get; set; }

    public int InsUser { get; set; }

    public DateTime InsTime { get; set; }

    public DateTime? UpdTime { get; set; }

    public int? UpdUser { get; set; }
     

    /*
    public virtual ICollection<Authority> Authorities { get; set; } = new List<Authority>();

 

    public virtual ICollection<ViewSetting> ViewSettings { get; set; } = new List<ViewSetting>();*/
}
