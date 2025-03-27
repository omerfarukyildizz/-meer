using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Dto
{
    public class GetParametersDto
    {
        public int ParameterID { get; set; }

        public string? Description { get; set; }

        public string? Code { get; set; } = null!;

        public string? CustomField1 { get; set; }

        public string? CustomField2 { get; set; }

        public string? CustomField3 { get; set; }

        public string? CustomField4 { get; set; }

        public string? CustomField5 { get; set; }

    }
}
