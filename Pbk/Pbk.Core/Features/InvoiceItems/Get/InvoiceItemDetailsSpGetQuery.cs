using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Core.Features.Users;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.InvoiceItems.Get
{
 
    public sealed record InvoiceItemDetailsSpGetQuery(int customerId) : IRequest<APIResponse>
    {
        internal sealed class InvoiceItemDetailsSpGetQueryHandler : IRequestHandler<InvoiceItemDetailsSpGetQuery, APIResponse>
        {
            private readonly IInvoiceItemRepository _invoiceItemRepository;
            private readonly IMapper _mapper;

            public InvoiceItemDetailsSpGetQueryHandler(IInvoiceItemRepository invoiceItemRepository, IMapper mapper )
            {
                _invoiceItemRepository = invoiceItemRepository;
                _mapper = mapper;
            }

            public async Task<APIResponse> Handle(InvoiceItemDetailsSpGetQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    if (request.customerId ==null || request.customerId == 0)
                    {
                        return new(status: StatusType.Error, messages: "CustomerId boş geçilemez.", null);
                    }
                    var data = _invoiceItemRepository.GetInvoiceItemDetails(request.customerId);

                    return new(status: StatusType.Success, messages: "", data);
                }
                catch (Exception ex)
                {
                    return new(status: StatusType.Error, messages: ex?.InnerException?.Message ?? ex?.Message, null);
                }
            }
        }

    }


}
