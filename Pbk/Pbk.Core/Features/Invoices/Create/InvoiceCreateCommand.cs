using Pbk.Core.Features.Response;
using MediatR;

namespace Pbk.Core.Features.Invoices.Create
{
        public sealed record InvoiceCreateCommand
(
         int CustomerId,
    int? SenderId,
    int? ReceiverId,
    int? TruckId,
    int? TrailerId,
    int DepartmentId,
    string? InvoiceNo,
    DateTime? InvoiceDate,
    string? IntegrationNo,
    decimal Amount,
    int CurrencyId,
    decimal? VATAmount,
    DateTime? DueDate,
    string? Description,
    int Year,
    int? BarsisInvoiceId, 
    int SectorId,
    string? CustomerReference,
    string? BGLReference

  ) : IRequest<APIResponse>;


}
