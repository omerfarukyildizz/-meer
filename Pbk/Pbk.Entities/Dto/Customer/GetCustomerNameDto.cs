using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Dto.Customer
{
    public class GetCustomerNameDto
    {
        public int? CustomerId { get; set; }
        public string CustomerName { get; set; } = null!;

    }
}
