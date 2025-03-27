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

namespace Pbk.Core.Features.Documents.Get
{
   

    public sealed record DocumentGetArchiveTypesQuery : IRequest<APIResponse>
    {
        internal sealed class DocumentGetArchiveTypesQueryHandler : IRequestHandler<DocumentGetArchiveTypesQuery, APIResponse>
        {
            private readonly IParameterRepository _parameterRepository;
            private readonly IMapper _mapper;
            public DocumentGetArchiveTypesQueryHandler(IParameterRepository parameterRepository, IMapper mapper)
            {
                _parameterRepository = parameterRepository;
                _mapper = mapper;
            }

            public async Task<APIResponse> Handle(DocumentGetArchiveTypesQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var data = _mapper.Map<List<GetDocumentArchiveTypesDto>>(_parameterRepository.GetAll()
                        .Where(x=>x.CategoryName== "Documents" && x.ParameterName== "Archive Types").ToList());
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
