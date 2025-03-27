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

namespace Pbk.Core.Features.CostItems.Get
{
 
    public sealed record CostItemByParamGetQuery(int? shipmentId, int? voyageId, int? stageId) : IRequest<APIResponse>
    {
        internal sealed class CostItemByParamGetQueryHandler : IRequestHandler<CostItemByParamGetQuery, APIResponse>
        {
            private readonly ICostItemRepository _costItemRepository;
            private readonly IUserManager _userManager;
            private readonly IMapper _mapper;

            public CostItemByParamGetQueryHandler(ICostItemRepository costItemRepository, IMapper mapper, IUserManager userManager)
            {
                _costItemRepository = costItemRepository;
                _mapper = mapper;
                _userManager = userManager;
            }


            public async Task<APIResponse> Handle(CostItemByParamGetQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var user = _userManager.UserInfo();
                    var data = _costItemRepository.GetCostItemByParam(request.shipmentId, request.stageId, request.voyageId);

                    return new(status: StatusType.Success, messages: "", data);
                }
                catch (Exception ex)
                {
                    // Hata durumunda hata mesajı döndür
                    return new(status: StatusType.Error, messages: ex?.InnerException?.Message ?? ex?.Message, null);
                }
            }
        }

    }
}
