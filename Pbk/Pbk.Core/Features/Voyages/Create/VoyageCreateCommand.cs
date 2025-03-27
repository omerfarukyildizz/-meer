using Pbk.Core.Features.Response;
using MediatR;

namespace Pbk.Core.Features.Voyages.Create
{
        public sealed record VoyageCreateCommand
(
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
decimal EmptyKm,
string? plate,
List<int>? plannedStages
) : IRequest<APIResponse>;


}
