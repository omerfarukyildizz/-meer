using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.PalletCompanies.Get
{
 
    public sealed record PalletCompanyNameGetQuery(string? search) : IRequest<APIResponse>
    {
        internal sealed class PalletCompanyNameGetQueryHandler : IRequestHandler<PalletCompanyNameGetQuery, APIResponse>
        {
            private readonly IPalletCompanyRepository   _palletCompanyRepository;
            private readonly IMapper _mapper;

            public PalletCompanyNameGetQueryHandler(IPalletCompanyRepository palletCompanyRepository, IMapper mapper)
            {
                _palletCompanyRepository = palletCompanyRepository;
                _mapper = mapper;
            }

            public async Task<APIResponse> Handle(PalletCompanyNameGetQuery request, CancellationToken cancellationToken)
            {
                try
                {

                    var data = (from palletCompany in _palletCompanyRepository.GetAll()
                                where string.IsNullOrWhiteSpace(request.search)
                                      || (!string.IsNullOrWhiteSpace(request.search) && palletCompany.PalletCompanyName.StartsWith(request.search))
                                select new
                                {
                                    PalletCompanyId = palletCompany.PalletCompanyId,
                                    PalletCompanyName = palletCompany.PalletCompanyName
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
