using AutoMapper;
using Pbk.Core.Features.Drivers.Create;
using Pbk.Core.Features.User;
using Pbk.Core.Features.Response;
using Pbk.Core.Utilities.IResults;
using Pbk.Entities.Repositories;
using MediatR;
using Pbk.Core.Features.Users;
namespace Pbk.Core.Features.Drivers.Create
{
    internal sealed class DriverCreateCommandHandler : IRequestHandler<DriverCreateCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly IDriverRepository _driverRepository;
       
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;

        public DriverCreateCommandHandler(IUserManager userManager, ITranslate tanslate, IMapper mapper, IDriverRepository driverRepository, IUnitOfWork unitOfWork)
        {
            _tanslate = tanslate;
            _driverRepository = driverRepository;
            _mapper = mapper;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<APIResponse> Handle(DriverCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!_userManager.isPermesion("Drivers", "Create", request.DepartmentId))
                {
                    return new(status: OperationResult.Error, messages: "Yetkiniz Yok.", null);
                }
                var integratedCheck = _driverRepository.GetWhere(x => x.IntegratedAccountCode == request.IntegratedAccountCode).Count();
                // IntegratedAccountCode uniq kontrolü
                if (integratedCheck > 0)
                {
                    return new(status: OperationResult.Error, messages: "IntegratedAccountCode must be uniq.", null);
                }


                var vclCheck = _driverRepository.GetWhere(x => x.VehicleId == request.VehicleId && x.IsPassive == false).Count();
                if(vclCheck > 0)
                {
                    return new(status: OperationResult.Error, messages: "VehicleId must be uniq.", null);
                }



                var UserId = _userManager.UserInfo().UserId;

                Entities.Models.Driver data = _mapper.Map<Entities.Models.Driver>(request);
                data.InsUser = UserId;
                data.InsTime = DateTime.Now;
                data.IsPassive = false;

                await _driverRepository.AddAsync(data, cancellationToken);
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
