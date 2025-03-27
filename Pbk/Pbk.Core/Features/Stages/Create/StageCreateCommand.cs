using Pbk.Core.Features.Response;
using MediatR;

namespace Pbk.Core.Features.Stages.Create
{
    public sealed record StageCreateCommand
(

      int ShipmentId,
      int? VoyageId,
      int SourceLocationId,
      int TargetLocationId,
      DateTime LoadingTime,
      DateTime UnloadingTime,
      int? VoyageSequence, 
      decimal? StageKM

) : IRequest<APIResponse>;
}
