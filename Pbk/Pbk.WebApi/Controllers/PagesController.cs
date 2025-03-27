using Pbk.Core.Features.Pages.Get;
using Pbk.Core.Features.Response;
using Pbk.WebApi.Abstractions;
using MediatR; 
using Microsoft.AspNetCore.Mvc; 

namespace Pbk.WebApi.Core.Controllers
{
    public class PagesController : ApiController
    {
        public PagesController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<IActionResult> GetAllPages([FromQuery] PageGetQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return response.status == StatusType.Success ? Ok(response) : BadRequest(response);
        }

       

    }

}
