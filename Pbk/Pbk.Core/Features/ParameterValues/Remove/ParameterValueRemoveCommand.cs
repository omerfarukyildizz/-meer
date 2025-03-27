using Pbk.Core.Features.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.ParameterValues.Remove
{ 
    public sealed record ParameterValueRemoveCommand
( 
     int ParameterValueId

  ) : IRequest<APIResponse>;


}
