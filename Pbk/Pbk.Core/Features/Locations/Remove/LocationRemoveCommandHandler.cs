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
using Pbk.Core.Features.Locations.Remove;
using Pbk.Core.Features.Users;
namespace Pbk.Core.Features.Locations.Remove
{


    internal sealed class LocationRemoveCommandHandler : IRequestHandler<LocationRemoveCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly ILocationRepository _locationRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;

        public LocationRemoveCommandHandler(ITranslate tanslate, IMapper mapper, ILocationRepository locationRepository, IUnitOfWork unitOfWork, IUserManager userManager)
        {
            _tanslate = tanslate;
            _locationRepository = locationRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<APIResponse> Handle(LocationRemoveCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var data = _locationRepository.GetWhere(w => w.LocationId == request.LocationId).FirstOrDefault();
                if (!_userManager.isPermesion("Locations", "Remove", data.DepartmentId))
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
                _locationRepository.Update(data);
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
