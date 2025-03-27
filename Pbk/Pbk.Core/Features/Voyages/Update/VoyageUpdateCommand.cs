using Pbk.Core.Features.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Voyages.Update
{ 
    public sealed record VoyageUpdateCommand
(
        int VoyageId,

int? CarrierId,
int TruckId,
int? TrailerId,
int? DriverId, 
int Year,
int StatusTypeId,
int? BarsisSeferNo,
int DepartmentId,
decimal? TransportPrice,
int? CurrencyId,
string? Description,
decimal EmptyKm

  ) : IRequest<APIResponse>;


}
