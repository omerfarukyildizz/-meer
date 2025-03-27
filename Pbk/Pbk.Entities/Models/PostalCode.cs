using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Models
{
    public class PostalCode
    {
        [Key]
        public int PostalCodeId { get; set; }

        public string? PostalCodeValue { get; set; }
        public int PlaceId { get; set; }
        public int CountryId { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public int InsUser { get; set; }
        public DateTime InsTime { get; set; }
        public string? UpdUser { get; set; }
        public DateTime? UpdTime { get; set; }
    }
}
