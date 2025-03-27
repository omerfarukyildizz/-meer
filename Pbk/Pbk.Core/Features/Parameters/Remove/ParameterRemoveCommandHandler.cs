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
using Pbk.Core.Features.Parameters.Remove;
using Pbk.Core.Features.Users;
namespace Pbk.Core.Features.Parameters.Remove
{
 

    internal sealed class ParameterRemoveCommandHandler : IRequestHandler<ParameterRemoveCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly IUserManager _userManager;
        private readonly IParameterRepository _parameterRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ParameterRemoveCommandHandler(ITranslate tanslate, IMapper mapper, IParameterRepository parameterRepository, IUnitOfWork unitOfWork, IUserManager userManager)
        {
            _tanslate = tanslate;
            _parameterRepository = parameterRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<APIResponse> Handle(ParameterRemoveCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var data =  _parameterRepository.GetWhere(w => w.ParameterId == request.ParameterId).FirstOrDefault();
                if (!_userManager.isPermesion("Parameters", "Get", null))
                {
                    return new(status: OperationResult.Error, messages: "Yetkiniz Yok.", null);
                }
                if (data == null)
                {
                    return new(status: OperationResult.Error, messages: "Kayıt bulunamadı", null);
                }

                _parameterRepository.Remove(data);
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
