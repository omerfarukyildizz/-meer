using Pbk.Core.Features.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.InvoiceItems.Update
{ 
    public sealed record InvoiceItemUpdateCommand
(
          int InvoiceItemId,
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
