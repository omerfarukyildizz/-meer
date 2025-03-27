using AutoMapper;
using Pbk.Core.Features.Shipments.Create;
using Pbk.Core.Features.User;
using Pbk.Core.Features.Response;
using Pbk.Core.Utilities.IResults;
using Pbk.Entities.Repositories;
using MediatR;
using Pbk.Core.Features.Users.Manager;
using Pbk.Core.Features.Users;
using Pbk.Core.Features.Users.Manager;
using Pbk.Core.Features.Users;
using Pbk.Core.Features.Stages.Create;
namespace Pbk.Core.Features.Shipments.Create
{
    internal sealed class ShipmentCreateCommandHandler : IRequestHandler<ShipmentCreateCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;
        private readonly IMediator _mediator;

        public ShipmentCreateCommandHandler(IUserManager userManager, ITranslate tanslate, IMapper mapper, IShipmentRepository shipmentRepository, IUnitOfWork unitOfWork, IMediator mediator)
        {
            _tanslate = tanslate;
            _shipmentRepository = shipmentRepository;
            _mapper = mapper;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        public async Task<APIResponse> Handle(ShipmentCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {

                if (!_userManager.isPermesion("Shipments", "Create", request.DepartmentId))
                {
                    return new(status: OperationResult.Error, messages: "Yetkiniz Yok.", null);
                }


                var UserId = _userManager.UserInfo().UserId;

                Entities.Models.Shipment data = _mapper.Map<Entities.Models.Shipment>(request);
                data.InsUser = UserId;
                data.InsTime = DateTime.Now;
                data.IsPassive = false;
                data.Volume = ((request.Length ?? 0) * (request.Width ?? 0) * (request.Height ?? 0) / 1000000);
                await _shipmentRepository.AddAsync(data, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                 return new(status: OperationResult.Success, messages: "", data);
            }
            catch (Exception ex)
            {
                return new(status: OperationResult.Error, messages: ex.Message, null);
            }

        }

    }



}
