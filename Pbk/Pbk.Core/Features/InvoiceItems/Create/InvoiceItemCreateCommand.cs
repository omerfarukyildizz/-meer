using Pbk.Core.Features.Response;
using MediatR;

namespace Pbk.Core.Features.InvoiceItems.Create
{
        public sealed record InvoiceItemCreateCommand
(
    int? InvoiceId,
    int CustomerId,
    int? ShipmentId,
    int? StageId,
    int? VoyageId,
    int DepartmentId,
    int RevenueCodeId,
    int SectorId,
    decimal Amount,
    int CurrencyId,
    decimal? VATRate,
    string? Description,
    int Year, 
    int? BarsisInvoiceItemId 
  ) : IRequest<APIResponse>;


}
