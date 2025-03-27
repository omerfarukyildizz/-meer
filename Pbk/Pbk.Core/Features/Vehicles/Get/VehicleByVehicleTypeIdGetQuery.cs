using Pbk.Core.Features.Response;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Vehicles.Get
{
   
    public sealed record VehicleByVehicleTypeIdGetQuery(int departmentId, int vehicleTypeId) : IRequest<APIResponse>
    {
        internal sealed class VehicleByVehicleTypeIdGetQueryHandler : IRequestHandler<VehicleByVehicleTypeIdGetQuery, APIResponse>
        {
            private readonly IVehicleRepository _vehicleRepository;
            private readonly IVehicleTypeRepository _vehicleTypeRepository;
            private readonly IDepartmentRepository _departmentRepository;

            public VehicleByVehicleTypeIdGetQueryHandler(IVehicleRepository vehicleRepository, IVehicleTypeRepository vehicleTypeRepository, IDepartmentRepository departmentRepository)
            {
                _vehicleRepository = vehicleRepository;
                _vehicleTypeRepository = vehicleTypeRepository;
                _departmentRepository = departmentRepository;
            }

            public async Task<APIResponse> Handle(VehicleByVehicleTypeIdGetQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    if (request.departmentId == null || request.departmentId == 0)
                    {
                        return new(status: StatusType.Error, messages: "Department boş olamaz.", null);

                    }
                    if (request.vehicleTypeId == null || request.vehicleTypeId == 0)
                    {
                        return new(status: StatusType.Error, messages: "VehicleType boş olamaz.", null);

                    }
                    var data = (from vehicle in _vehicleRepository.GetWhere(x => x.DepartmentId == request.departmentId
                                                              && x.VehicleTypeId == request.vehicleTypeId
                                                              && x.IsPassive == false)
                                join vehicleType in _vehicleTypeRepository.GetAll()
                                     on vehicle.VehicleTypeId equals vehicleType.VehicleTypeId
                                join department in _departmentRepository.GetAll()
                                     on vehicle.DepartmentId equals department.DepartmentId
                                select new
                                {
                                    VehicleId = vehicle.VehicleId,
                                    VehicleTypeId = vehicle.VehicleTypeId,
                                    VehicleTypeName = vehicleType.VehicleTypeName,
                                    Plate = vehicle.Plate,
                                    DepartmentId = vehicle.DepartmentId,
                                    DepartmentName = department.DepartmentName,
                                    DepartmentCode = department.Code
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
