using Pbk.Core.Features.Response;
using MediatR;

namespace Pbk.Core.Features.CostItems.Create
{
    public sealed record CostItemCreateCommand
(

        int? ShipmentId,
        int? StageId,
        int? VoyageId,
        int DepartmentId,
        string? Vendor,
        int ExpenseCodeId,
        int SectorId,
        decimal Amount,
        int CurrencyId,
        decimal? VATRate,
        int? PaymentTerms,
        string InvoiceNo,
        DateTime? InvoiceDate,
        string? Description,
        int Year,
        int? BarsisCostId 
  ) : IRequest<APIResponse>;


}
