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

namespace Pbk.Core.Features.Shipments.Update
{
 
    internal sealed class ShipmentUpdateCommandHandler : IRequestHandler<ShipmentUpdateCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;


        public ShipmentUpdateCommandHandler(IUserManager userManager, ITranslate tanslate, IMapper mapper, IShipmentRepository shipmentRepository, IUnitOfWork unitOfWork)
        {
            _tanslate = tanslate;
            _shipmentRepository = shipmentRepository;
            _mapper = mapper;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<APIResponse> Handle(ShipmentUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!_userManager.isPermesion("Shipments", "Edit", request.DepartmentId))
                {
                    return new(status: OperationResult.Error, messages: "Yetkiniz Yok.", null);
                }
                var UserId = _userManager.UserInfo().UserId;

               Entities.Models.Shipment data = await _shipmentRepository.GetByIdAsync(w=> w.ShipmentId == request.ShipmentId, cancellationToken);
                   
                if(data == null)
                {
                    return new(status: OperationResult.Error, messages: "Kayıt Bulunamadı.", null);
                }

                data.UpdUser = UserId;
                data.UpdTime = DateTime.Now;
                data.Volume = ((request.Length ?? 0) * (request.Width ?? 0) * (request.Height ?? 0) / 1000000);
                _mapper.Map(request, data);
                 _shipmentRepository.Update(data);
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
