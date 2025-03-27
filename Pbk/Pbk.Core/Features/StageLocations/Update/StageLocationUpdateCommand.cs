using Pbk.Core.Features.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.StageLocations.Update
{ 
    public sealed record StageLocationUpdateCommand
(
        int StageLocationId,

         int StageId,

     int LocationId,

     string LoadingType,

     int SequenceNumber
  ) : IRequest<APIResponse>;


}
