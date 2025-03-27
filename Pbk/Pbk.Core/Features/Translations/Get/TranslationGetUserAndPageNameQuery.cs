using Pbk.Core.Features.Response;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Translations.Get
{
   

    public sealed record TranslationGetUserAndPageNameQuery(int? UserID, int PageId) : IRequest<APIResponse>
    {
        internal sealed class AuthorityGetUserAndPageNameQueryHandler : IRequestHandler<TranslationGetUserAndPageNameQuery, APIResponse>
        {
            private readonly IAuthorityRepository _authorityRepository;
            public AuthorityGetUserAndPageNameQueryHandler(IAuthorityRepository authorityRepository)
            {
                _authorityRepository = authorityRepository;
            }
            
            public async Task<APIResponse> Handle(TranslationGetUserAndPageNameQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    Entities.Models.Authority data = await _authorityRepository.GetByIdAsync(w => w.UserID == request.UserID && w.PageId == request.PageId, cancellationToken);
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
