using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Dto
{
    public class GetEndPointDto
    {
        public int PointId { get; set; }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = null!; 

        public string PointName { get; set; } = null!;

        public string Address { get; set; } = null!;
        public string? state { get; set; }

        public int PlaceId { get; set; }
        public string PlaceName { get; set; } = null!;

        public int CountryId { get; set; }  
        public string CountryName { get; set; } = null!;
        public string? Phone { get; set; }

        public string PostalCode { get; set; } = null!;

        public string? RelatedPerson { get; set; }

        public string? Email { get; set; }

        public string? Reference { get; set; }

        public int? BarsisAdrBankCode { get; set; }

        public string? Latitude { get; set; }

        public string? Longitude { get; set; }
        public bool IsPassive { get; set; }
    }
}
