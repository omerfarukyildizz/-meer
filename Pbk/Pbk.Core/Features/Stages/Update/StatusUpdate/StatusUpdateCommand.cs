using Pbk.Core.Features.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Stages.Update.StatusUpdate
{
   

    public sealed record StatusUpdateCommand
(
       int StageId,
       int statusTypeId
 ) : IRequest<APIResponse>;


}
