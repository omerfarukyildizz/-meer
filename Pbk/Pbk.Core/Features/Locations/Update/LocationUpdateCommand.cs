using Pbk.Core.Features.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Locations.Update
{ 
    public sealed record LocationUpdateCommand
(
        int LocationId,
         int DepartmentId,
     string LocationName,
     string? Address,
     int? PlaceId,
     int? CountryId,
     string? Phone,
     string PostalCode,
     string? Latitude,
     string? Longitude, 

     //location için
     string? RelatedPerson,

     string? Email,

     string? Reference,

     int? BarsisAdrBankCode,


     bool? IsEndPoint


  ) : IRequest<APIResponse>;


}
