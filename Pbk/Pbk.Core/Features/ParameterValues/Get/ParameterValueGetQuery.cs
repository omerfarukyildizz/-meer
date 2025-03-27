using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Entities.Dto.Customer;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.ParameterValues.Get
{
    public sealed record ParameterValueGetQuery : IRequest<APIResponse>
    {
        internal sealed class ParameterValueGetQueryHandler : IRequestHandler<ParameterValueGetQuery, APIResponse>
        {

            private readonly IMapper _mapper;
            private readonly IParameterValueRepository _parameterValueRepository;

            public ParameterValueGetQueryHandler(IMapper mapper, IParameterValueRepository parameterValueRepository)
            {
                _mapper = mapper;
                _parameterValueRepository = parameterValueRepository;
            }

            public async Task<APIResponse> Handle(ParameterValueGetQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    return new(status: StatusType.Success, messages: "", _parameterValueRepository.GetAll().ToList());
                }
                catch (Exception ex)
                {
                    return new(status: StatusType.Error, messages: ex?.InnerException?.Message ?? ex?.Message, null);
                }
            }
        }

    }
}
