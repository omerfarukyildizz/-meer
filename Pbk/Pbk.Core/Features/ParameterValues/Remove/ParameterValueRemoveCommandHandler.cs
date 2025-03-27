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
namespace Pbk.Core.Features.ParameterValues.Remove
{
 

    internal sealed class ParameterValueRemoveCommandHandler : IRequestHandler<ParameterValueRemoveCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly IParameterValueRepository _parameterValueRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ParameterValueRemoveCommandHandler(ITranslate tanslate, IMapper mapper, IParameterValueRepository parameterValueRepository, IUnitOfWork unitOfWork)
        {
            _tanslate = tanslate;
            _parameterValueRepository = parameterValueRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<APIResponse> Handle(ParameterValueRemoveCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var data =  _parameterValueRepository.GetWhere(w => w.ParameterValueId == request.ParameterValueId).FirstOrDefault();
                if (data == null)
                {
                    return new(status: OperationResult.Error, messages: "Kayıt bulunamadı", null);
                }

                _parameterValueRepository.Remove(data);
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
