using MediatR;

namespace Pbk.Core.Features.Auth.Login;
public sealed record LoginAzureCommand(
    string Language,
    string Token
   ): IRequest<LoginCommandResponse>;
