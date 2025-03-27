using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Dto.Location
{
    public class GetLocationDto
    {
 
       public int LocationId { get; set; }
        public int DepartmentId { get; set; }
        public string LocationName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int? PlaceId { get; set; }
        public int CountryId { get; set; }
        public string? Phone { get; set; }
        public string PostalCode { get; set; } = null!;
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public bool IsPassive { get; set; }

        public string? DepartmentName { get; set; }
        public string? PlaceName { get; set; }
        public string? CountryName { get; set; }    
        public string? state { get; set; }
   


    }
}
