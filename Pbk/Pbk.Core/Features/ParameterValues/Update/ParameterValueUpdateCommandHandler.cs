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
namespace Pbk.Core.Features.ParameterValues.Update
{
 
    internal sealed class ParameterValueUpdateCommandHandler : IRequestHandler<ParameterValueUpdateCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly IParameterValueRepository _parameterValueRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;


        public ParameterValueUpdateCommandHandler(IUserManager userManager, ITranslate tanslate, IMapper mapper, IParameterValueRepository parameterValueRepository, IUnitOfWork unitOfWork)
        {
            _tanslate = tanslate;
            _parameterValueRepository = parameterValueRepository;
            _mapper = mapper;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<APIResponse> Handle(ParameterValueUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var UserId = _userManager.UserInfo().UserId;

               var data = await _parameterValueRepository.GetByIdAsync(w=> w.ParameterValueId == request.ParameterValueId, cancellationToken);
                   
                if(data == null)
                {
                    return new(status: OperationResult.Error, messages: "Kayıt Bulunamadı.", null);
                }

                  data.UpdUser = UserId;
                  data.UpdTime = DateTime.Now;

                 _mapper.Map(request, data);
                 _parameterValueRepository.Update(data);
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
