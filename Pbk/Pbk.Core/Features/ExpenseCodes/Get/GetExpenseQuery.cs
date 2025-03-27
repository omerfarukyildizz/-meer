using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.ExpenseCodes.Get
{
    public sealed record GetExpenseQuery : IRequest<APIResponse>
    {
        internal sealed class GetExpenseQueryHandler : IRequestHandler<GetExpenseQuery, APIResponse>
        {
            private readonly IExpenseCodeRepository _expenseCodeRepository;
            private readonly IMapper _mapper;

            public GetExpenseQueryHandler(IExpenseCodeRepository expenseCodeRepository, IMapper mapper)
            {
                _expenseCodeRepository = expenseCodeRepository;
                _mapper = mapper;
            }

            public async Task<APIResponse> Handle(GetExpenseQuery request, CancellationToken cancellationToken)
            {
                try
                { 
                   
                    return new(status: StatusType.Success, messages: "", _expenseCodeRepository.GetAll().ToList());
                }
                catch (Exception ex)
                {
                    // Hata durumunda hata mesajı döndür
                    return new(status: StatusType.Error, messages: ex?.InnerException?.Message ?? ex?.Message, null);
                }
            }
        }

    }
}
