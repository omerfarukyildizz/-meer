using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Account.Remove
{
 
    public sealed class UserRemoveCommandValidator : AbstractValidator<UserRemoveCommand>
    {
        public UserRemoveCommandValidator()
        {

            RuleFor(a => a.UserId)
                .NotEmpty().WithMessage("UserId is required.")
                .GreaterThan(0).WithMessage("UserId must be greater than 0.");
  
        }
    }
}
