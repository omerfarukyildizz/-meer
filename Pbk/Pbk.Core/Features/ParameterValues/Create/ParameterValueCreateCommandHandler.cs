using AutoMapper;
using Pbk.Core.Features.Customers.Create;
using Pbk.Core.Features.User;
using Pbk.Core.Features.Response;
using Pbk.Core.Utilities.IResults;
using Pbk.Entities.Repositories;
using MediatR;
using Pbk.Core.Features.Users;
namespace Pbk.Core.Features.ParameterValues.Create
{
    internal sealed class ParameterValueCreateCommandHandler : IRequestHandler<ParameterValueCreateCommand, APIResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserManager _userManager;
        private readonly IParameterValueRepository _parameterValueRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ParameterValueCreateCommandHandler(IMapper mapper, IUserManager userManager, IParameterValueRepository parameterValueRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _userManager = userManager;
            _parameterValueRepository = parameterValueRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<APIResponse> Handle(ParameterValueCreateCommand request, CancellationToken cancellationToken)
        {
            try 
            {
                var UserId = _userManager.UserInfo().UserId;

                var data = _mapper.Map<Entities.Models.ParameterValue>(request);
                data.InsUser = UserId;
                data.InsTime = DateTime.Now;

                await _parameterValueRepository.AddAsync(data, cancellationToken);
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
