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

namespace Pbk.Core.Features.Invoices.Get
{
     
    public sealed record InvoiceSpGetQuery(DateTime? StartDate, DateTime? EndDate, int? SelectedDepartmentId ) : IRequest<APIResponse>
    {
        internal sealed class InvoiceSpGetQueryHandler : IRequestHandler<InvoiceSpGetQuery, APIResponse>
        {
            private readonly IInvoiceRepository _invoiceRepository;
            private readonly IUserManager _userManager;
            private readonly IMapper _mapper;

            public InvoiceSpGetQueryHandler(IInvoiceRepository invoiceRepository, IMapper mapper, IUserManager userManager)
            {
                _invoiceRepository = invoiceRepository;
                _mapper = mapper;
                _userManager = userManager;
            }

            public async Task<APIResponse> Handle(InvoiceSpGetQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var user = _userManager.UserInfo();
                    var data = _invoiceRepository.GetInvoice(request.StartDate, request.EndDate, request.SelectedDepartmentId, user.RoleId, user.UserId);
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
