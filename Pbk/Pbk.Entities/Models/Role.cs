using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Models;

public partial class Role
{
    [Key]
    public int RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public int InsUser { get; set; }

    public DateTime InsTime { get; set; }
}