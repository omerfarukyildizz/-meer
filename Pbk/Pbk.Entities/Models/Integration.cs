using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Models
{
    public class Integration
    {
        public int IntegrationId { get; set; }
        public string CompanyName { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime InsTime { get; set; }
        public int InsUser { get; set; }
    }
}
