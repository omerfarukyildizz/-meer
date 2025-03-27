using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Core.Features.Users;
using Pbk.Entities.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Stages.Get
{
 
    public sealed record StageSpGetQuery(DateTime? StartDate, DateTime? EndDate, int? SelectedDepartmentId, bool ShowCompleted) : IRequest<APIResponse>
    {
        internal sealed class StageSpGetQueryHandler : IRequestHandler<StageSpGetQuery, APIResponse>
        {
             
            private readonly IStageRepository _stageRepository;
            private readonly IUserManager _userManager;

            public StageSpGetQueryHandler(IStageRepository stageRepository, IUserManager userManager)
            {
                _stageRepository = stageRepository;
                _userManager = userManager;
            }

            public async Task<APIResponse> Handle(StageSpGetQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var user = _userManager.UserInfo();
                    var data = _stageRepository.GetStage(request.StartDate, request.EndDate, request.SelectedDepartmentId, user.RoleId, user.UserId, request.ShowCompleted );

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
