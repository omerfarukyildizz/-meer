using AutoMapper;
using Pbk.Core.Features.Documents.Create;
using Pbk.Core.Features.User;
using Pbk.Core.Features.Response;
using Pbk.Core.Utilities.IResults;
using Pbk.Entities.Repositories;
using MediatR;
using Pbk.Core.Features.Users.Manager;
using Pbk.Core.Features.Users;
namespace Pbk.Core.Features.Documents.Create
{
    internal sealed class DocumentCreateCommandHandler : IRequestHandler<DocumentCreateCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly IDocumentRepository _documentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;

        public DocumentCreateCommandHandler(IUserManager userManager, ITranslate tanslate, IMapper mapper, IDocumentRepository documentRepository, IUnitOfWork unitOfWork)
        {
            _tanslate = tanslate;
            _documentRepository = documentRepository;
            _mapper = mapper;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<APIResponse> Handle(DocumentCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var UserId = _userManager.UserInfo().UserId;

                Entities.Models.Document data = _mapper.Map<Entities.Models.Document>(request);
                data.InsUser = UserId;
                data.InsTime = DateTime.Now;

                await _documentRepository.AddAsync(data, cancellationToken);
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
