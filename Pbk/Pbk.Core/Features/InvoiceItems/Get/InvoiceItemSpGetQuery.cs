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
 

    public sealed record InvoiceItemSpGetQuery(DateTime? StartDate, DateTime? EndDate, int? SelectedDepartmentId, bool ShowInvoiced) : IRequest<APIResponse>
    {
        internal sealed class InvoiceItemSpGetQueryHandler : IRequestHandler<InvoiceItemSpGetQuery, APIResponse>
        {
            private readonly IInvoiceItemRepository _invoiceItemRepository;
            private readonly IUserManager _userManager;
            private readonly IMapper _mapper;

            public InvoiceItemSpGetQueryHandler(IInvoiceItemRepository invoiceItemRepository, IMapper mapper, IUserManager userManager)
            {
                _invoiceItemRepository = invoiceItemRepository;
                _mapper = mapper;
                _userManager = userManager;
            }

            public async Task<APIResponse> Handle(InvoiceItemSpGetQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var user = _userManager.UserInfo();
                    var data = _invoiceItemRepository.GetInvoiceItem(request.StartDate, request.EndDate, request.SelectedDepartmentId, user.RoleId, user.UserId, request.ShowInvoiced);

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
