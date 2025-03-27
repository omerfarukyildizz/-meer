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
namespace Pbk.Core.Features.Drivers.Update
{
 
    internal sealed class DriverUpdateCommandHandler : IRequestHandler<DriverUpdateCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly IDriverRepository _driverRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;


        public DriverUpdateCommandHandler(IUserManager userManager, ITranslate tanslate, IMapper mapper, IDriverRepository driverRepository, IUnitOfWork unitOfWork)
        {
            _tanslate = tanslate;
            _driverRepository = driverRepository;
            _mapper = mapper;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<APIResponse> Handle(DriverUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!_userManager.isPermesion("Drivers", "Edit", request.DepartmentId))
                {
                    return new(status: OperationResult.Error, messages: "Yetkiniz Yok.", null);
                }
                var UserId = _userManager.UserInfo().UserId;

               Entities.Models.Driver data = await _driverRepository.GetByIdAsync(w=> w.DriverId == request.DriverId, cancellationToken);
                   
                if(data == null)
                {
                    return new(status: OperationResult.Error, messages: "Kayıt Bulunamadı.", null);
                }


                var vclCheck = _driverRepository.GetWhere(x => x.VehicleId == request.VehicleId && x.DriverId != request.DriverId && x.IsPassive == false).Count();
                if (vclCheck > 0)
                {
                    return new(status: OperationResult.Error, messages: "VehicleId must be uniq.", null);
                }


                if (data.IntegratedAccountCode != request.IntegratedAccountCode)
                {
                    var IntegratedCheck = _driverRepository.GetWhere(x => x.IntegratedAccountCode == request.IntegratedAccountCode && x.DriverId != data.DriverId).Count();
                    // IntegratedAccountCode uniq kontrolü
                    if (IntegratedCheck > 0)
                    {
                        return new(status: OperationResult.Error, messages: "IntegratedAccountCode must be uniq.", null);
                    }
                }


                data.UpdUser = UserId;
                data.UpdTime = DateTime.Now;

                _mapper.Map(request, data);
                _driverRepository.Update(data);
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
