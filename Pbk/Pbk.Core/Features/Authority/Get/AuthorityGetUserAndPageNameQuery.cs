using Pbk.Core.Features.Response;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Authority.Get
{

    public sealed record AuthorityGetUserAndPageNameQuery(int? UserID, int PageID) : IRequest<APIResponse>
    {
        internal sealed class AuthorityGetUserAndPageNameQueryHandler : IRequestHandler<AuthorityGetUserAndPageNameQuery, APIResponse>
        {
            private readonly IAuthorityRepository _authorityRepository;
            public AuthorityGetUserAndPageNameQueryHandler(IAuthorityRepository authorityRepository)
            {
                _authorityRepository = authorityRepository;
            }
            
            public async Task<APIResponse> Handle(AuthorityGetUserAndPageNameQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    Entities.Models.Authority data = await _authorityRepository.GetByIdAsync(w => w.UserID == request.UserID && w.PageId == request.PageID, cancellationToken);
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
