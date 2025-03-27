using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.IncoTerms.Get
{
    public sealed record IncoTermGetQuery(string? search) : IRequest<APIResponse>
    {
        internal sealed class IncoTermGetQueryHandler : IRequestHandler<IncoTermGetQuery, APIResponse>
        {
            private readonly IIncoTermRepository _incoTermRepository;
            private readonly IMapper _mapper;

            public IncoTermGetQueryHandler(IIncoTermRepository incoTermRepository, IMapper mapper)
            {
                _incoTermRepository = incoTermRepository;
                _mapper = mapper;
            }

            public async Task<APIResponse> Handle(IncoTermGetQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var data = (from incoTerm in _incoTermRepository.GetAll()
                                where string.IsNullOrWhiteSpace(request.search) 
                                      || (!string.IsNullOrWhiteSpace(request.search) && incoTerm.Code.StartsWith(request.search))
                                select new
                                {
                                    IncoTermId=incoTerm.IncoTermId,
                                    IncoTermCode=incoTerm.Code,
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
