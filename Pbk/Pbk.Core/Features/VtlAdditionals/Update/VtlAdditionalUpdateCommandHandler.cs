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
using Microsoft.AspNetCore.Identity;
namespace Pbk.Core.Features.VtlAdditionals.Update
{
 
    internal sealed class VtlAdditionalUpdateCommandHandler : IRequestHandler<VtlAdditionalUpdateCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly IVtlAdditionalRepository _vtlAdditionalRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;


        public VtlAdditionalUpdateCommandHandler(IUserManager userManager, ITranslate tanslate, IMapper mapper, IVtlAdditionalRepository vtlAdditionalRepository, IUnitOfWork unitOfWork)
        {
            _tanslate = tanslate;
            _vtlAdditionalRepository = vtlAdditionalRepository;
            _mapper = mapper;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<APIResponse> Handle(VtlAdditionalUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
               Entities.Models.VtlAdditional data = await _vtlAdditionalRepository.GetByIdAsync(w=> w.ShipmentId == request.ShipmentId, cancellationToken);
                   
                if(data == null)
                {
                    return new(status: OperationResult.Error, messages: "Kayıt Bulunamadı.", null);
                }
 
                 _mapper.Map(request, data);
                 _vtlAdditionalRepository.Update(data);
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
