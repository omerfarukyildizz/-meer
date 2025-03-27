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
namespace Pbk.Core.Features.VtlAdditionals.Remove
{
 

    internal sealed class VtlAdditionalRemoveCommandHandler : IRequestHandler<VtlAdditionalRemoveCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly IVtlAdditionalRepository _vtlAdditionalRepository;
        private readonly IUnitOfWork _unitOfWork;

        public VtlAdditionalRemoveCommandHandler(ITranslate tanslate, IMapper mapper, IVtlAdditionalRepository vtlAdditionalRepository, IUnitOfWork unitOfWork)
        {
            _tanslate = tanslate;
            _vtlAdditionalRepository = vtlAdditionalRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<APIResponse> Handle(VtlAdditionalRemoveCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var data =  _vtlAdditionalRepository.GetWhere(w => w.ShipmentId == request.ShipmentId).FirstOrDefault();
                if (data == null)
                {
                    return new(status: OperationResult.Error, messages: "Kayıt bulunamadı", null);
                }

                _vtlAdditionalRepository.Remove(data);
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
