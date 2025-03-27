using AutoMapper;
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
 
    public sealed record VehicleGetTraillerQuery(int departmentId) : IRequest<APIResponse>
    {
        internal sealed class VehicleGetTraillerQueryHandler : IRequestHandler<VehicleGetTraillerQuery, APIResponse>
        {
            private readonly IVehicleRepository _vehicleRepository;
            private readonly IMapper _mapper;

            public VehicleGetTraillerQueryHandler(IVehicleRepository vehicleRepository, IMapper mapper)
            {
                _vehicleRepository = vehicleRepository;
                _mapper = mapper;
            }

            public async Task<APIResponse> Handle(VehicleGetTraillerQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    if (request.departmentId==0 || request.departmentId==null)
                    {
                        return new(status: StatusType.Error, messages: "Department Id is required.", null);
                    }
                    var data = _vehicleRepository.GetWhere(x=>x.VehicleTypeId==2 && x.Department.IsPassive==false && x.DepartmentId==request.departmentId).Select(vehicle => new
                    {
                       VehicleId=vehicle.VehicleId,
                       DepartmentId = vehicle.DepartmentId,
                       Plate=vehicle.Plate
                    }); 

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
