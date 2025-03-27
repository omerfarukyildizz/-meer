using Pbk.Core.Features.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Account.Remove
{ 
    public sealed record UserRemoveCommand
( 
     int UserId

  ) : IRequest<APIResponse>;


}
