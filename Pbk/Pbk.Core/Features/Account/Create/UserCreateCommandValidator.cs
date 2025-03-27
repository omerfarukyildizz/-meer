using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Account.Create
{

    public sealed class UserCreateCommandValidator : AbstractValidator<UserCreateCommand>
    {
        public UserCreateCommandValidator()
        {
            RuleFor(x => x.DepartmentId.ToString()).NotEmpty().WithMessage("Departman Boş olamaz.");

            RuleFor(x => x.RoleId.ToString()).NotEmpty().WithMessage("RoleId Boş olamaz.");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Kullanıcı adı boş olamaz.")
                .MaximumLength(100).WithMessage("Kullanıcı adı en fazla 100 karakter olmalıdır.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre boş olamaz.")
                .MaximumLength(1000).WithMessage("Şifre en fazla 1000 karakter olmalıdır.");

            RuleFor(x => x.Position)
                .MaximumLength(50).WithMessage("Pozisyon en fazla 50 karakter olmalıdır.")
                .When(x => !string.IsNullOrEmpty(x.Position));

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi girin.")
                .MaximumLength(50).WithMessage("E-posta en fazla 50 karakter olmalıdır.")
                .When(x => !string.IsNullOrEmpty(x.Email));

            RuleFor(x => x.Phone)
                .MaximumLength(50).WithMessage("Telefon numarası en fazla 50 karakter olmalıdır.")
                .When(x => !string.IsNullOrEmpty(x.Phone));

        }
    }
}
