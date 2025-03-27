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
namespace Pbk.Core.Features.Vehicles.Update
{
 
    internal sealed class VehicleUpdateCommandHandler : IRequestHandler<VehicleUpdateCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;


        public VehicleUpdateCommandHandler(IUserManager userManager, ITranslate tanslate, IMapper mapper, IVehicleRepository vehicleRepository, IUnitOfWork unitOfWork)
        {
            _tanslate = tanslate;
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<APIResponse> Handle(VehicleUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var UserId = _userManager.UserInfo().UserId;

               Entities.Models.Vehicle data = await _vehicleRepository.GetByIdAsync(w=> w.VehicleId == request.VehicleId, cancellationToken);
                   
                if(data == null)
                {
                    return new(status: OperationResult.Error, messages: "Kayıt Bulunamadı.", null);
                }


                if (data.Plate!=request.Plate)
                {
                    var plateCheck = _vehicleRepository.GetWhere(x => x.Plate == request.Plate && x.VehicleId!=data.VehicleId).Count();
                    // Plate uniq kontrolü
                    if (plateCheck > 0)
                    {
                        return new(status: OperationResult.Error, messages: "Plate must be uniq.", null);
                    }
                }



                data.UpdUser = UserId;
                data.UpdTime = DateTime.Now;

                _mapper.Map(request, data);
                _vehicleRepository.Update(data);
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
