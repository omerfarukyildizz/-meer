using Pbk.Core.Features.Response;
using MediatR;

namespace Pbk.Core.Features.RevenueCodes.Update
{
        public sealed record RevenueCodeUpdateCommand
(
            int RevenueCodeId,
int DepartmentId,
string RevenueCodeName,
string? IntegrationCode,
string? Description,
string? TycoCode,
int? TransactionId



  ) : IRequest<APIResponse>;


}
