using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Core.Features.Users;
using Pbk.Core.Utilities.Uniq;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Departments.Get
{
 

    public sealed record DepartmentGetByRoleIdQuery(string? search) : IRequest<APIResponse>
    {
        internal sealed class DepartmentGetByRoleIdQueryHandler : IRequestHandler<DepartmentGetByRoleIdQuery, APIResponse>
        {
            private readonly IDepartmentRepository _departmentRepository;
            private readonly IUserRepository _userRepository;
            private readonly IAuthorityRepository _authorityRepository;
            private readonly IPagePermissionRepository _pagePermissionRepository;
            private readonly IUserManager _userManager;
            private readonly IMapper _mapper;

            public DepartmentGetByRoleIdQueryHandler(IDepartmentRepository departmentRepository, IPagePermissionRepository pagePermissionRepository, IUserManager userManager, IMapper mapper, IUserRepository userRepository, IAuthorityRepository authorityRepository)
            {
                _departmentRepository = departmentRepository;
                _pagePermissionRepository = pagePermissionRepository;
                _userManager = userManager;
                _mapper = mapper;
                _userRepository = userRepository;
                _authorityRepository = authorityRepository;
            }



            //Create için DepartmentName
            public async Task<APIResponse> Handle(DepartmentGetByRoleIdQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var user = _userManager.UserInfo();  
                    bool isAdmin = user.RoleId == 1;   
                    if (isAdmin)
                    {
                        var list = _departmentRepository.GetWhere(w => w.IsPassive == false).Select(x => new
                        {
                            x.DepartmentId,
                            x.DepartmentName,
                            x.Code
                        }).ToList();

                        return new(status: StatusType.Success, messages: "", list);  
                    }



                    // Ortak sorgu başlatılıyor.
                    var query = from authority in _authorityRepository.GetAll()
                                join department in _departmentRepository.GetAll()
                                on authority.DepartmentId equals department.DepartmentId into deptGroup
                                from dept in deptGroup.DefaultIfEmpty()
                                select new
                                {
                                    dept.DepartmentId,
                                    dept.DepartmentName,
                                    dept.Code,
                                    authority.PageId,
                                    authority.PagePermissionId,
                                    authority.UserID
                                };

                    // Role'e göre filtre uygulanıyor.
                    
                        var userDep = _userManager.getAllDepartmans();
                        query = query.Where(w => userDep.Contains(w.DepartmentId));
                     

                    // Ortak filtreler uygulanıyor.
                    if(!string.IsNullOrEmpty(request.search))
                    query = query.Where(x => Regex_Helper.IsNumber(request.search ?? "") ? x.DepartmentId ==  Convert.ToInt32( request.search)  :   
                                             x.DepartmentName.StartsWith(request.search));

                    // Sonuç alınıyor.
                    var data = query
                               .Distinct()
                               .Take(string.IsNullOrWhiteSpace(request.search) ? 500 : int.MaxValue)
                               .Select(x => new
                               {
                                   x.DepartmentId,
                                   x.DepartmentName,
                                   x.Code
                               })
                               .Distinct()
                               .ToList();

                    return new(status: StatusType.Success, messages: "", data); // Başarılı sonuç döndürülüyor.
                }
                catch (Exception ex)
                {
                    return new(status: StatusType.Error, messages: ex.Message, data: null); // Hata durumunda hata mesajı döndürülüyor.
                }

            }
        }
    }
}
