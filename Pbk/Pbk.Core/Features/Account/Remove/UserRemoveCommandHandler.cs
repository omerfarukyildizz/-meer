using AutoMapper;
using Pbk.Core.Features.User;
using Pbk.Core.Features.Response;
using Pbk.Core.Utilities.IResults;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pbk.Entities.Models;
using Pbk.Core.Features.Users;
namespace Pbk.Core.Features.Account.Remove
{
 

    internal sealed class UserRemoveCommandHandler : IRequestHandler<UserRemoveCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IUserManager _userManager;
        private readonly IUnitOfWork _unitOfWork;

        public UserRemoveCommandHandler(ITranslate tanslate, IMapper mapper, IUserRepository userRepository, IUnitOfWork unitOfWork, IUserManager userManager)
        {
            _tanslate = tanslate;
            _userRepository = userRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<APIResponse> Handle(UserRemoveCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var data =  _userRepository.GetWhere(w => w.UserId == request.UserId).FirstOrDefault();
                if (data == null)
                {
                    return new(status: OperationResult.Error, messages: "Kayıt bulunamadı", null);
                }
                var user = _userManager.UserInfo().UserId;

                data.IsPassive = true;
                data.UpdUser = user;
                data.UpdTime = DateTime.Now;

                _userRepository.Update(data);
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
