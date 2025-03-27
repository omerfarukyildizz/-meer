using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }

        public string Code2 { get; set; } = null!;

        public string Code3 { get; set; } = null!;

        public string CountryName { get; set; } = null!;

        public string Continent { get; set; } = null!;

        public string ContinentCode { get; set; } = null!;

        public int InsUser { get; set; }

        public DateTime InsTime { get; set; }

        public string? UpdUser { get; set; }

        public DateTime? UpdTime { get; set; }
    }

}
