using Pbk.Core.Features.Auth.Login;
using Pbk.Core.Features.CostItems.Create;
using Pbk.Core.Features.CostItems.Update;
using Pbk.Core.Features.CostItems.Remove;
using Pbk.Core.Features.Response;
using Pbk.WebApi.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pbk.Core.Features.Stages.Get;
using Pbk.Core.Features.CostItems.Get;

namespace Pbk.WebApi.Core.Controllers
{
    public class CostItemController : ApiController
    {
        public CostItemController(IMediator mediator) : base(mediator) { }


        [HttpGet]
        public async Task<IActionResult> GetCostItemByDepartmentId([FromQuery] CostItemByDepartmentIdGetQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return response.status == StatusType.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetSpCostItemList([FromQuery] CostItemListGetQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return response.status == StatusType.Success ? Ok(response) : BadRequest(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetSpCostItemByParam([FromQuery] CostItemByParamGetQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return response.status == StatusType.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetCostItem([FromQuery] CostItemGetQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return response.status == StatusType.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<IActionResult> add(CostItemCreateCommand request, CancellationToken cancellationToken)
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
        public async Task<IActionResult> update(CostItemUpdateCommand request, CancellationToken cancellationToken)
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
        public async Task<IActionResult> remove(CostItemRemoveCommand request, CancellationToken cancellationToken)
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



        [HttpGet]
        public async Task<IActionResult> VendorGetQuery([FromQuery] VendorGetQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return response.status == StatusType.Success ? Ok(response) : BadRequest(response);
        }



    }

}
