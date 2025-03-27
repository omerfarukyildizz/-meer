using Pbk.Core.Features.Account.Get;
using Pbk.Core.Features.Countries.Get;
using Pbk.Core.Features.Currencies.Get;
using Pbk.Core.Features.PaymentTypes.Get;
using Pbk.Core.Features.Response;
using Pbk.WebApi.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Pbk.WebApi.Core.Controllers
{

    public class PaymentTypesController : ApiController
    {
        public PaymentTypesController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<IActionResult> GetPaymentType([FromQuery] PaymentTypeGetQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return response.status == StatusType.Success ? Ok(response) : BadRequest(response);
        }
 
      
    }
}
