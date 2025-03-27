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
using Pbk.Core.Features.Users.Manager;
using Pbk.Core.Features.Users;
using Pbk.Core.Features.Users.Manager;
using Pbk.Core.Features.Users;
namespace Pbk.Core.Features.Parameters.Update
{
 
    internal sealed class ParameterUpdateCommandHandler : IRequestHandler<ParameterUpdateCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly IParameterRepository _parameterRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;


        public ParameterUpdateCommandHandler(IUserManager userManager, ITranslate tanslate, IMapper mapper, IParameterRepository parameterRepository, IUnitOfWork unitOfWork)
        {
            _tanslate = tanslate;
            _parameterRepository = parameterRepository;
            _mapper = mapper;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<APIResponse> Handle(ParameterUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!_userManager.isPermesion("Parameters", "Get", null) )
                {
                    return new(status: OperationResult.Error, messages: "Yetkiniz Yok.", null);
                }
                var UserId = _userManager.UserInfo().UserId;

               Entities.Models.Parameter data = await _parameterRepository.GetByIdAsync(w=> w.ParameterId == request.ParameterId, cancellationToken);
                   
                if(data == null)
                {
                    return new(status: OperationResult.Error, messages: "Kayıt Bulunamadı.", null);
                }

                  data.UpdUser = UserId;
                  data.UpdTime = DateTime.Now;

                 _mapper.Map(request, data);
                 _parameterRepository.Update(data);
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
