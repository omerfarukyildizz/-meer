using Pbk.Core.Features.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Departments.Update
{ 
    public sealed record DepartmentUpdateCommand
(
        int DepartmentId,
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
