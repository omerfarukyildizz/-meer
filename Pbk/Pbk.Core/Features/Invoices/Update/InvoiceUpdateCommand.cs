using Pbk.Core.Features.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Invoices.Update
{
    public sealed record InvoiceUpdateCommand
(
        int InvoiceId,
       int CustomerId,
    int? TruckId,
    int? TrailerId,
    int? SenderId,
    int? ReceiverId,
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
