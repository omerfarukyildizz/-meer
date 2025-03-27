using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Core.Features.Users;
using Pbk.Entities.Dto.Deparment;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Departments.Get
{

    public sealed record DepartmentNamePlanningGetQuery(string? search) : IRequest<APIResponse>
    {
        internal sealed class DepartmentNameGetQueryHandler : IRequestHandler<DepartmentNamePlanningGetQuery, APIResponse>
        {
            private readonly IDepartmentRepository _departmentRepository;
            private readonly IMapper _mapper;

            public DepartmentNameGetQueryHandler(IDepartmentRepository departmentRepository, IMapper mapper)
            {
                _departmentRepository = departmentRepository;
                _mapper = mapper;
            }

            //Planning Department Dropdown
            public async Task<APIResponse> Handle(DepartmentNamePlanningGetQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var data = (from department in _departmentRepository.GetWhere(w => w.IsPassive == false)
                                where (string.IsNullOrWhiteSpace(request.search) && department.IsPassive == false)
                                      || (!string.IsNullOrWhiteSpace(request.search) && department.DepartmentName.StartsWith(request.search))
                                select new
                                {
                                    DepartmentId = department.DepartmentId,
                                    DepartmentName = department.DepartmentName,
                                    DepartmentCode = department.Code
                                }).Take(string.IsNullOrWhiteSpace(request.search) ? 500 : int.MaxValue).ToList();

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
