using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Dto.Place
{
    public class GetPlaceDto
    {
        public int PlaceId { get; set; }
        public int CountryId { get; set; }

        public string PlaceName { get; set; } = null!;
    }
}
