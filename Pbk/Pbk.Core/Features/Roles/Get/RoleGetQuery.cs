using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Entities.Dto;
using Pbk.Entities.Dto.Country;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Roles.Get
{

    public sealed record RoleGetQuery : IRequest<APIResponse>
    {
        internal sealed class RoleGetQueryHandler : IRequestHandler<RoleGetQuery, APIResponse>
        {
            private readonly IRoleRepository _roleRepository;
            private readonly IMapper _mapper;

            public RoleGetQueryHandler(IMapper mapper, IRoleRepository roleRepository)
            {

                _mapper = mapper;
                _roleRepository = roleRepository;
            }

            public async Task<APIResponse> Handle(RoleGetQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var data = _mapper.Map<List<Pbk.Entities.Models.Role>>(_roleRepository.GetWhere(x=>x.RoleName!="Admin" && x.RoleId!=1).ToList());
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
