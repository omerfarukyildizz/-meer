using Pbk.Core.Features.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Vehicles.Update
{ 
    public sealed record VehicleUpdateCommand
(
        int VehicleId,
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
