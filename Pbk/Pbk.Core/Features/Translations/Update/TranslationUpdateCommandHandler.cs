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
namespace Pbk.Core.Features.Translations.Update
{
 
    internal sealed class TranslationUpdateCommandHandler : IRequestHandler<TranslationUpdateCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly ITranslationRepository _translationRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;


        public TranslationUpdateCommandHandler(IUserManager userManager, ITranslate tanslate, IMapper mapper, ITranslationRepository translationRepository, IUnitOfWork unitOfWork)
        {
            _tanslate = tanslate;
            _translationRepository = translationRepository;
            _mapper = mapper;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<APIResponse> Handle(TranslationUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var UserId = _userManager.UserInfo().UserId;

               Entities.Models.Translation data = await _translationRepository.GetByIdAsync(w=> w.TranslateId == request.TranslateId, cancellationToken);
                   
                if(data == null)
                {
                    return new(status: OperationResult.Error, messages: "Kayıt Bulunamadı.", null);
                }

                  data.UpdUserId = UserId;
                  data.UpdDate = DateTime.Now;

                 _mapper.Map(request, data);
                 _translationRepository.Update(data);
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
