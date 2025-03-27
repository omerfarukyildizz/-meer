using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Core.Features.Users;
using Pbk.Entities.Dto;
using Pbk.Entities.Repositories;
using MediatR;

namespace Pbk.Core.Features.Departments.Get
{
    public sealed record DepertmentGetQuery : IRequest<APIResponse>
    {
        internal sealed class DepertmentGetQueryHandler : IRequestHandler<DepertmentGetQuery, APIResponse>
        {
            private readonly IDepartmentRepository _departmentRepository;
            private readonly IMapper _mapper;
            private readonly IUserManager _userManager;
            public DepertmentGetQueryHandler(IMapper mapper, IDepartmentRepository departmentRepository, IUserManager userManager)
            {
                _departmentRepository = departmentRepository;
                _mapper = mapper;
                _userManager = userManager;
            }

            public async Task<APIResponse> Handle(DepertmentGetQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var dep =  _userManager.getAllDepartmans();
                    var data = _departmentRepository.GetWhere(w => (_userManager.UserInfo().RoleId == 1) ? 1==1 :  dep.Contains(w.DepartmentId) && w.IsPassive==false);
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
