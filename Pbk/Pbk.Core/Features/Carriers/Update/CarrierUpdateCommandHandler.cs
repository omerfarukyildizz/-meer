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
namespace Pbk.Core.Features.Carriers.Update
{
 
    internal sealed class CarrierUpdateCommandHandler : IRequestHandler<CarrierUpdateCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly ICarrierRepository _carrierRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;


        public CarrierUpdateCommandHandler(IUserManager userManager, ITranslate tanslate, IMapper mapper, ICarrierRepository carrierRepository, IUnitOfWork unitOfWork)
        {
            _tanslate = tanslate;
            _carrierRepository = carrierRepository;
            _mapper = mapper;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<APIResponse> Handle(CarrierUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!_userManager.isPermesion("Carriers", "Edit", request.DepartmentId))
                {
                    return new(status: OperationResult.Error, messages: "Yetkiniz Yok.", null);
                }

                var UserId = _userManager.UserInfo().UserId;

               Entities.Models.Carrier data = await _carrierRepository.GetByIdAsync(w=> w.CarrierId == request.CarrierId, cancellationToken);
                   
                if(data == null)
                {
                    return new(status: OperationResult.Error, messages: "Kayıt Bulunamadı.", null);
                }
                // SapAccountCode ve TimocomId
                var SAPAccountCodeCheck = _carrierRepository.GetWhere(x => x.SAPAccountCode == request.SAPAccountCode 
                                                                        && x.SAPAccountCode != null 
                                                                        && x.CarrierId !=request.CarrierId // Güncellenen kaydı hariç tut
                                                                        ).Any();
                if (SAPAccountCodeCheck)
                {
                    return new(status: OperationResult.Error, messages: "This SAPAccountCode already exists for another record.", null);
                }

                var TimocomIdCheck = _carrierRepository.GetWhere(x => x.TimocomId == request.TimocomId && x.TimocomId != null && x.CarrierId != request.CarrierId).Any();
                if (TimocomIdCheck)
                {
                    return new(status: OperationResult.Error, messages: "This TimocomId already exists for another record.", null);
                }

                data.UpdUser = UserId;
                data.UpdTime = DateTime.Now;
                _mapper.Map(request, data);
                 _carrierRepository.Update(data);
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
