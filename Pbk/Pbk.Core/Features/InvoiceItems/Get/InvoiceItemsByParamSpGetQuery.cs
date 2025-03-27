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
 

    public sealed record InvoiceItemsByParamSpGetQuery(int? shipmentId,int? stageId,int? voyageId) : IRequest<APIResponse>
    {
        internal sealed class InvoiceItemsByParamSpGetQueryHandler : IRequestHandler<InvoiceItemsByParamSpGetQuery, APIResponse>
        {
            private readonly IInvoiceItemRepository _invoiceItemRepository;
            private readonly IUserManager _userManager;
            private readonly IMapper _mapper;

            public InvoiceItemsByParamSpGetQueryHandler(IInvoiceItemRepository invoiceItemRepository, IMapper mapper, IUserManager userManager)
            {
                _invoiceItemRepository = invoiceItemRepository;
                _mapper = mapper;
                _userManager = userManager;
            }

            public async Task<APIResponse> Handle(InvoiceItemsByParamSpGetQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var user = _userManager.UserInfo();
                    var data = _invoiceItemRepository.GetInvoiceItemByParam(request.shipmentId, request.stageId, request.voyageId);

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
