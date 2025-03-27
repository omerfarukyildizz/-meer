using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Core.Features.Users;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Pages.Get
{ 
    public sealed record PageGetQuery(int departmentId) : IRequest<APIResponse>
    {
        internal sealed class PageGetQueryHandler : IRequestHandler<PageGetQuery, APIResponse>
        {
            private readonly IPageRepository _pageRepository;
            private readonly IMapper _mapper;
            private readonly IUserManager _userManager;
            private readonly IAuthorityRepository _authorityRepository;

            public PageGetQueryHandler(IMapper mapper, IPageRepository pageRepository, IUserManager userManager, IAuthorityRepository authorityRepository)
            {

                _mapper = mapper;
                _pageRepository = pageRepository;
                _userManager = userManager;
                _authorityRepository = authorityRepository;
            }

            public async Task<APIResponse> Handle(PageGetQuery request, CancellationToken cancellationToken)
            {
                try
                {

                    var dep  = _userManager.getAllDepartmans();
                    if (!dep.Contains(request.departmentId) && _userManager.UserInfo().RoleId != 1)
                    {
                        return new(status: StatusType.Error, messages: "You don't have a permission to view details in this department.", null);
                    }

                    var result = (from p in _pageRepository.GetAll()
                                  join a in _authorityRepository.GetAll() on p.PageId equals a.PageId into aGroup
                                  from a in aGroup.DefaultIfEmpty()
                                  where a.HasPermission == true 
                                                      && (_userManager.UserInfo().RoleId ==1 ? 1==1 : a.UserID == _userManager.UserInfo().UserId)
                                                      && ((request.departmentId>0 && _userManager.UserInfo().RoleId != 1) ? a.DepartmentId == request.departmentId : (1 == 1))
                                  select new
                                  {
                                      p.PageName,
                                      p.PageId,
                                  });

                    return new(status: StatusType.Success, messages: "", result.GroupBy(x => x.PageId).Select(g => g.FirstOrDefault())); ;

                 }
                catch (Exception ex)
                {
                    return new(status: StatusType.Error, messages: ex?.InnerException?.Message ?? ex?.Message, null);
                }
            }
        }

    }
}
