using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Models
{
    public class Unit
    {
        public int UnitId { get; set; }
        public string UnitName { get; set; } = null!;
        public int InsUser { get; set; }
        public DateTime InsTime { get; set; }
    }
}
