using AutoMapper;
using Pbk.Core.Features.Vehicles.Create;
using Pbk.Core.Features.User;
using Pbk.Core.Features.Response;
using Pbk.Core.Utilities.IResults;
using Pbk.Entities.Repositories;
using MediatR;
using Pbk.Core.Features.Users;
namespace Pbk.Core.Features.Vehicles.Create
{
    internal sealed class VehicleCreateCommandHandler : IRequestHandler<VehicleCreateCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly IVehicleRepository _vehicleRepository;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;

        public VehicleCreateCommandHandler(IUserManager userManager, ITranslate tanslate, IMapper mapper, IVehicleRepository vehicleRepository, IUnitOfWork unitOfWork)
        {
            _tanslate = tanslate;
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<APIResponse> Handle(VehicleCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var plateCheck = _vehicleRepository.GetWhere(x => x.Plate == request.Plate).Count();
                // Plate uniq kontrolü
                if (plateCheck > 0)
                {
                    return new(status: OperationResult.Error, messages: "Plate must be uniq.", null);
                }

                var UserId = _userManager.UserInfo().UserId;

                Entities.Models.Vehicle data = _mapper.Map<Entities.Models.Vehicle>(request);
                data.InsUser = UserId;
                data.InsTime = DateTime.Now;
                data.IsPassive = false;

              

                await _vehicleRepository.AddAsync(data, cancellationToken);
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
