using Pbk.Core.Features.Response;
using Pbk.Core.Features.Users;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.CostItems.Get
{
   
    public sealed record VendorGetQuery(string?  search) : IRequest<APIResponse>
    {
        internal sealed class VendorGetQueryHandler : IRequestHandler<VendorGetQuery, APIResponse>
        {
            private readonly ICostItemRepository _costItemRepository;

            public VendorGetQueryHandler(ICostItemRepository costItemRepository)
            {
                _costItemRepository = costItemRepository;
            
            }


            public async Task<APIResponse> Handle(VendorGetQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var list = _costItemRepository.GetVendor(request.search);
                    return new(status: StatusType.Success, messages: "", list);
                }
                catch (Exception ex)
                {
                    return new(status: StatusType.Error, messages: ex?.InnerException?.Message ?? ex?.Message, null);
                }
            }
        }

    }
}
