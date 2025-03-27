using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pbk.WebApi.Abstractions;
using Pbk.Core.Features.Auth.Login;
using Pbk.Core.Behaviors;
using Pbk.Core.Features.Response;
using Pbk.Core.Features.Account.Get;
using Pbk.Core.Features.Drivers.Create;
using Pbk.Core.Features.Account.Create;
using Pbk.Core.Features.Drivers.Update;
using Pbk.Core.Features.Account.Update;
using Pbk.Core.Features.Carriers.Remove;
using Pbk.Core.Features.Account.Remove;


namespace Pbk.WebApi.Controllers;

//[AllowAnonymous]
public sealed class AccountController : ApiController
{
    public AccountController(IMediator mediator) : base(mediator) { }


    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] AccountGetUserQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return response.status == StatusType.Success ? Ok(response) : BadRequest(response);
    }

    [HttpPost]
    public async Task<IActionResult> add(UserCreateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return Ok(new APIResponse("Fail", ex.Message, null));
        }
    }

    [HttpPut]
    public async Task<IActionResult> update(UserUpdateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return Ok(new APIResponse("Fail", ex.Message, null));
        }
    }
    [HttpDelete]
    public async Task<IActionResult> remove(UserRemoveCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return Ok(new APIResponse("Fail", ex.Message, null));
        }
    }

}
