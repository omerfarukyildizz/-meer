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
   

    public sealed record TranslationGetUserQuery(int? UserID) : IRequest<APIResponse>
    {
        internal sealed class AuthorityGetUserQueryHandler : IRequestHandler<TranslationGetUserQuery, APIResponse>
        {
            private readonly IAuthorityRepository _authorityRepository;
            public AuthorityGetUserQueryHandler(IAuthorityRepository authorityRepository)
            {
                _authorityRepository = authorityRepository;
            }
            
            public async Task<APIResponse> Handle(TranslationGetUserQuery request, CancellationToken cancellationToken)
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
