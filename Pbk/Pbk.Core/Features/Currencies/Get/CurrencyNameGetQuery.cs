using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Entities.Dto;
using Pbk.Entities.Dto.Country;
using Pbk.Entities.Models2;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Currencies.Get
{

    public sealed record CurrencyNameGetQuery(string? search) : IRequest<APIResponse>
    {
        internal sealed class CurrencyNameGetQueryHandler : IRequestHandler<CurrencyNameGetQuery, APIResponse>
        {
            private readonly ICurrencyRepository _currencyRepository;
            private readonly IMapper _mapper;

            public CurrencyNameGetQueryHandler(IMapper mapper, ICurrencyRepository currencyRepository)
            {

                _mapper = mapper;
                _currencyRepository = currencyRepository;
            }

            public async Task<APIResponse> Handle(CurrencyNameGetQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var data = (from currency in _currencyRepository.GetAll()
                                where (string.IsNullOrWhiteSpace(request.search))
                                      || (!string.IsNullOrWhiteSpace(request.search) && currency.CurrencyCode.StartsWith(request.search))
                                select new
                                {
                                    CurrencyId= currency.CurrencyId,
                                    CurrencyCode= currency.CurrencyCode
                                })
                                .Take(string.IsNullOrWhiteSpace(request.search) ? 500 : int.MaxValue)
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
