using Pbk.Core.Features.Response;
using Pbk.Core.Features.Users;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Voyages.Get
{
 
    public sealed record PlanningOverviewGetQuery(int? SelectedDepartmentId ) : IRequest<APIResponse>
    {
        internal sealed class PlanningOverviewGetQueryHandler : IRequestHandler<PlanningOverviewGetQuery, APIResponse>
        {

            private readonly IVoyageRepository _voyageRepository;
            private readonly IUserManager _userManager;
            

            public PlanningOverviewGetQueryHandler(IVoyageRepository voyageRepository, IUserManager userManager)
            {
                _voyageRepository = voyageRepository;
                _userManager = userManager;
            }

            public async Task<APIResponse> Handle(PlanningOverviewGetQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var user = _userManager.UserInfo();
                    var data = _voyageRepository.GetPlanningOverview(request.SelectedDepartmentId, user.RoleId, user.UserId);

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
