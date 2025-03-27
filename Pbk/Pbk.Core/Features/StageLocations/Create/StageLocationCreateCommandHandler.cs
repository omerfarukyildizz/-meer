using AutoMapper;
using Pbk.Core.Features.StageLocations.Create;
using Pbk.Core.Features.User;
using Pbk.Core.Features.Response;
using Pbk.Core.Utilities.IResults;
using Pbk.Entities.Repositories;
using MediatR;
using Pbk.Core.Features.Users.Manager;
using Pbk.Core.Features.Users;
namespace Pbk.Core.Features.StageLocations.Create
{
    internal sealed class StageLocationCreateCommandHandler : IRequestHandler<StageLocationCreateCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly IStageLocationRepository _stageLocationRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;

        public StageLocationCreateCommandHandler(IUserManager userManager, ITranslate tanslate, IMapper mapper, IStageLocationRepository stageLocationRepository, IUnitOfWork unitOfWork)
        {
            _tanslate = tanslate;
            _stageLocationRepository = stageLocationRepository;
            _mapper = mapper;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<APIResponse> Handle(StageLocationCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var UserId = _userManager.UserInfo().UserId;

                Entities.Models.StageLocation data = _mapper.Map<Entities.Models.StageLocation>(request);
                data.InsUser = UserId;
                data.InsTime = DateTime.Now;

                await _stageLocationRepository.AddAsync(data, cancellationToken);
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
