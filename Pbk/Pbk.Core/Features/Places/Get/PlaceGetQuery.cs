using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Entities.Dto;
using Pbk.Entities.Dto.Place;
using Pbk.Entities.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Countries.Get
{

    public sealed record PlaceGetQuery(int CountryId) : IRequest<APIResponse>
    {
        internal sealed class PlaceGetQueryHandler : IRequestHandler<PlaceGetQuery, APIResponse>
        {
            private readonly IPlaceRepository _placeRepository;
            private readonly ICountryRepository _countryRepository;
            private readonly IMapper _mapper;
            public PlaceGetQueryHandler(IPlaceRepository placeRepository, IMapper mapper, ICountryRepository countryRepository)
            {
                _placeRepository = placeRepository;
                _mapper = mapper;
                _countryRepository = countryRepository;
            }

            public async Task<APIResponse> Handle(PlaceGetQuery request, CancellationToken cancellationToken)
            {
                try
                { 
                    var data = _placeRepository.GetWhere(p => p.CountryId == request.CountryId).GroupBy(p => p.State).Select(g => new { State = g.Key }).ToList();
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
