using Pbk.Core.Features.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.CostItems.Remove
{ 
    public sealed record CostItemRemoveCommand
( 
     int CostItemId

  ) : IRequest<APIResponse>;


}
