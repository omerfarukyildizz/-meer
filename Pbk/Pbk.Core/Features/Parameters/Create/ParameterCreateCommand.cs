using Pbk.Core.Features.Response;
using MediatR;

namespace Pbk.Core.Features.Parameters.Create
{
    public sealed record ParameterCreateCommand
(
    string CategoryName,
    string ParameterName,
    string? Description
) : IRequest<APIResponse>;

}
