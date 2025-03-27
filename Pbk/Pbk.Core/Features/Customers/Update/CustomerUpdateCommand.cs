using Pbk.Core.Features.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Customers.Update
{ 
    public sealed record CustomerUpdateCommand
(
        int CustomerId,
        int DepartmentId,
     string CustomerName,
     string? Adress,
     string? AdressDetail,
     int? PlaceId,
     int? CountryId,
     string? PostalCode,
     string? Email,
     string? Phone,
     string? Fax, 
     string? ContactName,
     string? ContactEmail,
     string? ContactPhone,
     string? ContactPosition,
     string? SAPCompanyCode,
     int? PaymentTerms,
     decimal? VATRate,
     int? SectorId,
     decimal? Freight,
     int? PaymentTypeId,
     int? BarsisCustomerId,
     string? InvoiceEmail,
     string? Description
  ) : IRequest<APIResponse>;


}
