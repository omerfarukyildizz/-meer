using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.ExpenseCodes.Remove
{
 
    public sealed class ExpenseCodeRemoveCommandValidator : AbstractValidator<ExpenseCodeRemoveCommand>
    {
        public ExpenseCodeRemoveCommandValidator()
        {

            RuleFor(a => a.ExpenseCodeId)
                .NotEmpty().WithMessage("ExpenseCodeId is required.")
                .GreaterThan(0).WithMessage("ExpenseCodeId must be greater than 0.");
  
        }
    }
}
