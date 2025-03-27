using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Core.Features.Users;
using Pbk.Core.Utilities.IResults;
using Pbk.Entities.Repositories;
using MediatR;

namespace Pbk.Core.Features.Locations.Get
{
    public sealed record LocationSourceAndTargetGetQuery(int shipmentId, string? search) : IRequest<APIResponse>
    {
        internal sealed class LocationSourceAndTargetGetQueryHandler : IRequestHandler<LocationSourceAndTargetGetQuery, APIResponse>
        {
            private readonly ILocationRepository _locationRepository;
            private readonly IMapper _mapper;
            private readonly IAuthorityRepository _authorityRepository;
            private readonly IUserManager _userManager;
            private readonly IDepartmentRepository _departmentRepository;
            private readonly IShipmentRepository _shipmentRepository;
            public LocationSourceAndTargetGetQueryHandler(
                IDepartmentRepository departmentRepository,
                 IUserManager userManager,
            IAuthorityRepository authorityRepository,
                ILocationRepository locationRepository, IMapper mapper, IShipmentRepository shipmentRepository)
            {
                _locationRepository = locationRepository;
                _mapper = mapper;
                _authorityRepository = authorityRepository;
                _userManager = userManager;
                _departmentRepository = departmentRepository;
                _shipmentRepository = shipmentRepository;
            }

            public async Task<APIResponse> Handle(LocationSourceAndTargetGetQuery request, CancellationToken cancellationToken)
            {
                try
                {
                   
                    var data = (from location in _locationRepository.GetWhere(w => w.IsPassive == false)
                                where location.DepartmentId == (
                                          from shipment in _shipmentRepository.GetAll()
                                          where shipment.ShipmentId == request.shipmentId
                                          select shipment.DepartmentId
                                      ).FirstOrDefault() &&
                                      (string.IsNullOrWhiteSpace(request.search) || location.LocationName.StartsWith(request.search))
                                select new
                                {
                                    location.LocationId,
                                    location.LocationName
                                })
                             .Take(string.IsNullOrWhiteSpace(request.search) ? 500 : int.MaxValue) // Eğer search boşsa 500 kayıt getir
                             .ToList();

                    return new(status: StatusType.Success, messages: "", data );


                }
                catch (Exception ex)
                {
                    return new(status: StatusType.Error, messages: ex?.InnerException?.Message ?? ex?.Message, null);
                }
            }
        }
    }
}
