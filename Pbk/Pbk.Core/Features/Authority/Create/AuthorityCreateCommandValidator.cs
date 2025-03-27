using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Authority.Create
{
 
    public sealed class AuthorityCreateCommandValidator : AbstractValidator<AuthorityCreateCommand>
    {
        public AuthorityCreateCommandValidator()
        {

            RuleFor(a => a.UserID)
                .NotEmpty().WithMessage("UserID is required.")
                .GreaterThan(0).WithMessage("UserID must be greater than 0.");

            RuleFor(a => a.PageId)
                .NotEmpty().NotNull().WithMessage("Sayfa bilgisi gerekli");

            RuleFor(a => a.DepartmentId)
         .NotEmpty().NotNull().WithMessage("Department bilgisi gerekli");


            RuleFor(a => a.PagePermissionId)
                .NotEmpty().NotNull().WithMessage("Yetki bilgisi zorunlu.");
 
            RuleFor(a => a.HasPermission)
                .NotNull().WithMessage("HasPermission bilgisi zorunlu.");
  
        }
    }
}
