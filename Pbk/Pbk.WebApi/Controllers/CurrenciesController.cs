using Pbk.Core.Features.Account.Get;
using Pbk.Core.Features.Countries.Get;
using Pbk.Core.Features.Currencies.Get;
using Pbk.Core.Features.Response;
using Pbk.WebApi.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Pbk.WebApi.Core.Controllers
{

    public class CurrenciesController : ApiController
    {
        public CurrenciesController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<IActionResult> GetCurrency([FromQuery] CurrencyNameGetQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return response.status == StatusType.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCountries([FromQuery] CurrencyGetQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return response.status == StatusType.Success ? Ok(response) : BadRequest(response);
        }
      
    }
}
