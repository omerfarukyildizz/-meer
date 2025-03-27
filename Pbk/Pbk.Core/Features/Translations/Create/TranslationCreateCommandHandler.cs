using AutoMapper;
using Pbk.Core.Features.Translations.Create;
using Pbk.Core.Features.User;
using Pbk.Core.Features.Response;
using Pbk.Core.Utilities.IResults;
using Pbk.Entities.Repositories;
using MediatR;
using Pbk.Core.Features.Users;
namespace Pbk.Core.Features.Translations.Create
{
    internal sealed class TranslationCreateCommandHandler : IRequestHandler<TranslationCreateCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly ITranslationRepository _translationRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;

        public TranslationCreateCommandHandler(IUserManager userManager, ITranslate tanslate, IMapper mapper, ITranslationRepository translationRepository, IUnitOfWork unitOfWork)
        {
            _tanslate = tanslate;
            _translationRepository = translationRepository;
            _mapper = mapper;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<APIResponse> Handle(TranslationCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var UserId = _userManager.UserInfo().UserId;

                Entities.Models.Translation data = _mapper.Map<Entities.Models.Translation>(request);
                data.InsUserId = UserId;
                data.InsDate = DateTime.Now;

                await _translationRepository.AddAsync(data, cancellationToken);
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
