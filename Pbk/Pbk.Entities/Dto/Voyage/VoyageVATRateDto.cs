using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Dto.Voyage
{
    public class VoyageVATRateDto
    {
        public int? VoyageId { get; set; }  
        public string? Plate { get; set; }  
        public decimal? VATRate { get; set; }  
    }
}
