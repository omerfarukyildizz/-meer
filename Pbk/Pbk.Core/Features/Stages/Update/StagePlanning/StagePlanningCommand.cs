using Pbk.Core.Features.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Stages.Update.StagePlanning
{
 
    public sealed record StagePlanningCommand
(
        int StageId,
        int VehicleId,
        bool LTLandFTLControl,
        bool LoadingTimeArrivalTimeNextControl
  ) : IRequest<APIResponse>;

}
