using Pbk.Core.Features.Response;
using MediatR;

namespace Pbk.Core.Features.Stages.Remove
{ 
    public sealed record StageRemoveCommand
( 
     int StageId,
     int? DepartmentId

  ) : IRequest<APIResponse>;


}
