using Pbk.Core.Features.Auth.Login;
using Pbk.Core.Features.Drivers.Create;
using Pbk.Core.Features.Drivers.Update;
using Pbk.Core.Features.Drivers.Remove;
using Pbk.Core.Features.Response;
using Pbk.WebApi.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pbk.Core.Features.Carriers.Get;
using Pbk.Core.Features.Drivers.Get;
using Pbk.Core.Features.VehicleTypes.Get;

namespace Pbk.WebApi.Core.Controllers
{
    public class VehicleTypesController : ApiController
    {
        public VehicleTypesController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<IActionResult> GetVehicleTypes([FromQuery] VehicleTypesGetQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return response.status == StatusType.Success ? Ok(response) : BadRequest(response);
        }


    }

}
