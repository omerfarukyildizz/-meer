using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pbk.Entities.Models;

public  class Authority
{
    [Key]
    public int AuthorityID { get; set; }

    public int UserID { get; set; }
    public int DepartmentId { get; set; }

    public int PageId{ get; set; }  
    public int PagePermissionId { get; set; }

    public bool HasPermission { get; set; }

    public int InsUser { get; set; }

    public DateTime InsTime { get; set; }

    public int? UpdUser { get; set; }

    public DateTime? UpdTime { get; set; }

   // public virtual User User { get; set; } = null!;
}
