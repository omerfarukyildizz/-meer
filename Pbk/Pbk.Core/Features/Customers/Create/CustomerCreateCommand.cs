using Pbk.Core.Features.Response;
using MediatR;

namespace Pbk.Core.Features.Customers.Create
{
    public sealed record CustomerCreateCommand
(
      int DepartmentId, 
     string CustomerName, 
     string? Adress ,
     string? AdressDetail ,
     int? PlaceId ,
     int? CountryId ,
     string? PostalCode ,
     string? Email ,
     string? Phone ,
     string? Fax , 
     string? ContactName,
     string? ContactEmail ,
     string? ContactPhone ,
     string? ContactPosition ,
     string? SAPCompanyCode ,
     int? PaymentTerms ,
     decimal? VATRate ,
     int? SectorId ,
     decimal? Freight ,
     int? PaymentTypeId ,
     int? BarsisCustomerId,
     string? InvoiceEmail ,
     string? Description 
  ) : IRequest<APIResponse>;


}
