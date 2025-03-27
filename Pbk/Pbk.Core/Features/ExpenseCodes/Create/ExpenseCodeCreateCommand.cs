using Pbk.Core.Features.Response;
using MediatR;

namespace Pbk.Core.Features.ExpenseCodes.Create
{
        public sealed record ExpenseCodeCreateCommand
(
int DepartmentId,
string ExpenseCodeName,
string? IntegrationCode,
string? Description,
string? TycoCode,
string? ExpenseFlag,
int? TransactionId
 

  ) : IRequest<APIResponse>;


}
