using AutoMapper;
using Pbk.Core.Features.Users.Manager;
using Pbk.Core.Features.Response;
using Pbk.Core.Utilities.IResults;
using Pbk.Entities.Repositories;
using MediatR;
using Pbk.Core.Features.Users.Manager;
using Pbk.Core.Features.User;
using Pbk.Core.Features.Users;
namespace Pbk.Core.Features.Authority.Create
{
    internal sealed class AuthorityCreateCommandHandler : IRequestHandler<AuthorityCreateCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly IAuthorityRepository _authorityRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;

        public AuthorityCreateCommandHandler(IUserManager userManager, ITranslate tanslate, IMapper mapper, IAuthorityRepository authorityRepository, IUnitOfWork unitOfWork)
        {
            _tanslate = tanslate;
            _authorityRepository = authorityRepository;
            _mapper = mapper;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<APIResponse> Handle(AuthorityCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var UserId = _userManager.UserInfo().UserId;
                var auth = _authorityRepository.GetWhere(
                    w => w.UserID == request.UserID &&
                    w.DepartmentId == request.DepartmentId &&
                    w.PageId == request.PageId &&
                    w.PagePermissionId == request.PagePermissionId  
                    ).FirstOrDefault();

                Entities.Models.Authority data = new Entities.Models.Authority() ;
                if (auth == null)
                {
                    data = _mapper.Map<Entities.Models.Authority>(request);
                    data.InsUser = UserId;
                    data.InsTime = DateTime.Now;
                    data.HasPermission = true;
                    await _authorityRepository.AddAsync(data, cancellationToken);
                }
                else
                {
                    data = auth;
                    data.HasPermission = !data.HasPermission;
                    data.UpdUser = UserId;
                    data.UpdTime = DateTime.Now;
                    _authorityRepository.Update(data);
                }

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
