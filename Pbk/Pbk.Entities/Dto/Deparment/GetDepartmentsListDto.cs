using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Dto.Deparment
{
    public class GetDepartmentsListDto
    {
        public int DepartmentId { get; set; }

        public string Code { get; set; } = null!;

        public string? DepartmentName { get; set; } = null!;

        public string? InvoiceCurrency { get; set; }

        public string? CommercialAccount { get; set; }

        public string? BlockedAccount { get; set; }

        public string? OverdraftAccount { get; set; }

        public string? Director { get; set; }

        public string? DirectorEmail { get; set; }

        public string? Email { get; set; }

        public string? Address { get; set; }
        public string? UserName { get; set; }

        public int? PlaceId { get; set; }

        public int? CountryId { get; set; }

        public string? PostalCode { get; set; }

        public string? SAPCompanyCode { get; set; }

        public bool? IsPassive { get; set; }

        public int? CurrencyId { get; set; }
        public string? CurrencyName { get; set; }

        public int? DocumentId { get; set; }

        public int? YdInvoiceNo { get; set; }

        public string? YdInvoicePrefix { get; set; }
        public string? State { get; set; }
        public string? CountryName { get; set; } 
        public string? Phone { get; set; } 
        public string? PlaceName { get; set; }    



    }
}
