using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Entities.Dto;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Sectors.Get
{
   

    public sealed record SectorGetQuery(string? search) : IRequest<APIResponse>
    {
        internal sealed class SectorGetQueryHandler : IRequestHandler<SectorGetQuery, APIResponse>
        {
            private readonly ISectorRepository _sectorRepository;
            private readonly IMapper _mapper;
            public SectorGetQueryHandler(ISectorRepository sectorRepository, IMapper mapper)
            {
                _sectorRepository = sectorRepository;
                _mapper = mapper;
            }

            public async Task<APIResponse> Handle(SectorGetQuery request, CancellationToken cancellationToken)
            {
                try
                {

                    var data = (from sector in _sectorRepository.GetAll()
                                where string.IsNullOrWhiteSpace(request.search)
                                      || (!string.IsNullOrWhiteSpace(request.search) && sector.SectorName.StartsWith(request.search))
                                select new
                                {
                                    SectorId=sector.SectorId,
                                    SectorName=sector.SectorName
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
