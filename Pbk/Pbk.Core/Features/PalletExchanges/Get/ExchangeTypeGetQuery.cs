using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.PalletExchanges.Get
{
 
    public sealed record ExchangeTypeGetQuery(string? search) : IRequest<APIResponse>
    {
        internal sealed class ExchangeTypeGetQueryHandler : IRequestHandler<ExchangeTypeGetQuery, APIResponse>
        {
            private readonly IPalletExchangeRepository _palletExchangeRepository;
            private readonly IMapper _mapper;

            public ExchangeTypeGetQueryHandler(IPalletExchangeRepository palletExchangeRepository, IMapper mapper)
            {
                _palletExchangeRepository = palletExchangeRepository;
                _mapper = mapper;
            }

            public async Task<APIResponse> Handle(ExchangeTypeGetQuery request, CancellationToken cancellationToken)
            {
                try
                {

                    var data = (from palletExchange in _palletExchangeRepository.GetAll()
                                where string.IsNullOrWhiteSpace(request.search)
                                      || (!string.IsNullOrWhiteSpace(request.search) && palletExchange.ExchangeType.StartsWith(request.search))
                                select new
                                {
                                    PalletExchangeId=palletExchange.PalletExchangeId,
                                    ExchangeType=palletExchange.ExchangeType
                                }).Take(string.IsNullOrWhiteSpace(request.search) ? 500 : int.MaxValue).ToList();
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
