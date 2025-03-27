using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Dto
{
    public class GetParameterListDto
    {
        public int ParameterId { get; set; }
        public string? CategoryName { get; set; }
        public string? ParameterName { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

    }
}
