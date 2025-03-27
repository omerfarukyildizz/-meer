using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Dto.Country
{
    public class GetCountriesDto
    {
        public string CountryId { get; set; } = null!;
        public string CountryName { get; set; } = null!;
    }
}
