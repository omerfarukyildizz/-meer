using Pbk.Core.Features.Response;
using MediatR;

namespace Pbk.Core.Features.EndPoints.Create
{
        public sealed record EndPointCreateCommand
(
    int DepartmentId,

     string PointName,

     string Address,

     int? PlaceId,

     int? CountryId,

     string? Phone,

     string? PostalCode,

     string? RelatedPerson,

     string? Email,

     string? Reference,

     int? BarsisAdrBankCode,

     string? Latitude,

     string? Longitude, 

     int? LocationId,


     // location'a kayıt atmak için
     bool? IsLocation

  ) : IRequest<APIResponse>;


}
