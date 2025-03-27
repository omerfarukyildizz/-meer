using Pbk.Core.Features.Pages.Get;
using Pbk.Core.Features.PlannedStages.Get;
using Pbk.Core.Features.Response;
using Pbk.Core.Features.Stages.Update.PlanningSequence;
using Pbk.WebApi.Abstractions;
using MediatR; 
using Microsoft.AspNetCore.Mvc; 

namespace Pbk.WebApi.Core.Controllers
{
    public class PlannedStagesController : ApiController
    {
        public PlannedStagesController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<IActionResult> GetPlannedStageByVehicleId([FromQuery] PlannedStageGetQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return response.status == StatusType.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<IActionResult> updatePlanningSequence(PlanningSequenceCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return response.status == StatusType.Success ? Ok(response) : BadRequest(response);
        }

    }

}
