using Pbk.Core.Features.Response;
using MediatR;

namespace Pbk.Core.Features.RevenueCodes.Create
{
        public sealed record RevenueCodeCreateCommand
(
int DepartmentId,
string RevenueCodeName,
string? IntegrationCode,
string? Description,
string? TycoCode,
int? TransactionId



  ) : IRequest<APIResponse>;


}
