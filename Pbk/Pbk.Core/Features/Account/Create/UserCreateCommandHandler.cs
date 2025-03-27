using AutoMapper;
using Pbk.Core.Features.Drivers.Create;
using Pbk.Core.Features.User;
using Pbk.Core.Features.Response;
using Pbk.Core.Utilities.IResults;
using Pbk.Entities.Repositories;
using MediatR;
using Pbk.Core.Features.Users;
using System.Runtime.CompilerServices;
namespace Pbk.Core.Features.Account.Create
{
    internal sealed class UserCreateCommandHandler : IRequestHandler<UserCreateCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;
        private readonly IAuthorityRepository _authority;

        public UserCreateCommandHandler(IAuthorityRepository authority,IUserManager userManager, ITranslate tanslate, IMapper mapper, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _tanslate = tanslate;
            _userRepository = userRepository;
            _mapper = mapper;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _authority = authority;
        }

        public async Task<APIResponse> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var UserId = _userManager.UserInfo().UserId;

                /**
                  var perms = _authority.GetWhere(w => w.UserID == UserId && w.PageName == "Users" && w.PermissionType == "Users.Create" && w.HasPermission == true).FirstOrDefault();
                  if(perms == null)
                  return new(status: OperationResult.Error, messages: "Bu işlemi yapmak için yetkiniz bulunmamaktadır  - Users.Create ", null);
                */

                Entities.Models.User data = _mapper.Map<Entities.Models.User>(request);
                data.IsPassive = false;
                data.InsUser = UserId;
                data.InsTime = DateTime.Now;
 

                await _userRepository.AddAsync(data, cancellationToken);
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
