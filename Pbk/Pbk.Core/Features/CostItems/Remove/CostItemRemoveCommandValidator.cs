using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.CostItems.Remove
{
 
    public sealed class CustomerRemoveCommandValidator : AbstractValidator<CostItemRemoveCommand>
    {
        public CustomerRemoveCommandValidator()
        {

            RuleFor(a => a.CostItemId)
                .NotEmpty().WithMessage("CostItemId is required.")
                .GreaterThan(0).WithMessage("CostItemId must be greater than 0.");
  
        }
    }
}
