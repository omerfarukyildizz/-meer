using Pbk.Core.Features.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Stages.Remove.StagePlanning
{
 

        public sealed record StagePlanningRemoveCommand
    (
         int StageId,
         int VehicleId

      ) : IRequest<APIResponse>;


}


