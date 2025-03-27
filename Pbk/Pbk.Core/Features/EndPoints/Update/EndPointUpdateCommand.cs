using Pbk.Core.Features.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.EndPoints.Update
{ 
    public sealed record EndPointUpdateCommand
(
        int PointId,
        int DepartmentId,

     string PointName,

     string? Address,

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


     // location'a kayıt atmak için
     bool? IsLocation
  ) : IRequest<APIResponse>;


}
