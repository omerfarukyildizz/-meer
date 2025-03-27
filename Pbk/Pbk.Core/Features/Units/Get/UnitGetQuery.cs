using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Units.Get
{
 
    public sealed record UnitGetQuery(string? search) : IRequest<APIResponse>
    {
        internal sealed class UnitGetQueryHandler : IRequestHandler<UnitGetQuery, APIResponse>
        {
            private readonly IUnitRepository _unitRepository;
            private readonly IMapper _mapper;

            public UnitGetQueryHandler(IUnitRepository unitRepository, IMapper mapper)
            {
                _unitRepository = unitRepository;
                _mapper = mapper;
            }

            public async Task<APIResponse> Handle(UnitGetQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var data = (from unit in  _unitRepository.GetAll()
                                where string.IsNullOrWhiteSpace(request.search)
                                     || (!string.IsNullOrWhiteSpace(request.search) && unit.UnitName.StartsWith(request.search))
                                select new
                                {
                                     UnitId=unit.UnitId,
                                     UnitName=unit.UnitName
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
