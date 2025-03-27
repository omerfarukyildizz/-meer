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
    public sealed record CostItemListGetQuery(DateTime? StartDate, DateTime? EndDate, int? SelectedDepartmentId, bool ShowIntegrated) : IRequest<APIResponse>
    {
        internal sealed class CostItemListGetQueryHandler : IRequestHandler<CostItemListGetQuery, APIResponse>
        {
            private readonly ICostItemRepository _costItemRepository;
            private readonly IUserManager _userManager;

            public CostItemListGetQueryHandler(ICostItemRepository costItemRepository , IUserManager userManager)
            {
                _costItemRepository = costItemRepository;
                _userManager = userManager;
            }


            public async Task<APIResponse> Handle(CostItemListGetQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var user = _userManager.UserInfo();
                    var data = _costItemRepository.GetCostItemList(request.StartDate, request.EndDate, request.SelectedDepartmentId, user.RoleId,user.UserId,request.ShowIntegrated);

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
