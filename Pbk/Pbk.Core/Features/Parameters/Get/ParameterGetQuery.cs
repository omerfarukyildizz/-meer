using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Core.Features.Users;
using Pbk.Core.Utilities.IResults;
using Pbk.Entities.Dto;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Parameters.Get
{


    public sealed record ParameterGetQuery(string Category,string ParameterName) : IRequest<APIResponse>
    {
        internal sealed class ParameterGetQueryHandler : IRequestHandler<ParameterGetQuery, APIResponse>
        {
            private readonly IParameterRepository _parameterRepository;
            private readonly IUserManager _userManager;
            private readonly IMapper _mapper;

            public ParameterGetQueryHandler(IParameterRepository parameterRepository, IMapper mapper, IUserManager userManager)
            {
                _parameterRepository = parameterRepository;
                _mapper = mapper;
                _userManager = userManager;
            }

            public async Task<APIResponse> Handle(ParameterGetQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    if (!_userManager.isPermesion("Parameters", "Get", null) )
                    {
                        return new(status: OperationResult.Error, messages: "Yetkiniz Yok.", null);
                    }
                    var list = _parameterRepository.GetWhere(w => 
                    w.CategoryName == request.Category 
                    && w.ParameterName == request.ParameterName).ToList();
                    var data = _mapper.Map<List<GetParametersDto>>(list);
                   
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
