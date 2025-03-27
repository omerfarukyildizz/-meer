using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Dto
{
    public class GetDepartmentsDto
    {
        public int DepartmentId { get; set; }
        public string? PlaceName { get; set; }
        public string? CountryName { get; set; }
        public string Code { get; set; } = null!;
        public string DepartmentName { get; set; } = null!;
        public string? InvoiceCurrency { get; set; }
        public string? CommercialAccount { get; set; }
        public string? BlockedAccount { get; set; }
        public string? OverdraftAccount { get; set; }
        public string? Director { get; set; }
    }
}
