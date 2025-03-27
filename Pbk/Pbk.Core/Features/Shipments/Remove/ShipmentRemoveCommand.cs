using Pbk.Core.Features.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Shipments.Remove
{ 
    public sealed record ShipmentRemoveCommand
( 
     int ShipmentId,
      int? DepartmentId
  ) : IRequest<APIResponse>;


}
