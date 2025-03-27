using Pbk.Core.Features.Auth.Login;
using Pbk.Core.Features.Translations.Create;
using Pbk.Core.Features.Translations.Update;
using Pbk.Core.Features.Translations.Remove;
using Pbk.Core.Features.Response;
using Pbk.WebApi.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Pbk.WebApi.Core.Controllers
{
    public class TranslationController : ApiController
    {
        public TranslationController(IMediator mediator) : base(mediator) { }

        [HttpPost]
        public async Task<IActionResult> add(TranslationCreateCommand request, CancellationToken cancellationToken)
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
        public async Task<IActionResult> update(TranslationUpdateCommand request, CancellationToken cancellationToken)
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
        public async Task<IActionResult> remove(TranslationRemoveCommand request, CancellationToken cancellationToken)
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
