using FluentValidation;
namespace Pbk.Core.Features.Auth.Login;
public sealed class ProfileCommandValidator : AbstractValidator<ProfileCommand>
{
    public ProfileCommandValidator()
    {
        //RuleFor(p => p.Email).NotEmpty().WithMessage("Kullanıcı adı boş olamaz");
        //RuleFor(p => p.Email).NotNull().WithMessage("Kullanıcı adı boş olamaz");
        //RuleFor(p => p.Email).MinimumLength(3).WithMessage("Kullanıcı en az 3 karakter olmalıdır");
        //RuleFor(p => p.Password).NotEmpty().WithMessage("Şifre boş olamaz");
        //RuleFor(p => p.Password).NotNull().WithMessage("Şifre boş olamaz");
        //RuleFor(p => p.Password).MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalıdır");
    }
}
