using Pbk.Core.Features.Response;
using MediatR;

namespace Pbk.Core.Features.Locations.Create
{
        public sealed record LocationCreateCommand
(
     int DepartmentId ,
     string LocationName , 
     string? Address , 
     int? PlaceId ,
     int? CountryId ,
     string? Phone ,
     string PostalCode , 
     string? Latitude ,
     string? Longitude , 

     //Endpoint için
     string? RelatedPerson,

     string? Email,

     string? Reference,
     int? BarsisAdrBankCode,
     int? PointId,

     bool? IsEndPoint


  ) : IRequest<APIResponse>;


}
