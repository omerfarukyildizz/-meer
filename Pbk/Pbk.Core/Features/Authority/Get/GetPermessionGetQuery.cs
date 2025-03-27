using Pbk.Core.Features.Response;
using Pbk.Core.Features.Users;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Authority.Get
{
   

    public sealed record GetPermessionGetQuery(int pageId,string permessionType) : IRequest<APIResponse>
    {
        internal sealed class GetPermessionGetQueryHandler : IRequestHandler<GetPermessionGetQuery, APIResponse>
        {
            private readonly IAuthorityRepository _authorityRepository;
            private readonly IDepartmentRepository _departmentRepository;
            private readonly IPagePermissionRepository _pagePermissionRepository;
            private readonly IUserManager _userManager;
            public GetPermessionGetQueryHandler(IAuthorityRepository authorityRepository, IDepartmentRepository departmentRepository, IPagePermissionRepository pagePermissionRepository, IUserManager userManager)
            {
                _authorityRepository = authorityRepository;
                _departmentRepository = departmentRepository;
                _pagePermissionRepository = pagePermissionRepository;
                _userManager = userManager;
            }

            public async Task<APIResponse> Handle(GetPermessionGetQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var user = _userManager.UserInfo();
                    var data = (from authority in _authorityRepository.GetAll()
                                  join department in _departmentRepository.GetAll()
                                  on authority.DepartmentId equals department.DepartmentId
                                  join pagePermission in _pagePermissionRepository.GetAll()
                                  on authority.PagePermissionId equals pagePermission.PagePermissionId
                                  where authority.UserID == user.UserId
                                        && authority.PageId == request.pageId
                                        && pagePermission.PermissionType == request.permessionType
                                select new
                                  {
                                      authority.DepartmentId,
                                      department.Code
                                  }).Distinct().ToList();

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
