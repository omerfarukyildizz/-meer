using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Core.Features.Users;
using Pbk.Entities.Repositories;
using MediatR; 

namespace Pbk.Core.Features.Shipments.Get
{
    public sealed record ShipmentSpGetQuery(DateTime? StartDate, DateTime? EndDate, int? SelectedDepartmentId, bool ShowCompleted, int? planning, bool? isVTL) : IRequest<APIResponse>
    {
        internal sealed class ShipmentSpGetQueryHandler : IRequestHandler<ShipmentSpGetQuery, APIResponse>
        {
            private readonly IShipmentRepository _shipmentRepository;
            private readonly IUserManager _userManager;
            private readonly IMapper _mapper;

            public ShipmentSpGetQueryHandler(IShipmentRepository shipmentRepository, IMapper mapper, IUserManager userManager)
            {
                _shipmentRepository = shipmentRepository;
                _mapper = mapper;
                _userManager = userManager;
            }


            //Shipment Type Dropdown
            public async Task<APIResponse> Handle(ShipmentSpGetQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var user = _userManager.UserInfo();
                    var data = _shipmentRepository.GetShipment(request.StartDate, request.EndDate, request.SelectedDepartmentId, user.RoleId, user.UserId, request.ShowCompleted, request.planning ?? 0, request.isVTL ?? false);

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
