﻿using MediatR;

namespace Pbk.Core.Features.Auth.Register;
public sealed record RegisterCommand(
    string Name,
    string Lastname,
    string Email,
    string UserName,
    string Password): IRequest<Unit>;
