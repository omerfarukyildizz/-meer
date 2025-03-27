using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Invoices.Get
{
   

    public sealed record InvoiceGetQuery : IRequest<APIResponse>
    {
        internal sealed class InvoiceGetQueryHandler : IRequestHandler<InvoiceGetQuery, APIResponse>
        {
            private readonly IInvoiceRepository _invoiceRepository;
            private readonly IMapper _mapper;

            public InvoiceGetQueryHandler(IInvoiceRepository invoiceRepository, IMapper mapper)
            {
                _invoiceRepository = invoiceRepository;
                _mapper = mapper;
            }

            public async Task<APIResponse> Handle(InvoiceGetQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    return new(status: StatusType.Success, messages: "", _invoiceRepository.GetWhere(w => w.IsPassive == false).ToList());
                }
                catch (Exception ex)
                {
                    return new(status: StatusType.Error, messages: ex?.InnerException?.Message ?? ex?.Message, null);
                }
            }
        }

    }
}
