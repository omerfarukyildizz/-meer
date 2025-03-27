using Pbk.Core.Features.Locations.Create;
using Pbk.Core.Features.Locations.Update;
using Pbk.Core.Features.Locations.Remove;
using Pbk.Core.Features.Response;
using Pbk.WebApi.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pbk.Core.Features.Locations.Get;

namespace Pbk.WebApi.Core.Controllers
{
    public class LocationController : ApiController
    {
        public LocationController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<IActionResult> GetSourceAndTargetLocation([FromQuery] LocationSourceAndTargetGetQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return response.status == StatusType.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLocation([FromQuery] LocationGetQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return response.status == StatusType.Success ? Ok(response) : BadRequest(response);
        }
        [HttpPost]
        public async Task<IActionResult> add(LocationCreateCommand request, CancellationToken cancellationToken)
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
        public async Task<IActionResult> update(LocationUpdateCommand request, CancellationToken cancellationToken)
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
        public async Task<IActionResult> remove(LocationRemoveCommand request, CancellationToken cancellationToken)
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

}
