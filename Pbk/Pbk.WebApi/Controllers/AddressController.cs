using Pbk.Core.Features.Account.Get;
using Pbk.Core.Features.Countries.Get;
using Pbk.Core.Features.Places.Get;
using Pbk.Core.Features.Response;
using Pbk.WebApi.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Pbk.WebApi.Core.Controllers
{

    public class AddressController : ApiController
    {
        public AddressController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<IActionResult> GetPlacesByStateWithPlaceId([FromQuery] StateWithPlaceIdGetQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return response.status == StatusType.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCountries([FromQuery] CountryGetQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return response.status == StatusType.Success ? Ok(response) : BadRequest(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetCitiesByCountryId([FromQuery] PlaceGetQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return response.status == StatusType.Success ? Ok(response) : BadRequest(response);
        }
    }
}
