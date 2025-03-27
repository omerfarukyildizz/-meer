using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Models;

public partial class Option
{
    [Key]
    public int Id { get; set; }

    public string OptionName { get; set; } = null!;

    public string OptionValue { get; set; } = null!;

    public bool? IsActive { get; set; }

    public int? InsUserId { get; set; }

    public DateTime? InsDate { get; set; }

    public int? UpdUserId { get; set; }

    public DateTime? UpdDate { get; set; }

    public bool? IsDeleted { get; set; }
}
