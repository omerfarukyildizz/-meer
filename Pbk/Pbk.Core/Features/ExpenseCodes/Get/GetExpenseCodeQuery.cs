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
    public sealed record GetExpenseCodeQuery(int? departmentId,string? search) : IRequest<APIResponse>
    {
        internal sealed class GetExpenseCodeQueryHandler : IRequestHandler<GetExpenseCodeQuery, APIResponse>
        {
            private readonly IExpenseCodeRepository _expenseCodeRepository;
            private readonly IMapper _mapper;

            public GetExpenseCodeQueryHandler(IExpenseCodeRepository expenseCodeRepository, IMapper mapper)
            {
                _expenseCodeRepository = expenseCodeRepository;
                _mapper = mapper;
            }

            public async Task<APIResponse> Handle(GetExpenseCodeQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var query = _expenseCodeRepository.GetAll();

                    if (request.departmentId.HasValue)
                    {
                        query = query.Where(expense => expense.DepartmentId == request.departmentId.Value);
                    }

                    if (!string.IsNullOrEmpty(request.search))
                    {
                        query = query.Where(expense => expense.ExpenseCodeName.StartsWith(request.search));
                    }

                    var data = (from expense in query
                                select new
                                {
                                    ExpenseCodeId = expense.ExpenseCodeId,
                                    ExpenseCodeName = expense.ExpenseCodeName
                                })
                                .Take(500)
                                .ToList();

                    return new(status: StatusType.Success, messages: "", data);
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
