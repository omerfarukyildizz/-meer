using Pbk.Core.Features.Response;
using MediatR;

namespace Pbk.Core.Features.ExpenseCodes.Update
{
        public sealed record ExpenseCodeUpdateCommand
(
    int ExpenseCodeId,
int DepartmentId,
string ExpenseCodeName,
string? IntegrationCode,
string? Description,
string? TycoCode,
string? ExpenseFlag,
int? TransactionId
 

  ) : IRequest<APIResponse>;


}
