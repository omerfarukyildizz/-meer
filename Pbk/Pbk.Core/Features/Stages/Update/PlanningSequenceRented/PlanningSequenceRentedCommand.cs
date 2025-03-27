using Pbk.Core.Features.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Stages.Update.PlanningSequenceRented
{
    public sealed record PlanningSequenceRentedCommand
(
           int PlannedStageId,
           int PlanningSequence

) : IRequest<APIResponse>;

}
