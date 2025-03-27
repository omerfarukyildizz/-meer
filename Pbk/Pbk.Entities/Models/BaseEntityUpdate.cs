using Pbk.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Models
{
    public class BaseEntityUpdate : Entity
    {
        public int upduser { get; set; }
        public DateTime? updtime { get; set; }
    }
}
