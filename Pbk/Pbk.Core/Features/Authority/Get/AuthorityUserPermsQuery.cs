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
   

    public sealed record AuthorityUserPermsQuery(int DepartmentId, int PagePermissionId) : IRequest<APIResponse>
    {

        internal sealed class AuthorityUserPermsQueryHandler : IRequestHandler<AuthorityUserPermsQuery, APIResponse>
        {
            private readonly IAuthorityRepository _authorityRepository;
            private readonly IUserManager _userManager;
            public AuthorityUserPermsQueryHandler(IAuthorityRepository authorityRepository, IUserManager userManager)
            {
                _authorityRepository = authorityRepository;
                _userManager = userManager;
            }

            public async Task<APIResponse> Handle(AuthorityUserPermsQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var user = _userManager.UserInfo();

                    if (user.RoleId == 1)
                    {
                        return new(status: StatusType.Success, messages: "", "OK");
                    }

                    var check = _authorityRepository.GetWhere(p =>
                    p.UserID == user.UserId &&
                    p.DepartmentId == request.DepartmentId &&
                    p.PagePermissionId == request.PagePermissionId &&
                    p.HasPermission == true).Count();

                    return new(status: check>0  ? StatusType.Success : StatusType.Error, messages: "", null);

                }
                catch (Exception ex)
                {
                    return new(status: StatusType.Error, messages: ex?.InnerException?.Message ?? ex?.Message, null);
                }
            }
        }
    }
}
