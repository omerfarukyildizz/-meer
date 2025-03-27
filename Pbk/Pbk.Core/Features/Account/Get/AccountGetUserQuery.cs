using Pbk.Core.Features.Response;
using Pbk.Core.Features.Users;
using Pbk.Entities.Dto;
using Pbk.Entities.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Account.Get
{

    public sealed record AccountGetUserQuery(int? departmentId) : IRequest<APIResponse>
    {
        internal sealed class AccountGetUserQueryHandler : IRequestHandler<AccountGetUserQuery, APIResponse>
        {
            private readonly IUserRepository _userRepository;
            private readonly IUserManager _userManager;
            private readonly IDepartmentRepository _departmentRepository;
            private readonly IRoleRepository _roleRepository;
            public AccountGetUserQueryHandler(IUserRepository userRepository, IDepartmentRepository departmentRepository, IUserManager userManager, IRoleRepository roleRepository)
            {
                _userRepository = userRepository;
                _departmentRepository = departmentRepository;
                _userManager = userManager;
                _roleRepository = roleRepository;
            }

            public async Task<APIResponse> Handle(AccountGetUserQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    // Kullanıcı bilgilerini al
                    var roleId = _userManager.UserInfo().RoleId; // Kullanıcının rol bilgisi
                    var depList = _userManager.getDepartmansPagePerms("Users", "Get"); // Kullanıcının yetkili olduğu departmanlar

                    // Sorgu
                    var data = (from user in _userRepository.GetAll()
                                join department in _departmentRepository.GetAll()
                                on user.DepartmentId equals department.DepartmentId
                                join role in _roleRepository.GetAll()
                                on user.RoleId equals role.RoleId
                                where user.IsPassive == false &&
                                      (
                                          // Admin kullanıcılar için
                                          (roleId == 1 &&
                                           (!request.departmentId.HasValue || user.DepartmentId == request.departmentId.Value)) ||

                                          // Admin olmayan kullanıcılar için
                                          (roleId != 1 &&
                                           depList.Contains(user.DepartmentId) &&
                                           (!request.departmentId.HasValue || user.DepartmentId == request.departmentId.Value))
                                      )
                                select new
                                {
                                    UserId = user.UserId,
                                    DepartmentId = user.DepartmentId,
                                    DepartmentName = department.DepartmentName,
                                    DepartmentCode = department.Code,
                                    RoleId = user.RoleId,
                                    RoleName = role.RoleName,
                                    UserName = user.UserName,
                                    Password = user.Password,
                                    Position = user.Position,
                                    Email = user.Email,
                                    Phone = user.Phone,
                                    IsPassive = user.IsPassive,
                                    BarsisUserId = user.BarsisUserId,
                                    InsUser = user.InsUser,
                                    InsTime = user.InsTime,
                                    UpdTime = user.UpdTime,
                                    UpdUser = user.UpdUser
                                }).ToList();



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
