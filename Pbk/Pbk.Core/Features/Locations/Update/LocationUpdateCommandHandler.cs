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
using Pbk.Core.Features.EndPoints.Create;
using Pbk.Core.Features.EndPoints.Update;
namespace Pbk.Core.Features.Locations.Update
{

    internal sealed class LocationUpdateCommandHandler : IRequestHandler<LocationUpdateCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly ILocationRepository _locationRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;
        private readonly IMediator _mediator;


        public LocationUpdateCommandHandler(IUserManager userManager, ITranslate tanslate, IMapper mapper, ILocationRepository locationRepository, IUnitOfWork unitOfWork, IMediator mediator)
        {
            _tanslate = tanslate;
            _locationRepository = locationRepository;
            _mapper = mapper;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        public async Task<APIResponse> Handle(LocationUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _locationRepository.GetByIdAsync(w => w.LocationId == request.LocationId, cancellationToken);


                if (!_userManager.isPermesion("Locations", "Edit", data.DepartmentId))
                {
                    return new(status: OperationResult.Error, messages: "Yetkiniz Yok.", null);
                }

                var UserId = _userManager.UserInfo().UserId;


                if (data == null)
                {
                    return new(status: OperationResult.Error, messages: "Kayıt Bulunamadı.", null);
                }

                data.UpdUser = UserId;
                data.UpdTime = DateTime.Now;
                _mapper.Map(request, data);
                _locationRepository.Update(data);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                string msg = "";
                if (request.IsEndPoint == true)
                {
                    if (data.PointId != null)
                    {
                        //Update
                        var nDate = new EndPointUpdateCommand(
                       data.PointId.Value,
                       request.DepartmentId,
                       request.LocationName,
                       request.Address,
                       request.PlaceId,
                       request.CountryId,
                       request.Phone,
                       request.PostalCode,
                       request.RelatedPerson,
                       request.Email,
                       request.Reference,
                       request.BarsisAdrBankCode,
                       request.Latitude,
                       request.Longitude, 
                       null //IsLocation
                       );
                        var response = await _mediator.Send(nDate, cancellationToken);
                        msg = response.messages;
                    }
                    else
                    {
                        // Create
                        var nDate = new EndPointCreateCommand(
                       request.DepartmentId,
                       request.LocationName,
                       request.Address,
                       request.PlaceId,
                       request.CountryId,
                       request.Phone,
                       request.PostalCode,
                       request.RelatedPerson,
                       request.Email,
                       request.Reference,
                       request.BarsisAdrBankCode,
                       request.Latitude,
                       request.Longitude, 
                       data.LocationId,
                       false // isLocation için
                       );
                        var response = await _mediator.Send(nDate, cancellationToken);
                        msg = response.messages;
                    }


                }
                return new(status: OperationResult.Success, messages: msg, data);



            }
            catch (Exception ex)
            {
                return new(status: OperationResult.Error, messages: ex.Message, null);
            }

        }

    }



}
