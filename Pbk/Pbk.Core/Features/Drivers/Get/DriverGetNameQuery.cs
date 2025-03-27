using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Entities.Dto;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Drivers.Get
{
 
    public sealed record DriverGetNameQuery(int departmentId) : IRequest<APIResponse>
    {
        internal sealed class DriverGetNameQueryHandler : IRequestHandler<DriverGetNameQuery, APIResponse>
        {
            private readonly IDriverRepository _driverRepository;
            private readonly IVehicleRepository _vehicleRepository;
            private readonly IDepartmentRepository _departmentRepository;
            private readonly IMapper _mapper;

            public DriverGetNameQueryHandler(IDriverRepository driverRepository, IMapper mapper, IVehicleRepository vehicleRepository, IDepartmentRepository departmentRepository)
            {
                _driverRepository = driverRepository;
                _mapper = mapper;
                _vehicleRepository = vehicleRepository;
                _departmentRepository = departmentRepository;
            }

            public async Task<APIResponse> Handle(DriverGetNameQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    
                    var data = (from driver in _driverRepository.GetWhere(w => w.IsPassive == false && w.DepartmentId == request.departmentId)
                                join department in _departmentRepository.GetAll()
                                    on driver.DepartmentId equals department.DepartmentId
                                select new
                                {
                                    DriverId = driver.DriverId,
                                    DriverName = driver.DriverName,
                                    DepartmentId = department.DepartmentId
                                })
                                .ToList();

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
