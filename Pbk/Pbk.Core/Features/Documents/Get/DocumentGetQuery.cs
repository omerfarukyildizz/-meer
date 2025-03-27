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
   

    public sealed record DocumentGetQuery: IRequest<APIResponse>
    {
        internal sealed class DocumentGetQueryHandler : IRequestHandler<DocumentGetQuery, APIResponse>
        {
            private readonly IDocumentRepository _documentRepository;
            private readonly IMapper _mapper;
            public DocumentGetQueryHandler(IDocumentRepository documentRepository, IMapper mapper = null)
            {
                _documentRepository = documentRepository;
                _mapper = mapper;
            }

            public async Task<APIResponse> Handle(DocumentGetQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var data = _mapper.Map<List<GetDocumentDto>>(_documentRepository.GetAll().ToList());
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
