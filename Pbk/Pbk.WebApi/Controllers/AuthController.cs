using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pbk.WebApi.Abstractions;
using Pbk.Core.Features.Auth.Login;
using Pbk.Core.Behaviors;
using Pbk.Core.Features.Authority.Get;

namespace Pbk.WebApi.Controllers;

[AllowAnonymous]
public sealed class AuthController : ApiController
{
    public AuthController(IMediator mediator) : base(mediator) { }


    [HttpPost]
    public async Task<IActionResult> Login(LoginCommand request, CancellationToken cancellationToken)
    {
        try
        {
             var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return Ok(new LoginCommandResponse(null, null, "error", ex.Message.Trim()));
        }
    }

    [HttpPost]
    public async Task<IActionResult> LoginAzureAD(LoginAzureCommand request, CancellationToken cancellationToken)
    {
        try
        {
            AppHelper.Language = request.Language;
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return Ok(new LoginCommandResponse(null, null, "error", ex.Message.Trim()));
        }
    }

    [HttpPost]
    public async Task<IActionResult> Profile(LoginCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }





}
