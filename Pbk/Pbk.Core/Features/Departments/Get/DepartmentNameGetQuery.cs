using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Core.Features.Users;
using Pbk.Core.Utilities.Uniq;
using Pbk.Entities.Dto.Deparment;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Pbk.Core.Features.Departments.Get
{

    public sealed record DepartmentNameGetQuery(string? search, string pageName, string PermissionType, int? departmentId,  bool allDepartman ) : IRequest<APIResponse>
    {
        internal sealed class DepartmentNameGetQueryHandler : IRequestHandler<DepartmentNameGetQuery, APIResponse>
        {
            private readonly IDepartmentRepository _departmentRepository;
            private readonly IUserRepository _userRepository;
            private readonly IAuthorityRepository _authorityRepository;
            private readonly IPagePermissionRepository _pagePermissionRepository;
           private readonly IPageRepository  _pageRepository;
            private readonly IUserManager _userManager;
            private readonly IMapper _mapper;

            public DepartmentNameGetQueryHandler(IDepartmentRepository departmentRepository, IPagePermissionRepository pagePermissionRepository, IUserManager userManager, IMapper mapper, IUserRepository userRepository, IAuthorityRepository authorityRepository, IPageRepository pageRepository)
            {
                _departmentRepository = departmentRepository;
                _pagePermissionRepository = pagePermissionRepository;
                _userManager = userManager;
                _mapper = mapper;
                _userRepository = userRepository;
                _authorityRepository = authorityRepository;
                _pageRepository = pageRepository;
            }



            //Create için DepartmentName
            public async Task<APIResponse> Handle(DepartmentNameGetQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var user = _userManager.UserInfo();
                    

                    if(user.RoleId == 1)
                    {
                        var result = _departmentRepository.GetWhere(w =>
                                  string.IsNullOrEmpty(request.search) || string.IsNullOrWhiteSpace(request.search)
                                      ? true
                                      : Regex_Helper.IsNumber(request.search ?? "")
                                          ? w.DepartmentId == Convert.ToInt32(request.search)
                                          : w.DepartmentName.StartsWith(request.search)
                              )
                              .Select(dept => new
                              {
                                  dept.DepartmentId,
                                  dept.DepartmentName,
                                  dept.Code
                              }).Distinct().ToList();
                                                    return new(status: StatusType.Success, messages: "", result);
                    }
                    else
                    {

                        var result = (from p in _pageRepository.GetAll()
                                      join pp in _pagePermissionRepository.GetAll() on p.PageId equals pp.PageId into ppGroup
                                      from pp in ppGroup.DefaultIfEmpty()
                                      join a in _authorityRepository.GetAll() on pp.PagePermissionId equals a.PagePermissionId into aGroup
                                      from a in aGroup.DefaultIfEmpty()
                                      join department in _departmentRepository.GetAll()
                                      on a.DepartmentId equals department.DepartmentId into deptGroup
                                      from dept in deptGroup.DefaultIfEmpty()
                                      where a.HasPermission ==true &&  p.PageName == request.pageName
                                                          && pp.PermissionType == request.PermissionType
                                                          && a.UserID == user.UserId
                                                          && (request.departmentId.HasValue ? a.DepartmentId == request.departmentId : (1 == 1))
                                      select new
                                      {
                                          dept.DepartmentId,
                                          dept.DepartmentName,
                                          dept.Code
                                      }).Distinct().ToList();

                        return new(status: StatusType.Success, messages: "", result);
                    }

                   
 
                }
                catch (Exception ex)
                {
                    return new(status: StatusType.Error, messages: ex?.InnerException?.Message ?? ex?.Message, null);
                }
            }
        }
    }
}


/* var user = _userManager.UserInfo().UserId;
                    var data = (from authority in _authorityRepository.GetAll()
                                join department in _departmentRepository.GetAll()
                                on authority.DepartmentId equals department.DepartmentId into deptGroup
                                from dept in deptGroup.DefaultIfEmpty()
                                where authority.PageId == 10 &&
                                      authority.PagePermissionId == 68 &&
                                      authority.UserID == user &&
                                      (string.IsNullOrEmpty(request.search) ||
                                                        dept.DepartmentName.StartsWith(request.search)) 
                                select new
                                {
                                    dept.DepartmentId,
                                    dept.DepartmentName,
                                    dept.Code
                                })
                                .Distinct().Take(string.IsNullOrWhiteSpace(request.search) ? 500 : int.MaxValue)
                                .ToList();
                    */
