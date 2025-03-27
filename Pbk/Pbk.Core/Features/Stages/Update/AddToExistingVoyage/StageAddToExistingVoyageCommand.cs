using Pbk.Core.Features.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Stages.Update.AddToExistingVoyage
{
 

    public sealed record StageAddToExistingVoyageCommand
(
    List<int> StageIds,
    int VoyageId,
    int departmentId,
      bool? isSenderVoyageAddStage 

) : IRequest<APIResponse>;

}
