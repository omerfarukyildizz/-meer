using Pbk.Core.Features.Response;
using MediatR;

namespace Pbk.Core.Features.Departments.Create
{
    public sealed record DepartmentCreateCommand
(
      string Code,
        string DepartmentName,
        string? InvoiceCurrency,
        string? CommercialAccount,
        string? BlockedAccount,
        string? OverdraftAccount,
        string? Director,
        string? DirectorEmail,
        string? Email,
        string? Address,
        int? PlaceId,
        int? CountryId,
        int? DocumentId,
        string? PostalCode,
        string? SAPCompanyCode, 
        int? CurrencyId,
        int? YdInvoiceNo,
        string? YdInvoicePrefix,
        string? Phone

 ) : IRequest<APIResponse>;


}
