using Pbk.Core.Features.Response;
using MediatR;
 
namespace Pbk.Core.Features.Carriers.Create
{
    public sealed record CarrierCreateCommand
(

     int DepartmentId  ,
     string CarrierName  ,
     string? SAPAccountCode  ,
     int? PaymentTerms ,
     int TimocomId,
     //int? DocumentId ,
     string? ContactPerson ,
     string? Email ,
     string? Phone 
  ) : IRequest<APIResponse>;


}
