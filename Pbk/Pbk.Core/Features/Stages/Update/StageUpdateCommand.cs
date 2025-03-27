using Pbk.Core.Features.Response;
using Pbk.Core.Features.Stages.Update;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Stages.Update
{ 
    public sealed record StageUpdateCommand
(
        int StageId,
 
        int SourceLocationId,
        int TargetLocationId,
        DateTime LoadingTime,
        DateTime UnloadingTime,
        decimal? StageKM

  ) : IRequest<APIResponse>;


}
