using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Models
{
    public class PaymentType
    {
        public int PaymentTypeId { get; set; }
        public string PaymentTypeName { get; set; } = null!;
        public string? Description { get; set; }
        public int InsUser { get; set; }
        public DateTime InsTime { get; set; }
    }
}
