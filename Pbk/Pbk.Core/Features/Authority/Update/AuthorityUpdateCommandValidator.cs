using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Authority.Update
{
 
    public sealed class AuthorityUpdateCommandValidator : AbstractValidator<AuthorityUpdateCommand>
    {
        public AuthorityUpdateCommandValidator()
        {

            RuleFor(a => a.AuthorityID)
                .NotEmpty().WithMessage("AuthorityID is required.")
                .GreaterThan(0).WithMessage("AuthorityID must be greater than 0.");


            RuleFor(a => a.Category)
                .NotEmpty().WithMessage("Category is required.")
                .MaximumLength(50).WithMessage("Category can be at most 50 characters long.");


            RuleFor(a => a.PageName)
                .NotEmpty().WithMessage("PageName is required.")
                .MaximumLength(100).WithMessage("PageName can be at most 100 characters long.");


            RuleFor(a => a.PermissionType)
                .NotEmpty().WithMessage("PermissionType is required.")
                .MaximumLength(50).WithMessage("PermissionType can be at most 50 characters long.");


            RuleFor(a => a.HasPermission)
                .NotNull().WithMessage("HasPermission is required.");


        }
    }
}
