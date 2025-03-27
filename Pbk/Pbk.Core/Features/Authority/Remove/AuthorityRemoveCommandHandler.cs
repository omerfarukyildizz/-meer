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
namespace Pbk.Core.Features.Authority.Remove
{
 

    internal sealed class AuthorityRemoveCommandHandler : IRequestHandler<AuthorityRemoveCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly IAuthorityRepository _authorityRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;

        public AuthorityRemoveCommandHandler(ITranslate tanslate, IMapper mapper, IAuthorityRepository authorityRepository, IUnitOfWork unitOfWork, IUserManager userManager)
        {
            _tanslate = tanslate;
            _authorityRepository = authorityRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<APIResponse> Handle(AuthorityRemoveCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var data =  _authorityRepository.GetWhere(w => w.AuthorityID == request.AuthorityID).FirstOrDefault();
                if (data == null)
                {
                    return new(status: OperationResult.Error, messages: "Kayıt bulunamadı", null);
                }
                var user = _userManager.UserInfo().UserId;
                data.UpdTime = DateTime.Now;
                data.UpdUser = user;
                data.HasPermission = false;
                _authorityRepository.Update(data);
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
