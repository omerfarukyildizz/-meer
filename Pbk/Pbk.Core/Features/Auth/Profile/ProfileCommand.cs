using MediatR;

namespace Pbk.Core.Features.Auth.Login;
public sealed record ProfileCommand() : IRequest<ProfileCommandResponse>;
