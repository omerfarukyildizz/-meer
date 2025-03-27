using AutoMapper;
using Pbk.Core.Features.Countries.Get;
using Pbk.Core.Features.Response;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Places.Get
{
    public sealed record StateWithPlaceIdGetQuery(string State, int CountryId) : IRequest<APIResponse>
    {
        internal sealed class StateWithPlaceIdGetQueryHandler: IRequestHandler<StateWithPlaceIdGetQuery, APIResponse>
        {
            private readonly IPlaceRepository _placeRepository;
            private readonly IMapper _mapper;
            public StateWithPlaceIdGetQueryHandler(IPlaceRepository placeRepository, IMapper mapper)
            {
                _placeRepository = placeRepository;
                _mapper = mapper;
            }

            public async Task<APIResponse> Handle(StateWithPlaceIdGetQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var data = _placeRepository
                                .GetWhere(p => p.CountryId == request.CountryId && p.State == request.State)
                                .Select(p => new { p.PlaceName, p.PlaceId })
                                .ToList();
                    return new(status: StatusType.Success, messages: "", data);
                }
                catch (Exception ex)
                {
                    return new(status: StatusType.Error, messages: ex?.InnerException?.Message ?? ex?.Message, null);
                }
            }
        }
    }
}
