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

namespace Pbk.Core.Features.VehicleTypes.Get
{

    public sealed record VehicleTypesGetQuery : IRequest<APIResponse>
    {
        internal sealed class VehicleTypesGetQueryHandler : IRequestHandler<VehicleTypesGetQuery, APIResponse>
        {
            private readonly IVehicleTypeRepository _vehicleTypesRepository;
            private readonly IMapper _mapper;

            public VehicleTypesGetQueryHandler(IMapper mapper, IVehicleTypeRepository vehicleTypesRepository)
            {
                _mapper = mapper;
                _vehicleTypesRepository = vehicleTypesRepository;
            }

            public async Task<APIResponse> Handle(VehicleTypesGetQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var data = _mapper.Map<List<Pbk.Entities.Models.VehicleType>>(_vehicleTypesRepository.GetAll().ToList());
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
