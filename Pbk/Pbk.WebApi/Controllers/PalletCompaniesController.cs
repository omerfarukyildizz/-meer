using Pbk.Core.Features.Account.Get;
using Pbk.Core.Features.Countries.Get;
using Pbk.Core.Features.Currencies.Get;
using Pbk.Core.Features.PalletCompanies.Get;
using Pbk.Core.Features.PaymentTypes.Get;
using Pbk.Core.Features.Response;
using Pbk.WebApi.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Pbk.WebApi.Core.Controllers
{

    public class PalletCompaniesController: ApiController
    {
        public PalletCompaniesController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<IActionResult> GetPalletCompanyName([FromQuery] PalletCompanyNameGetQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return response.status == StatusType.Success ? Ok(response) : BadRequest(response);
        }
 
      
    }
}
