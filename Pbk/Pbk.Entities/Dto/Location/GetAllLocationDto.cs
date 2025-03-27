using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Dto.Location
{
    public class GetAllLocationDto
    {
        public int? LocationId { get; set; }
        public int? DepartmentId { get; set; }
        public string? LocationName { get; set; }
        public string? Address { get; set; }
        public int? PlaceId { get; set; }
        public string? Phone { get; set; }
        public int? CountryId { get; set; }
        public string? PostalCode { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public string? PlaceName { get; set; }
        public string? State { get; set; }
        public string? CountryName { get; set; }
        public string? DepartmentName { get; set; }
        public int? InsUser { get; set; }
        public string? UserName { get; set; }
    }
}
