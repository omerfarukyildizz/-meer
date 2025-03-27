using AutoMapper;
using Pbk.Core.Features.Locations.Create;
using Pbk.Core.Features.User;
using Pbk.Core.Features.Response;
using Pbk.Core.Utilities.IResults;
using Pbk.Entities.Repositories;
using MediatR;
using Pbk.Core.Features.Users;
using Pbk.Core.Features.EndPoints.Create;
namespace Pbk.Core.Features.Locations.Create
{
    internal sealed class LocationCreateCommandHandler : IRequestHandler<LocationCreateCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly ILocationRepository _locationRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;
        private readonly IMediator _mediator;

        public LocationCreateCommandHandler(IUserManager userManager, ITranslate tanslate, IMapper mapper, ILocationRepository locationRepository, IUnitOfWork unitOfWork, IMediator mediator)
        {
            _tanslate = tanslate;
            _locationRepository = locationRepository;
            _mapper = mapper;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        public async Task<APIResponse> Handle(LocationCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!_userManager.isPermesion("Locations", "Create", request.DepartmentId))
                {
                    return new(status: OperationResult.Error, messages: "Yetkiniz Yok.", null);
                }

                var UserId = _userManager.UserInfo().UserId;

                Entities.Models.Location data = _mapper.Map<Entities.Models.Location>(request);
                data.InsUser = UserId;
                data.InsTime = DateTime.Now;
                data.IsPassive = false;

                await _locationRepository.AddAsync(data, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                string msg = "";
                if (request.IsEndPoint == true)
                {

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

                    if (response.status == "Success")
                    {
                        data.PointId = Convert.ToInt32(response.data);
                        _locationRepository.Update(data);
                    }

                    await _unitOfWork.SaveChangesAsync(cancellationToken);
                }

                return new(status: OperationResult.Success, messages: msg, data.LocationId);



            }
            catch (Exception ex)
            {
                return new(status: OperationResult.Error, messages: ex.Message, null);
            }

        }

    }



}
