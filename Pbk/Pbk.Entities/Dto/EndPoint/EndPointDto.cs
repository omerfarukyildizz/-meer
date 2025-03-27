using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Dto.EndPoint
{
    public class EndPointDto
    {
        public int? PointId { get; set; }
        public int? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public string? PointName { get; set; }
        public string? Address { get; set; }
        public string? State { get; set; }
        public int? PlaceId { get; set; }
        public string? PlaceName { get; set; }
        public int? CountryId { get; set; }
        public string? CountryName { get; set; }
        public string? Phone { get; set; }
        public string? PostalCode { get; set; }
        public string? RelatedPerson { get; set; }
        public string? Email { get; set; }
        public string? Reference { get; set; }
        public int? BarsisAdrBankCode { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public bool IsPassive { get; set; }
        public int? InsUser { get; set; }
        public string? UserName { get; set; }
    }
}
