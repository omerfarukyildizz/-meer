using Pbk.Core.Features.Auth.Login;
using Pbk.Core.Features.Shipments.Create;
using Pbk.Core.Features.Shipments.Update;
using Pbk.Core.Features.Shipments.Remove;
using Pbk.Core.Features.Response;
using Pbk.WebApi.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pbk.Core.Features.ShipmentTypes.Get;

namespace Pbk.WebApi.Core.Controllers
{
    public class ShipmentTypesController : ApiController
    {
        public ShipmentTypesController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<IActionResult> GetShipmentType([FromQuery] ShipmentTypeNameGetQuery request, CancellationToken cancellationToken)
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
