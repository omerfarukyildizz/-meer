using Pbk.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Models
{
    public class BaseEntity : Entity
    {
        public int InsUser { get; set; }
        public DateTime InsTime { get; set; }
        public int? UpdUser { get; set; }
        public DateTime? UpdTime { get; set; }
        public bool IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public int? DeletedUserId { get; set; }
    }
}
