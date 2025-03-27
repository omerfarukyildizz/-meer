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
using Microsoft.AspNetCore.Identity;
using Pbk.Core.Features.Users;
namespace Pbk.Core.Features.Authority.Update
{
 
    internal sealed class AuthorityUpdateCommandHandler : IRequestHandler<AuthorityUpdateCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly IAuthorityRepository _authorityRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;


        public AuthorityUpdateCommandHandler(IUserManager userManager, ITranslate tanslate, IMapper mapper, IAuthorityRepository authorityRepository, IUnitOfWork unitOfWork)
        {
            _tanslate = tanslate;
            _authorityRepository = authorityRepository;
            _mapper = mapper;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<APIResponse> Handle(AuthorityUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // isPermission kontrolü yapılacak

                var UserId = _userManager.UserInfo().UserId;

               Entities.Models.Authority data = await _authorityRepository.GetByIdAsync(w=> w.AuthorityID == request.AuthorityID, cancellationToken);
                   
                if(data == null)
                {
                    return new(status: OperationResult.Error, messages: "Kayıt Bulunamadı.", null);
                }

                  data.UpdUser = UserId;
                  data.UpdTime = DateTime.Now;

                 _mapper.Map(request, data);
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
