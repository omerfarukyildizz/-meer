using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Pbk.WebApi.Abstractions;
[Route("[controller]/[action]")]
[ApiController]
[Authorize]
public abstract class ApiController : ControllerBase
{
    public readonly IMediator _mediator;

    protected ApiController(IMediator mediator)
    {
        _mediator = mediator;
    }
}
