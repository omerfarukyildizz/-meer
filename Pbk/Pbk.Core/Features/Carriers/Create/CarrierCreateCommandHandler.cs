using AutoMapper;
using Pbk.Core.Features.Carriers.Create;
using Pbk.Core.Features.User;
using Pbk.Core.Features.Response;
using Pbk.Core.Utilities.IResults;
using Pbk.Entities.Repositories;
using MediatR;
using Pbk.Core.Features.Users.Manager;
 
using Pbk.Core.Features.Users.Manager;
using Pbk.Core.Features.Users;
namespace Pbk.Core.Features.Carriers.Create
{
    internal sealed class CarrierCreateCommandHandler : IRequestHandler<CarrierCreateCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly ICarrierRepository _carrierRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;

        public CarrierCreateCommandHandler(IUserManager userManager, ITranslate tanslate, IMapper mapper, ICarrierRepository carrierRepository, IUnitOfWork unitOfWork)
        {
            _tanslate = tanslate;
            _carrierRepository = carrierRepository;
            _mapper = mapper;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<APIResponse> Handle(CarrierCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!_userManager.isPermesion("Carriers", "Create", request.DepartmentId))
                {
                    return new(status: OperationResult.Error, messages: "Yetkiniz Yok.", null);
                }

                bool checkTimocomId = _carrierRepository.GetWhere(x => x.TimocomId == request.TimocomId && x.TimocomId!=null).Any();
                if (checkTimocomId)
                {
                    return new(status: OperationResult.Error, messages: "This TimocomId already exist", null);
                }

                bool SAPAccountCodeCheck = _carrierRepository.GetWhere(x => x.SAPAccountCode == request.SAPAccountCode && x.SAPAccountCode != null).Any();
                if (SAPAccountCodeCheck)
                {
                    return new(status: OperationResult.Error, messages: "This SAPAccountCode already exist", null);
                }


                var UserId = _userManager.UserInfo().UserId;

                Entities.Models.Carrier data = _mapper.Map<Entities.Models.Carrier>(request);
                data.InsUser = UserId;
                data.InsTime = DateTime.Now;
                data.IsPassive = false;

                await _carrierRepository.AddAsync(data, cancellationToken);
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
