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
    public sealed record ParameterValueByParameterIdGetQuery(int ParameterId) : IRequest<APIResponse>
    {
        internal sealed class ParameterValueByParameterIdGetQueryHandler : IRequestHandler<ParameterValueByParameterIdGetQuery, APIResponse>
        {

            private readonly IMapper _mapper;
            private readonly IParameterValueRepository _parameterValueRepository;

            public ParameterValueByParameterIdGetQueryHandler(IMapper mapper, IParameterValueRepository parameterValueRepository)
            {
                _mapper = mapper;
                _parameterValueRepository = parameterValueRepository;
            }

            public async Task<APIResponse> Handle(ParameterValueByParameterIdGetQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var data = _parameterValueRepository.GetWhere(x=>x.ParameterId==request.ParameterId).ToList();
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
