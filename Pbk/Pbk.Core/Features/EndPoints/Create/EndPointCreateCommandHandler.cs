using AutoMapper;
using Pbk.Core.Features.EndPoints.Create;
using Pbk.Core.Features.User;
using Pbk.Core.Features.Response;
using Pbk.Core.Utilities.IResults;
using Pbk.Entities.Repositories;
using MediatR;
using Pbk.Core.Features.Users;
using Pbk.Core.Features.Locations.Create;
using Microsoft.EntityFrameworkCore;
namespace Pbk.Core.Features.EndPoints.Create
{
    internal sealed class EndPointCreateCommandHandler : IRequestHandler<EndPointCreateCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly IEndPointRepository _endPointRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;
        private readonly IMediator _mediator;

        public EndPointCreateCommandHandler(IUserManager userManager, ITranslate tanslate, IMapper mapper, IEndPointRepository endPointRepository, IUnitOfWork unitOfWork, IMediator mediator, ILocationRepository locationRepository)
        {
            _tanslate = tanslate;
            _endPointRepository = endPointRepository;
            _mapper = mapper;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
            _locationRepository = locationRepository;
        }

        public async Task<APIResponse> Handle(EndPointCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!_userManager.isPermesion("EndPoints", "Create", request.DepartmentId))
                {
                    return new(status: OperationResult.Error, messages: "Yetkiniz Yok.", null);
                }

                var UserId = _userManager.UserInfo().UserId;

                Entities.Models.EndPoint data = _mapper.Map<Entities.Models.EndPoint>(request);
                data.InsUser = UserId;
                data.InsTime = DateTime.Now;
                data.IsPassive = false;

                await _endPointRepository.AddAsync(data, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                string msg = "";
                if (request.IsLocation == true)
                {

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
                        false 
                        );
                    var response = await _mediator.Send(nDate, cancellationToken);
                    msg = response.messages;

                    if (response.status == "Success")
                    {
                        data.LocationId = Convert.ToInt32(response.data);
                        _endPointRepository.Update(data);
                    }

                    await _unitOfWork.SaveChangesAsync(cancellationToken);
                }
               

                return new(status: OperationResult.Success, messages: "", data.PointId);
            }
            catch (Exception ex)
            {
                return new(status: OperationResult.Error, messages: ex.Message, null);
            }

        }

    }



}
