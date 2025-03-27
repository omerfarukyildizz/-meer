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
using Pbk.Core.Features.Locations.Update;
using Pbk.Core.Features.Locations.Create;
namespace Pbk.Core.Features.EndPoints.Update
{

    internal sealed class EndPointUpdateCommandHandler : IRequestHandler<EndPointUpdateCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly IEndPointRepository _endPointRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;
        private readonly IMediator _mediator;

        public EndPointUpdateCommandHandler(IUserManager userManager, ITranslate tanslate, IMapper mapper, IEndPointRepository endPointRepository, IUnitOfWork unitOfWork, IMediator mediator)
        {
            _tanslate = tanslate;
            _endPointRepository = endPointRepository;
            _mapper = mapper;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        public async Task<APIResponse> Handle(EndPointUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var UserId = _userManager.UserInfo().UserId;

                var data = await _endPointRepository.GetByIdAsync(w => w.PointId == request.PointId, cancellationToken);
                if (data == null)
                {
                    return new(status: OperationResult.Error, messages: "Kayıt Bulunamadı.", null);
                }

                if (!_userManager.isPermesion("EndPoints", "Edit", data.DepartmentId))
                {
                    return new(status: OperationResult.Error, messages: "Yetkiniz Yok.", null);
                }



                data.UpdUser = UserId;
                data.UpdTime = DateTime.Now;
                _mapper.Map(request, data);
                _endPointRepository.Update(data);
                await _unitOfWork.SaveChangesAsync(cancellationToken);


                string msg = "";
                if (request.IsLocation == true)
                {
                    if (data.LocationId != null)
                    {
                        //Update
                        var nDate = new LocationUpdateCommand(
                       data.LocationId.Value,
                       request.DepartmentId,
                       request.PointName,
                       request.Address,
                       request.PlaceId,
                       request.CountryId,
                       request.Phone,
                       request.PostalCode,
                       request.Latitude,
                       request.Longitude, 
                       request.RelatedPerson,
                       request.Email,
                       request.Reference,
                       request.BarsisAdrBankCode,
                       null //IsLocation
                       );
                        var response = await _mediator.Send(nDate, cancellationToken);
                        msg = response.messages;
                    }
                    else
                    {
                        // Create
                        var nDate = new LocationCreateCommand(
                       request.DepartmentId,
                       request.PointName,
                       request.Address,
                       request.PlaceId,
                       request.CountryId,
                       request.Phone,
                       request.PostalCode,
                       request.Latitude,
                       request.Longitude, 
                       request.RelatedPerson,
                       request.Email,
                       request.Reference,
                       request.BarsisAdrBankCode,

                       data.PointId,
                       false // isLocation için
                       );
                        var response = await _mediator.Send(nDate, cancellationToken);
                        msg = response.messages;
                    }


                }



                return new(status: OperationResult.Success, messages: "", data);
            }
            catch (Exception ex)
            {
                return new(status: OperationResult.Error, messages: ex.Message, null);
            }

        }

    }



}
