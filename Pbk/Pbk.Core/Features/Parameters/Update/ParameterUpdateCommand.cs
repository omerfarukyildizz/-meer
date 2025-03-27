using Pbk.Core.Features.Response;
using MediatR;
namespace Pbk.Core.Features.Parameters.Update
{
    public sealed record ParameterUpdateCommand
(
        int ParameterId,
        string CategoryName,
        string ParameterName,
        string? Description
  ) : IRequest<APIResponse>;


}
