using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Models
{
    public class PagePermission
    {
        [Key]
        public int PagePermissionId { get; set; }
        public int PageId { get; set; }
        public string PermissionType { get; set; } = null!;
        public int InsUser { get; set; }
        public DateTime InsTime { get; set; }
    }
}
