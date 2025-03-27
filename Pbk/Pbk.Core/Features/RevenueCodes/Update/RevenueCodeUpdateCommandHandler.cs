using AutoMapper;
using Pbk.Core.Features.Locations.Create;
using Pbk.Core.Features.User;
using Pbk.Core.Features.Response;
using Pbk.Core.Utilities.IResults;
using Pbk.Entities.Repositories;
using MediatR;
using Pbk.Core.Features.Users;
using System.Drawing.Printing;
namespace Pbk.Core.Features.RevenueCodes.Update
{
    internal sealed class RevenueCodeUpdateCommandHandler : IRequestHandler<RevenueCodeUpdateCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IRevenueCodeRepository _revenueCodeRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;

        public RevenueCodeUpdateCommandHandler(ITranslate tanslate, IRevenueCodeRepository revenueCodeRepository, IMapper mapper, IUnitOfWork unitOfWork, IUserManager userManager)
        {
            _tanslate = tanslate;
            _revenueCodeRepository = revenueCodeRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<APIResponse> Handle(RevenueCodeUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var UserId = _userManager.UserInfo().UserId;

                Entities.Models.RevenueCode data = await _revenueCodeRepository.GetByIdAsync(w => w.RevenueCodeId == request.RevenueCodeId, cancellationToken);

                if (data == null)
                {
                    return new(status: OperationResult.Error, messages: "Kayıt Bulunamadı.", null);
                }

                data.UpdUser = UserId;
                data.UpdTime = DateTime.Now;

                _mapper.Map(request, data);
                _revenueCodeRepository.Update(data);
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

