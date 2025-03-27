using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Authority.Remove
{
 
    public sealed class AuthorityRemoveCommandValidator : AbstractValidator<AuthorityRemoveCommand>
    {
        public AuthorityRemoveCommandValidator()
        {

            RuleFor(a => a.AuthorityID)
                .NotEmpty().WithMessage("AuthorityID is required.")
                .GreaterThan(0).WithMessage("AuthorityID must be greater than 0.");
  
        }
    }
}
