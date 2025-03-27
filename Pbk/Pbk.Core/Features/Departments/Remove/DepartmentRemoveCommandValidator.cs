using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Departments.Remove
{
 
    public sealed class UserRemoveCommandValidator : AbstractValidator<DepartmentRemoveCommand>
    {
        public UserRemoveCommandValidator()
        {

            RuleFor(a => a.DepartmentId)
                .NotEmpty().WithMessage("DepartmentId is required.")
                .GreaterThan(0).WithMessage("DepartmentId must be greater than 0.");
  
        }
    }
}
