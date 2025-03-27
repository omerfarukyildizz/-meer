using MediatR;

namespace Pbk.Core.Features.Auth.Login;
public sealed record LoginCommand(
    string Email,
    string Password
   ): IRequest<LoginCommandResponse>;
