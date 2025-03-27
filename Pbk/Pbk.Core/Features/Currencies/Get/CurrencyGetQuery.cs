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

namespace Pbk.Core.Features.Currencies.Get
{

    public sealed record CurrencyGetQuery : IRequest<APIResponse>
    {
        internal sealed class CurrencyGetQueryHandler : IRequestHandler<CurrencyGetQuery, APIResponse>
        {
            private readonly ICurrencyRepository _currencyRepository;
            private readonly IMapper _mapper;

            public CurrencyGetQueryHandler(IMapper mapper, ICurrencyRepository currencyRepository)
            {

                _mapper = mapper;
                _currencyRepository = currencyRepository;
            }

            public async Task<APIResponse> Handle(CurrencyGetQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    return new(status: StatusType.Success, messages: "", _currencyRepository.GetAll().ToList());
                }
                catch (Exception ex)
                {
                    return new(status: StatusType.Error, messages: ex?.InnerException?.Message ?? ex?.Message, null);
                }
            }
        }

    }
}
