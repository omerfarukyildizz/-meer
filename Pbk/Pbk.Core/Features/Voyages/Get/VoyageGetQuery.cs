using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Core.Features.Users;
using Pbk.Entities.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Voyages.Get
{
 
    public sealed record VoyageSpGetQuery(DateTime? StartDate, DateTime? EndDate, int? SelectedDepartmentId ,bool ShowCompleted) : IRequest<APIResponse>
    {
        internal sealed class VoyageSpGetQueryHandler : IRequestHandler<VoyageSpGetQuery, APIResponse>
        {
            private readonly IVoyageRepository _voyageRepository;
            private readonly IUserManager _userManager;

            public VoyageSpGetQueryHandler(IVoyageRepository voyageRepository, IUserManager userManager)
            {
                _voyageRepository = voyageRepository;
                _userManager = userManager;
            }


            //Shipment Type Dropdown
            public async Task<APIResponse> Handle(VoyageSpGetQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var user = _userManager.UserInfo();
                    var data = _voyageRepository.GetVoyage(request.StartDate,request.EndDate,request.SelectedDepartmentId,user.RoleId,user.UserId,request.ShowCompleted);
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
