using AutoMapper;
using Pbk.Core.Features.Parameters.Create;
using Pbk.Core.Features.User;
using Pbk.Core.Features.Response;
using Pbk.Core.Utilities.IResults;
using Pbk.Entities.Repositories;
using MediatR;
using Pbk.Core.Features.Users;
namespace Pbk.Core.Features.Parameters.Create
{
    internal sealed class ParameterCreateCommandHandler : IRequestHandler<ParameterCreateCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly IParameterRepository _parameterRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;

        public ParameterCreateCommandHandler(IUserManager userManager, ITranslate tanslate, IMapper mapper, IParameterRepository parameterRepository, IUnitOfWork unitOfWork)
        {
            _tanslate = tanslate;
            _parameterRepository = parameterRepository;
            _mapper = mapper;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<APIResponse> Handle(ParameterCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!_userManager.isPermesion("Parameters", "Get", null))
                {
                    return new(status: OperationResult.Error, messages: "Yetkiniz Yok.", null);
                }
                var UserId = _userManager.UserInfo().UserId;

                Entities.Models.Parameter data = _mapper.Map<Entities.Models.Parameter>(request);
                data.InsUser = UserId;
                data.InsTime = DateTime.Now;

                await _parameterRepository.AddAsync(data, cancellationToken);
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
