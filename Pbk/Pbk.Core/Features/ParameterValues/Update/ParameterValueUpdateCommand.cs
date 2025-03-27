using Pbk.Core.Features.Response;
using MediatR;
namespace Pbk.Core.Features.ParameterValues.Update
{
    public sealed record ParameterValueUpdateCommand
(
        int ParameterValueId,
        int ParameterId,
string? Code,
string? CustomField1,
string? CustomField2,
string? CustomField3,
string? CustomField4,
string? CustomField5
  ) : IRequest<APIResponse>;


}
