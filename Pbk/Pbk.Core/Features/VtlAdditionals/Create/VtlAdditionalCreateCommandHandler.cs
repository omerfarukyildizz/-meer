using AutoMapper;
using Pbk.Core.Features.User;
using Pbk.Core.Features.Response;
using Pbk.Core.Utilities.IResults;
using Pbk.Entities.Repositories;
using MediatR;
using Pbk.Core.Features.Users;

namespace Pbk.Core.Features.VtlAdditionals.Create
{
    internal sealed class VtlAdditionalCreateCommandHandler : IRequestHandler<VtlAdditionalCreateCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly IVtlAdditionalRepository _vtlAdditionalRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;

        public VtlAdditionalCreateCommandHandler(IUserManager userManager, ITranslate tanslate, IMapper mapper, IVtlAdditionalRepository vtlAdditionalRepository, IUnitOfWork unitOfWork)
        {
            _tanslate = tanslate;
            _vtlAdditionalRepository = vtlAdditionalRepository;
            _mapper = mapper;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<APIResponse> Handle(VtlAdditionalCreateCommand request, CancellationToken cancellationToken)
        {
            try
            { 
                Entities.Models.VtlAdditional data = _mapper.Map<Entities.Models.VtlAdditional>(request);

                await _vtlAdditionalRepository.AddAsync(data, cancellationToken);
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
