using Pbk.Core.Features.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Drivers.Remove
{ 
    public sealed record DriverRemoveCommand
( 
     int DriverId

  ) : IRequest<APIResponse>;


}
