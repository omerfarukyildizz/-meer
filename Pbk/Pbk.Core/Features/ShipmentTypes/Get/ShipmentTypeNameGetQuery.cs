using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.ShipmentTypes.Get
{
    public sealed record ShipmentTypeNameGetQuery(string? search) : IRequest<APIResponse>
    {
        internal sealed class ShipmentTypeNameGetQueryHandler : IRequestHandler<ShipmentTypeNameGetQuery, APIResponse>
        {
            private readonly IShipmentTypeRepository _shipmentTypeRepository;
            private readonly IMapper _mapper;

            public ShipmentTypeNameGetQueryHandler(IShipmentTypeRepository shipmentTypeRepository, IMapper mapper)
            {
                _shipmentTypeRepository = shipmentTypeRepository;
                _mapper = mapper;
            }

            //Shipment Type Dropdown
            public async Task<APIResponse> Handle(ShipmentTypeNameGetQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var data = (from shipmenttype in _shipmentTypeRepository.GetAll()
                                where string.IsNullOrWhiteSpace(request.search) 
                                      || (!string.IsNullOrWhiteSpace(request.search) && shipmenttype.ShipmentTypeName.StartsWith(request.search))
                                select new
                                {
                                    ShipmentTypeId= shipmenttype.ShipmentTypeId,
                                    ShipmentTypeName= shipmenttype.ShipmentTypeName
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
