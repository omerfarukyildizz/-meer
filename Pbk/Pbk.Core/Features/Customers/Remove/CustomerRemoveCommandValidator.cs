using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Customers.Remove
{
 
    public sealed class CustomerRemoveCommandValidator : AbstractValidator<CustomerRemoveCommand>
    {
        public CustomerRemoveCommandValidator()
        {

            RuleFor(a => a.CustomerId)
                .NotEmpty().WithMessage("CustomerId is required.")
                .GreaterThan(0).WithMessage("CustomerId must be greater than 0.");
  
        }
    }
}
