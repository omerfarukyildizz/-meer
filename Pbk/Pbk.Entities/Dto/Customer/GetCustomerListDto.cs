using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Dto.Customer
{
    public class GetCustomerListDto
    {
        public string? PlaceName { get; set; }
        public string? DepartmentName { get; set; }
        public int? CustomerId { get; set; }
        public int? DepartmentId { get; set; }
        public string? CustomerName { get; set; } = null!;
        public string? Adress { get; set; } = null!;
        public string? AdressDetail { get; set; }
        public int? PlaceId { get; set; }
        public int? CountryId { get; set; }
        public string? PostalCode { get; set; } = null!;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }
        public bool IsPassive { get; set; }
        public string? ContactName { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactPhone { get; set; }
        public string? ContactPosition { get; set; }
        public string? SAPCompanyCode { get; set; } = null!;
        public int? PaymentTerms { get; set; }
        public int? BarsisCustomerId { get; set; }
        public decimal? VATRate { get; set; }
        public int? SectorId { get; set; }
        public decimal? Freight { get; set; }
        public int? PaymentTypeId { get; set; }
        public string? InvoiceEmail { get; set; }
        public string? Description { get; set; }
        public string? State { get; set; }
    }
}
