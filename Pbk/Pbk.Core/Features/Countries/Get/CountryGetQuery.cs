using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Entities.Dto;
using Pbk.Entities.Dto.Country;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Countries.Get
{

    public sealed record CountryGetQuery : IRequest<APIResponse>
    {
        internal sealed class CountryGetQueryHandler : IRequestHandler<CountryGetQuery, APIResponse>
        {
            private readonly ICountryRepository _countryRepository;
            private readonly IMapper _mapper;
            public CountryGetQueryHandler(ICountryRepository countryRepository, IMapper mapper)
            {
                _countryRepository = countryRepository;
                _mapper = mapper;
            }

            public async Task<APIResponse> Handle(CountryGetQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var data = _mapper.Map<List<GetCountriesDto>>(_countryRepository.GetAll().ToList());
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
