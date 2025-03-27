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
using Pbk.Core.Features.Roles.Get;


namespace Pbk.WebApi.Controllers;

//[AllowAnonymous]
public sealed class RoleController : ApiController
{
    public RoleController(IMediator mediator) : base(mediator) { }


    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] RoleGetQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return response.status == StatusType.Success ? Ok(response) : BadRequest(response);
    }

}
