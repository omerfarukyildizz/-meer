using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Entities.Dto.Customer;
using Pbk.Entities.Dto.Projects;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Projects.Get
{
    public sealed record ProjectGetDtoQuery : IRequest<APIResponse>
    {
        internal sealed class ProjectGetDtoQueryHandler : IRequestHandler<ProjectGetDtoQuery, APIResponse>
        {
            private readonly IProjectRepository _projectRepository;

            private readonly IMapper _mapper;

            public ProjectGetDtoQueryHandler(IProjectRepository projectRepository, IMapper mapper)
            {
                _projectRepository = projectRepository;
                _mapper = mapper;
            }

            public async Task<APIResponse> Handle(ProjectGetDtoQuery request, CancellationToken cancellationToken)
            {
                try
                {

                    var data = _mapper.Map<List<GetProjectDto>>(_projectRepository.GetAll().ToList());

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
