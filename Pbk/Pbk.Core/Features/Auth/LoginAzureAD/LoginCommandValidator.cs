 



using FluentValidation;

namespace Pbk.Core.Features.Auth.Login;
public sealed class LoginAzureCommandValidator : AbstractValidator<LoginAzureCommand>
{
    public LoginAzureCommandValidator()
    {
        RuleFor(p => p.Token).NotEmpty().WithMessage("Geçersiz Token bilgisi");
    }
} 