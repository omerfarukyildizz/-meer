using Pbk.Core.Features.Auth.Login;
using Pbk.Core.Features.Parameters.Create;
using Pbk.Core.Features.Parameters.Update;
using Pbk.Core.Features.Parameters.Remove;
using Pbk.Core.Features.Response;
using Pbk.WebApi.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pbk.Core.Features.Parameters.Get;
using Pbk.Core.Features.ParameterValues.Get;
using Pbk.Core.Features.ParameterValues.Create;
using Pbk.Core.Features.ParameterValues.Update;
using Pbk.Core.Features.ParameterValues.Remove;

namespace Pbk.WebApi.Core.Controllers
{
    public class ParameterValuesController : ApiController
    {
        public ParameterValuesController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] ParameterValueGetQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return response.status == StatusType.Success ? Ok(response) : BadRequest(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetByParameterIdList([FromQuery] ParameterValueByParameterIdGetQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return response.status == StatusType.Success ? Ok(response) : BadRequest(response);
        }


        [HttpPost]
        public async Task<IActionResult> add(ParameterValueCreateCommand request, CancellationToken cancellationToken)
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
        public async Task<IActionResult> update(ParameterValueUpdateCommand request, CancellationToken cancellationToken)
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
        public async Task<IActionResult> remove(ParameterValueRemoveCommand request, CancellationToken cancellationToken)
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
