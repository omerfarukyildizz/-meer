using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Entities.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Vehicles.Get
{

    public sealed record VehicleGetTruckQuery(int departmentId) : IRequest<APIResponse>
    {
        internal sealed class VehicleGetTruckQueryHandler : IRequestHandler<VehicleGetTruckQuery, APIResponse>
        {
            private readonly IVehicleRepository _vehicleRepository;
            private readonly IVehicleTypeRepository _vehicleTypeRepository;
            private readonly IDriverRepository _driverRepository;
            private readonly IMapper _mapper;

            public VehicleGetTruckQueryHandler(IVehicleRepository vehicleRepository, IMapper mapper, IVehicleTypeRepository vehicleTypeRepository, IDriverRepository driverRepository)
            {
                _vehicleRepository = vehicleRepository;
                _mapper = mapper;
                _vehicleTypeRepository = vehicleTypeRepository;
                _driverRepository = driverRepository;
            }

            public async Task<APIResponse> Handle(VehicleGetTruckQuery request, CancellationToken cancellationToken)
            {
                try
                {

                    var data = _vehicleRepository
                    .GetWhere(x => x.VehicleTypeId == 1 &&
                                x.Department.IsPassive == false &&
                                x.DepartmentId == request.departmentId)
                    .Include(x => x.Department)  // Department ilişkisini dahil et
                    .Include(x => x.Driver)      // Driver ilişkisini dahil et
                    .Select(vehicle => new
                    {
                        VehicleId = vehicle.VehicleId,
                        DepartmentId = vehicle.DepartmentId,
                        Plate = vehicle.Plate,
                        DriverId = vehicle.Driver != null ? vehicle.Driver.DriverId :0,
                        DriverName = vehicle.Driver != null ? vehicle.Driver.DriverName : null
                    })
                    .ToList();
                    return new(status: StatusType.Success, messages: "", data.ToList());

                }
                catch (Exception ex)
                {
                    return new(status: StatusType.Error, messages: ex?.InnerException?.Message ?? ex?.Message, null);
                }
            }
        }

    }
}
