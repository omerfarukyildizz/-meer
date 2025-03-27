using Pbk.Core.Features.Account.Get;
using Pbk.Core.Features.Countries.Get;
using Pbk.Core.Features.IncoTerms.Get;
using Pbk.Core.Features.Response;
using Pbk.Core.Features.Sectors.Get;
using Pbk.WebApi.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Pbk.WebApi.Core.Controllers
{

    public class IncoTermController : ApiController
    {
        public IncoTermController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<IActionResult> GetIncoTerm([FromQuery] IncoTermGetQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return response.status == StatusType.Success ? Ok(response) : BadRequest(response);
        }

    }
}
