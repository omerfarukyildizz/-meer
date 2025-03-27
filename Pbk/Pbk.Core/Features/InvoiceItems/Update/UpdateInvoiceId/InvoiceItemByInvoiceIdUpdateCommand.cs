using Pbk.Core.Features.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.InvoiceItems.Update.UpdateInvoiceId
{
    public sealed record InvoiceItemByInvoiceIdUpdateCommand
(
       int InvoiceItemId,
 int InvoiceId
) : IRequest<APIResponse>;

}
