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
namespace Pbk.Core.Features.Carriers.Remove
{
 

    internal sealed class CarrierRemoveCommandHandler : IRequestHandler<CarrierRemoveCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly ICarrierRepository _CarrierRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;


        public CarrierRemoveCommandHandler(ITranslate tanslate, IMapper mapper, ICarrierRepository CarrierRepository, IUnitOfWork unitOfWork, IUserManager userManager)
        {
            _tanslate = tanslate;
            _CarrierRepository = CarrierRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<APIResponse> Handle(CarrierRemoveCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var data =  _CarrierRepository.GetWhere(w => w.CarrierId == request.CarrierId).FirstOrDefault();
                if (!_userManager.isPermesion("Carriers", "Remove", data.DepartmentId))
                {
                    return new(status: OperationResult.Error, messages: "Yetkiniz Yok.", null);
                }
                if (data == null)
                {
                    return new(status: OperationResult.Error, messages: "Kayıt bulunamadı", null);
                }
                var user = _userManager.UserInfo().UserId;
                data.UpdUser = user;
                data.UpdTime = DateTime.Now;
                data.IsPassive= true;
                _CarrierRepository.Update(data);
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
