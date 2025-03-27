using Pbk.Core.Features.Response;
using MediatR;

namespace Pbk.Core.Features.Drivers.Create
{
      public sealed record DriverCreateCommand
(
        int? VehicleId ,

     string DriverName , 

     int DepartmentId , 

     string? EdiCode ,

     string IntegratedAccountCode  
  ) : IRequest<APIResponse>;


}
