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

namespace Pbk.Core.Features.Vehicles.Get
{


    public sealed record VehicleGetDtoQuery(int? departmentId, int? vehicleTypeId,int? carrierId) : IRequest<APIResponse>
    {
        internal sealed class VehicleGetDtoQueryHandler : IRequestHandler<VehicleGetDtoQuery, APIResponse>
        {
            private readonly IVehicleRepository _vehicleRepository;
            private readonly IVehicleTypeRepository _vehicleTypeRepository;
            private readonly IMapper _mapper;

            public VehicleGetDtoQueryHandler(IMapper mapper, IVehicleRepository vehicleRepository, IVehicleTypeRepository vehicleTypeRepository)
            {
                _mapper = mapper;
                _vehicleRepository = vehicleRepository;
                _vehicleTypeRepository = vehicleTypeRepository;
            }

            public async Task<APIResponse> Handle(VehicleGetDtoQuery request, CancellationToken cancellationToken)
            {
                 
                try
                {
                    if (request.carrierId.HasValue)
                    {
                        var data = (from vehicle in _vehicleRepository.GetWhere(x => x.CarrierId == request.carrierId && x.IsPassive == false) 
                                    select new GetVehicleDto
                                    {
                                        VehicleId = vehicle.VehicleId,
                                        VehicleTypeName = null,
                                        Plate = vehicle.Plate,
                                       
                                    }).ToList();

                        return new(status: StatusType.Success, messages: "", data);
                    }
                    else
                    {
                        var data = (from vehicletype in _vehicleTypeRepository.GetWhere(x => x.VehicleTypeId == request.vehicleTypeId)
                                    join vehicle in _vehicleRepository.GetWhere(x => x.VehicleTypeId == request.vehicleTypeId && x.Driver == null)
                                    on vehicletype.VehicleTypeId equals vehicle.VehicleTypeId
                                    where
                                   ((!request.departmentId.HasValue || vehicle.DepartmentId == request.departmentId) && vehicle.Driver == null)
                                    select new GetVehicleDto
                                    {
                                        VehicleId = vehicle.VehicleId,
                                        VehicleTypeName = vehicletype.VehicleTypeName,
                                        Plate = vehicle.Plate
                                    }).ToList();

                        return new(status: StatusType.Success, messages: "", data);

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
