using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Edp.WebApi.AzureAD.Abstractions;
[Route("api/[controller]/[action]")]
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
