using Pbk.Core.Features.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Stages.Update.StagePlanningRented
{

    public sealed record StagePlanningRentedCommand
(
      int StageId,
      int CarrierId,
      bool LTLandFTLControl
) : IRequest<APIResponse>;

}
