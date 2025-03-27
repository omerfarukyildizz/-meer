using Pbk.Core.Features.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Stages.Remove.StagePlanningRented
{

    public sealed record StagePlanningRentedRemoveCommand
(
     int StageId,
     int CarrierId

  ) : IRequest<APIResponse>;
}
