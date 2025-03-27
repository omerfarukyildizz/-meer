using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Integrations.Get
{
 
    public sealed record IntegrationGetQuery(string? search) : IRequest<APIResponse>
    {
        internal sealed class IntegrationGetQueryHandler : IRequestHandler<IntegrationGetQuery, APIResponse>
        {
            private readonly IIntegrationRepository _integrationRepository;
            private readonly IMapper _mapper;

            public IntegrationGetQueryHandler(IIntegrationRepository integrationRepository, IMapper mapper)
            {
                _integrationRepository = integrationRepository;
                _mapper = mapper;
            }

            public async Task<APIResponse> Handle(IntegrationGetQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var data = (from integration in _integrationRepository.GetAll()
                                where string.IsNullOrWhiteSpace(request.search)
                                     || (!string.IsNullOrWhiteSpace(request.search) && integration.CompanyName.StartsWith(request.search))
                                select new
                                {
                                    IntegrationId = integration.IntegrationId,
                                    CompanyName=integration.CompanyName
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
