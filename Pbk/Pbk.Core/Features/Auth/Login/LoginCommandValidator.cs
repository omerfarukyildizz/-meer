 
using FluentValidation;
namespace Pbk.Core.Features.Auth.Login;
public sealed class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(p => p.Email).NotEmpty().WithMessage("E-posta adresi zorunludur");
        RuleFor(p => p.Email).NotNull().WithMessage("E-posta adresi zorunludur");
        RuleFor(p => p.Email).EmailAddress().WithMessage("Geçersiz e-posta formatı");
        RuleFor(p => p.Email).MinimumLength(6).WithMessage("E-posta adresi 6 karekterden az olamaz");
        //RuleFor(p => p.Password).MinimumLength(3).WithMessage("Şifre en az 3 karakter olmalıdır");
        RuleFor(p => p.Password).NotEmpty().WithMessage("Şifre zorunlu");
        RuleFor(p => p.Password).NotNull().WithMessage("Şifre Zorunlu");
    }
}

/*RuleFor(p => p.Password).Matches("[A-Z]").WithMessage("Şife en az 1 adet büyük harf içermelidir!");
   RuleFor(p => p.Password).Matches("[a-z]").WithMessage("Şife en az 1 adet küçük harf içermelidir!");
   RuleFor(p => p.Password).Matches("[0-9]").WithMessage("Şife en az 1 adet rakam içermelidir!");
   RuleFor(p => p.Password).Matches("[^a-zA-Z0-9]").WithMessage("Şife en az 1 adet özel karakter içermelidir!");*/