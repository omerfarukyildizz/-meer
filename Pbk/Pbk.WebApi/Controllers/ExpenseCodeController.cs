using Pbk.Core.Features.Auth.Login;
using Pbk.Core.Features.Voyages.Create;
using Pbk.Core.Features.Voyages.Update;
using Pbk.Core.Features.Voyages.Remove;
using Pbk.Core.Features.Response;
using Pbk.WebApi.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pbk.Core.Features.Stages.Get;
using Pbk.Core.Features.Voyages.Get;
using Pbk.Core.Features.ExpenseCodes.Get;
using Pbk.Core.Features.ExpenseCodes.Create;
using Pbk.Core.Features.ExpenseCodes.Update;
using Pbk.Core.Features.ExpenseCodes.Remove;

namespace Pbk.WebApi.Core.Controllers
{
    public class ExpenseCodeController : ApiController
    {
        public ExpenseCodeController(IMediator mediator) : base(mediator) { }


        [HttpGet]
        public async Task<IActionResult> GetExpenseCode([FromQuery] GetExpenseCodeQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return response.status == StatusType.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetExpense([FromQuery] GetExpenseQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return response.status == StatusType.Success ? Ok(response) : BadRequest(response);
        }


        [HttpPost]
        public async Task<IActionResult> add(ExpenseCodeCreateCommand request, CancellationToken cancellationToken)
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
        public async Task<IActionResult> update(ExpenseCodeUpdateCommand request, CancellationToken cancellationToken)
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
        public async Task<IActionResult> remove(ExpenseCodeRemoveCommand request, CancellationToken cancellationToken)
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
