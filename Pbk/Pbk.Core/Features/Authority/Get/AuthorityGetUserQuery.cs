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
   

    public sealed record AuthorityGetUserQuery(int? UserID) : IRequest<APIResponse>
    {
        internal sealed class AuthorityGetUserQueryHandler : IRequestHandler<AuthorityGetUserQuery, APIResponse>
        {
            private readonly IAuthorityRepository _authorityRepository;
            public AuthorityGetUserQueryHandler(IAuthorityRepository authorityRepository)
            {
                _authorityRepository = authorityRepository;
            }
            
            public async Task<APIResponse> Handle(AuthorityGetUserQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    Entities.Models.Authority data = await _authorityRepository.GetByIdAsync(w => w.UserID == request.UserID, cancellationToken);
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
