using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Models
{
    public class Page
    {
        [Key]
        public int PageId { get; set; }
        public string PageName { get; set; } = null!;
        public int? ParentPageId { get; set; }
        public int InsUser { get; set; }
        public DateTime InsTime { get; set; }
    }
}
