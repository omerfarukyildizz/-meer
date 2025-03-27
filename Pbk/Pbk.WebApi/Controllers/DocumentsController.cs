using Pbk.Core.Features.Auth.Login;
using Pbk.Core.Features.Documents.Create;
using Pbk.Core.Features.Documents.Update;
using Pbk.Core.Features.Documents.Remove;
using Pbk.Core.Features.Response;
using Pbk.WebApi.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pbk.Core.Features.Carriers.Get;
using Pbk.Core.Features.Documents.Get;

namespace Pbk.WebApi.Core.Controllers
{
    public class DocumentController : ApiController
    {
        public DocumentController(IMediator mediator) : base(mediator) { }

        //[HttpGet]
        //public async Task<IActionResult> GetArchiveTypes([FromQuery] DocumentGetArchiveTypesQuery request, CancellationToken cancellationToken)
        //{
        //    var response = await _mediator.Send(request, cancellationToken);
        //    return response.status == StatusType.Success ? Ok(response) : BadRequest(response);
        //}


        [HttpGet]
        public async Task<IActionResult> GetDocuments([FromQuery] DocumentGetQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return response.status == StatusType.Success ? Ok(response) : BadRequest(response);
        } 

        [HttpDelete]
        public async Task<IActionResult> remove(DocumentRemoveCommand request, CancellationToken cancellationToken)
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
