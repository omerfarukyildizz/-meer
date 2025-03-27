using AutoMapper;
using Pbk.Core.Features.User;
using Pbk.Core.Features.Response;
using Pbk.Core.Utilities.IResults;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pbk.Entities.Models;
using Pbk.Core.Features.Drivers.Remove;
using Pbk.Core.Features.Users;
namespace Pbk.Core.Features.ExpenseCodes.Remove
{
 

    internal sealed class ExpenseCodeRemoveCommandHandler : IRequestHandler<ExpenseCodeRemoveCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly IExpenseCodeRepository _expenseCodeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ExpenseCodeRemoveCommandHandler(ITranslate tanslate, IMapper mapper, IExpenseCodeRepository expenseCodeRepository, IUnitOfWork unitOfWork )
        {
            _tanslate = tanslate;
            _mapper = mapper;
            _expenseCodeRepository = expenseCodeRepository;
            _unitOfWork = unitOfWork;
            
        }

        public async Task<APIResponse> Handle(ExpenseCodeRemoveCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var data = _expenseCodeRepository.GetWhere(w => w.ExpenseCodeId == request.ExpenseCodeId).FirstOrDefault();
                if (data == null)
                {
                    return new(status: OperationResult.Error, messages: "Kayıt bulunamadı", null);
                }
                 
                _expenseCodeRepository.Remove(data);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                return new(status: OperationResult.Success, messages: "", data);
            }
            catch (Exception ex)
            {
                return new(status: OperationResult.Error, messages: ex.Message, null);
            }

        }

    }



}
