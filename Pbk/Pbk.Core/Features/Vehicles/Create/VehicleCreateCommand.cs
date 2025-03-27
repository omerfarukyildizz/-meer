using Pbk.Core.Features.Response;
using MediatR;

namespace Pbk.Core.Features.Vehicles.Create
{
        public sealed record VehicleCreateCommand
(
       int VehicleTypeId,
string Plate,
int DepartmentId, 
bool? IsRented,
int? ProjectId,
int? DocumentId,
int? CustomerId,
DateTime? TuvInspection,
DateTime? SafetyInspection,
int? CarrierId



) : IRequest<APIResponse>;


}
