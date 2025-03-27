using Pbk.Core.Features.Response;
using Pbk.WebApi.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pbk.Core.Features.RevenueCodes.Get;
using Pbk.Core.Features.RevenueCodes.Create;
using Pbk.Core.Features.RevenueCodes.Update;
using Pbk.Core.Features.RevenueCodes.Remove;

namespace Pbk.WebApi.Core.Controllers
{
    public class RevenueCodeController : ApiController
    {
        public RevenueCodeController(IMediator mediator) : base(mediator) { }


        [HttpGet]
        public async Task<IActionResult> GetRevenueCode([FromQuery] GetRevenueCodeQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return response.status == StatusType.Success ? Ok(response) : BadRequest(response);
        }


        [HttpPost]
        public async Task<IActionResult> add(RevenueCodeCreateCommand request, CancellationToken cancellationToken)
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
        public async Task<IActionResult> update(RevenueCodeUpdateCommand request, CancellationToken cancellationToken)
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
        public async Task<IActionResult> remove(RevenueCodeRemoveCommand request, CancellationToken cancellationToken)
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
