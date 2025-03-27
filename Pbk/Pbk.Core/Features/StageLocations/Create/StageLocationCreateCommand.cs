using Pbk.Core.Features.Response;
using MediatR;

namespace Pbk.Core.Features.StageLocations.Create
{
      public sealed record StageLocationCreateCommand
(
     int StageId ,

     int LocationId ,

     string LoadingType , 

     int SequenceNumber 

) : IRequest<APIResponse>;


}
