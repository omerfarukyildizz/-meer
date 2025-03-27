using Pbk.Core.Features.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Drivers.Update
{ 
    public sealed record DriverUpdateCommand
(
        int DriverId,
          int? VehicleId,

     string DriverName,

     int DepartmentId,

     string? EdiCode,

     string IntegratedAccountCode 
  ) : IRequest<APIResponse>;


}
