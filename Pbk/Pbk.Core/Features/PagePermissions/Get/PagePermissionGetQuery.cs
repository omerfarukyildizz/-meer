using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Core.Features.Users;
using Pbk.Entities.Dto.PagePermission;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.PagePermissions.Get
{

    public sealed record PagePermissionGetQuery(int UserId, int PageId, int DepartmentId) : IRequest<APIResponse>
    {
        internal sealed class PagePermissionGetQueryHandler : IRequestHandler<PagePermissionGetQuery, APIResponse>
        {
            private readonly IPagePermissionRepository _pagePermissionsRepository;
            private readonly IAuthorityRepository _authorityRepository;
            private readonly IMapper _mapper;
            private readonly IUserManager _userManager;

            public PagePermissionGetQueryHandler(IMapper mapper, IPagePermissionRepository pagePermissionsRepository, IAuthorityRepository authorityRepository, IUserManager userManager)
            {

                _mapper = mapper;
                _pagePermissionsRepository = pagePermissionsRepository;
                _authorityRepository = authorityRepository;
                _userManager = userManager;
            }

            public async Task<APIResponse> Handle(PagePermissionGetQuery request, CancellationToken cancellationToken)
            {
                try
                {

                    // &&  ag.DepartmentId ==request.DepartmentId && ag.UserID == request.UserId
                    var data = (from p in _pagePermissionsRepository.GetAll()
                                join a in _authorityRepository.GetWhere(w => w.DepartmentId == request.DepartmentId && w.UserID == request.UserId && w.HasPermission==true)
                                on p.PagePermissionId equals a.PagePermissionId into authorityGroup
                                from ag in authorityGroup.DefaultIfEmpty()
                                where p.PageId == request.PageId
                                select new GetPagePermissionWithPageDto
                                {
                                    PagePermissionId = p.PagePermissionId,
                                    PageId = p.PageId,
                                    DepartmentId = request.DepartmentId,
                                    UserID = request.UserId,
                                    PermissionType = p.PermissionType,
                                    InsUser = p.InsUser,
                                    InsTime = p.InsTime,
                                    isUserPermActive = ag != null ? 1 : 0
                                }).ToList();

                    if(_userManager.UserInfo().RoleId == 1)
                    {
                        return new(status: StatusType.Success, messages: "", data);
                    }


                    var kontrol = _authorityRepository.GetWhere(w => w.UserID == _userManager.UserInfo().UserId && w.DepartmentId ==request.DepartmentId && w.PageId == request.PageId && w.HasPermission == true)
                                                      .Select(w => w.PagePermissionId)
                                                      .ToHashSet();

                    var sonList = data.Where(w => kontrol.Contains(w.PagePermissionId)).ToList();


                    return new(status: StatusType.Success, messages: "", sonList);
                }
                catch (Exception ex)
                {
                    return new(status: StatusType.Error, messages: ex?.InnerException?.Message ?? ex?.Message, null);
                }
            }
        }

    }
}
