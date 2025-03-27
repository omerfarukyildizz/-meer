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
using Pbk.Core.Features.Users;
namespace Pbk.Core.Features.Drivers.Remove
{
 

    internal sealed class DriverRemoveCommandHandler : IRequestHandler<DriverRemoveCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly IDriverRepository _driverRepository;
        private readonly IUserManager _userManager;
        private readonly IUnitOfWork _unitOfWork;

        public DriverRemoveCommandHandler(ITranslate tanslate, IMapper mapper, IDriverRepository driverRepository, IUnitOfWork unitOfWork, IUserManager userManager)
        {
            _tanslate = tanslate;
            _driverRepository = driverRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<APIResponse> Handle(DriverRemoveCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var data =  _driverRepository.GetWhere(w => w.DriverId == request.DriverId).FirstOrDefault();
                if (!_userManager.isPermesion("Drivers", "Remove", data.DepartmentId))
                {
                    return new(status: OperationResult.Error, messages: "Yetkiniz Yok.", null);
                }
                if (data == null)
                {
                    return new(status: OperationResult.Error, messages: "Kayıt bulunamadı", null);
                }
                var user = _userManager.UserInfo().UserId;
                data.IsPassive = true;
                data.UpdTime = DateTime.Now;
                data.UpdUser = user;
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
