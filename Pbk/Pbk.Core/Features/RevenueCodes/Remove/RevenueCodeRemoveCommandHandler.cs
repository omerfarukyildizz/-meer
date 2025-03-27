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
using Pbk.Core.Features.Drivers.Remove;
namespace Pbk.Core.Features.RevenueCodes.Remove
{
 

    internal sealed class RevenueCodeRemoveCommandHandler : IRequestHandler<RevenueCodeRemoveCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly IRevenueCodeRepository _revenueCodeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RevenueCodeRemoveCommandHandler(ITranslate tanslate, IMapper mapper, IRevenueCodeRepository revenueCodeRepository, IUnitOfWork unitOfWork)
        {
            _tanslate = tanslate;
            _mapper = mapper;
            _revenueCodeRepository = revenueCodeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<APIResponse> Handle(RevenueCodeRemoveCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var data = _revenueCodeRepository.GetWhere(w => w.RevenueCodeId == request.RevenueCodeId).FirstOrDefault();
                if (data == null)
                {
                    return new(status: OperationResult.Error, messages: "Kayıt bulunamadı", null);
                }

                _revenueCodeRepository.Remove(data);
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
