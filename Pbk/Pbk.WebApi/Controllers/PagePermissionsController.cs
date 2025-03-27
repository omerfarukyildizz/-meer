using Pbk.Core.Features.Auth.Login;
using Pbk.Core.Features.Authority.Create;
using Pbk.Core.Features.Authority.Update;
using Pbk.Core.Features.Authority.Remove;
using Pbk.Core.Features.Response;
using Pbk.WebApi.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pbk.Core.Features.Roles.Get;
using Pbk.Core.Features.PagePermissions.Get;

namespace Pbk.WebApi.Core.Controllers
{
    public class PagePermissionsController : ApiController
    {
        public PagePermissionsController(IMediator mediator) : base(mediator) { }


        [HttpGet]
        public async Task<IActionResult> GetPageHUser([FromQuery] PagePermissionGetQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return response.status == StatusType.Success ? Ok(response) : BadRequest(response);
        }

    }

}
