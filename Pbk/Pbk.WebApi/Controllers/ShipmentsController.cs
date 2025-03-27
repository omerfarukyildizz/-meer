using Pbk.Core.Features.Response;
using Pbk.Core.Features.Shipments.Create;
using Pbk.Core.Features.Shipments.Remove;
using Pbk.Core.Features.Shipments.Update;
using Pbk.Core.Utilities.Roles;
using Pbk.DataAccess.Authorization;
using Pbk.WebApi.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pbk.Core.Features.Locations.Get;
using Pbk.Core.Features.Shipments.Get;

namespace Pbk.WebApi.Core.Controllers
{
    public class ShipmentController : ApiController
    {
        public ShipmentController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<IActionResult> GetShipmentToCustomerByDepartmentId([FromQuery] ShipmentToCustomerByDepartmentIdGetQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return response.status == StatusType.Success ? Ok(response) : BadRequest(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetShipmentToCustomerByCostItem([FromQuery] ShipmentToCustomerByCostItemGetQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return response.status == StatusType.Success ? Ok(response) : BadRequest(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetShipmentToCustomer([FromQuery] ShipmentToCustomerGetQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return response.status == StatusType.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetSpShipments([FromQuery] ShipmentSpGetQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return response.status == StatusType.Success ? Ok(response) : BadRequest(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetShipments([FromQuery] ShipmentGetQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return response.status == StatusType.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        //[RoleFilter([1,2])]
        public async Task<IActionResult> add( ShipmentCreateCommand request, CancellationToken cancellationToken)
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
        public async Task<IActionResult> update(ShipmentUpdateCommand request, CancellationToken cancellationToken)
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
        public async Task<IActionResult> remove(ShipmentRemoveCommand request, CancellationToken cancellationToken)
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
