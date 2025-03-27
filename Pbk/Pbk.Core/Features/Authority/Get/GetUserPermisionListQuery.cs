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

    public sealed record GetUserPermisionListQuery() : IRequest<APIResponse>
    {
        internal sealed class GetUserPermisionListQueryHandler : IRequestHandler<GetUserPermisionListQuery, APIResponse>
        {
            private readonly IAuthorityRepository _authorityRepository;
            private readonly IDepartmentRepository _departmentRepository;
            private readonly IPagePermissionRepository _pagePermissionRepository;
            private readonly IPageRepository _pageRepository;
            private readonly IUserManager _userManager;
            public GetUserPermisionListQueryHandler(IAuthorityRepository authorityRepository, IDepartmentRepository departmentRepository, IPagePermissionRepository pagePermissionRepository, IUserManager userManager, IPageRepository pageRepository)
            {
                _authorityRepository = authorityRepository;
                _departmentRepository = departmentRepository;
                _pagePermissionRepository = pagePermissionRepository;
                _userManager = userManager;
                _pageRepository = pageRepository;
            }

            public async Task<APIResponse> Handle(GetUserPermisionListQuery request, CancellationToken cancellationToken)
            {
 
                try
                {
                    var user = _userManager.UserInfo();
                    var data = (from authority in _authorityRepository.GetAll()
                                join department in _departmentRepository.GetAll()
                                on authority.DepartmentId equals department.DepartmentId
                                join page in _pageRepository.GetAll()
                                on  authority.PageId equals page.PageId
                                join pagePermission in _pagePermissionRepository.GetAll()
                                on authority.PagePermissionId equals pagePermission.PagePermissionId
                                where authority.UserID == user.UserId && authority.HasPermission == true

                                select new
                                {
                                    DepartmanId =  authority.DepartmentId,
                                    PageName = page.PageName,
                                    pagePermission.PermissionType
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
