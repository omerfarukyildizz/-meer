using AutoMapper;
using Pbk.Core.Features.CostItems.Create;
using Pbk.Core.Features.User;
using Pbk.Core.Features.Response;
using Pbk.Core.Utilities.IResults;
using Pbk.Entities.Repositories;
using MediatR;
using Pbk.Core.Features.Users.Manager;
using Pbk.Core.Features.Users;
namespace Pbk.Core.Features.CostItems.Create
{
    internal sealed class CostItemCreateCommandHandler : IRequestHandler<CostItemCreateCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly ICostItemRepository _costItemRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;

        public CostItemCreateCommandHandler(IUserManager userManager, ITranslate tanslate, IMapper mapper, ICostItemRepository costItemRepository, IUnitOfWork unitOfWork)
        {
            _tanslate = tanslate;
            _costItemRepository = costItemRepository;
            _mapper = mapper;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<APIResponse> Handle(CostItemCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var UserId = _userManager.UserInfo().UserId;

                if (!_userManager.isPermesion("CostItems", "Create", request.DepartmentId))
                {
                    return new(status: OperationResult.Error, messages: "Yetkiniz Yok.", null);
                }
                Entities.Models.CostItem data = _mapper.Map<Entities.Models.CostItem>(request);
                data.InsUser = UserId;
                data.InsTime = DateTime.Now;
                data.IsPassive = false;

                await _costItemRepository.AddAsync(data, cancellationToken);
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
