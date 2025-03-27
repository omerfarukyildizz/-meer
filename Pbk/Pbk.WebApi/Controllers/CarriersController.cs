using Pbk.Core.Features.Carriers.Create;
using Pbk.Core.Features.Carriers.Get;
using Pbk.Core.Features.Carriers.Remove;
using Pbk.Core.Features.Carriers.Update;
using Pbk.Core.Features.Locations.Get;
using Pbk.Core.Features.Response;
using Pbk.WebApi.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Pbk.WebApi.Core.Controllers
{
    public class CarriersController : ApiController
    {
        public CarriersController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<IActionResult> GetNameCarriers([FromQuery] CarrierGetNameQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return response.status == StatusType.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCarriers([FromQuery] CarrierGetQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return response.status == StatusType.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<IActionResult> add(CarrierCreateCommand request, CancellationToken cancellationToken)
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
        public async Task<IActionResult> update(CarrierUpdateCommand request, CancellationToken cancellationToken)
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
        public async Task<IActionResult> remove(CarrierRemoveCommand request, CancellationToken cancellationToken)
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
