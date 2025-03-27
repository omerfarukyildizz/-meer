using MediatR;
using Microsoft.AspNetCore.Mvc;
using Edp.WebApi.AzureAD.Abstractions;
using Edp.Core.Features.Auth.Login;
using Edp.Core.Behaviors;
namespace Edp.WebApi.AzureAD.Controllers;


public sealed class AuthController : ApiController
{
    public AuthController(IMediator mediator) : base(mediator)
    { }

    [HttpPost]
    public async Task<IActionResult> LoginAzureAD(LoginAzureCommand request, CancellationToken cancellationToken)
    {
        try
        {

            //AppHelper.Language = request.Language;
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);

        }
        catch (Exception ex)
        {
            return Ok(new LoginCommandResponse(null, null, "error", ex.Message.Trim()));
        }
    }

}
