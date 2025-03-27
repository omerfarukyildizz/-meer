using Pbk.Core.Features.Auth.Login;
using Pbk.Core.Features.Stages.Create;
using Pbk.Core.Features.Stages.Update;
using Pbk.Core.Features.Stages.Remove;
using Pbk.Core.Features.Response;
using Pbk.WebApi.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pbk.Core.Features.Sectors.Get;
using Pbk.Core.Features.Stages.Get;
using Pbk.Core.Features.Stages.Update.StagePlanning;
using Pbk.Core.Features.Stages.Remove.StagePlanning;
using Pbk.Core.Features.Stages.Update.StagePlanningRented;
using Pbk.Core.Features.Stages.Update.PlanningSequenceRented;
using Pbk.Core.Features.Stages.Update.PlanningSequence;
using Pbk.Core.Features.Stages.Update.AddToExistingVoyage;
using Pbk.Core.Features.Stages.Update.StatusUpdate;

namespace Pbk.WebApi.Core.Controllers
{
    public class StageController : ApiController
    {
        public StageController(IMediator mediator) : base(mediator) { }


        [HttpGet]
        public async Task<IActionResult> GetStageByDepartmentId([FromQuery] StageByDepartmentIdGetQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return response.status == StatusType.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetStageByShipmentId([FromQuery] StageByShipmentIdGetQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return response.status == StatusType.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetStageByVoyageId([FromQuery] StageByVoyageIdGetQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return response.status == StatusType.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetSpStage([FromQuery] StageSpGetQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return response.status == StatusType.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet]
        public async Task<IActionResult> StageListVoyagesGetQuery([FromQuery] StageListVoyagesGetQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return response.status == StatusType.Success ? Ok(response) : BadRequest(response);
        }

         
        [HttpPost]
        public async Task<IActionResult> add(StageCreateCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return response.status == StatusType.Success ? Ok(response) : BadRequest(response);
        }


        [HttpPost]
        public async Task<IActionResult> AddToExistingVoyage(StageAddToExistingVoyageCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return response.status == StatusType.Success ? Ok(response) : BadRequest(response);
        }


        [HttpPut]
        public async Task<IActionResult> update(StageUpdateCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return response.status == StatusType.Success ? Ok(response) : BadRequest(response);
        }


        [HttpPut]
        public async Task<IActionResult> addPlannedStage(StagePlanningCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return response.status == StatusType.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<IActionResult> addPlannedSequenceStage(PlanningSequenceCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return response.status == StatusType.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<IActionResult> addPlannedRentedStage(StagePlanningRentedCommand request, CancellationToken cancellationToken)
        {

            var response = await _mediator.Send(request, cancellationToken);
            return response.status == StatusType.Success ? Ok(response) : BadRequest(response);

        }

        [HttpPut]
        public async Task<IActionResult> addPlannedSequenceRentedStage(PlanningSequenceRentedCommand request, CancellationToken cancellationToken)
        {

            var response = await _mediator.Send(request, cancellationToken);
            return response.status == StatusType.Success ? Ok(response) : BadRequest(response);

        }


        [HttpPut]
        public async Task<IActionResult> statusUpdate(StatusUpdateCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return response.status == StatusType.Success ? Ok(response) : BadRequest(response);
        }
         

        [HttpDelete]
        public async Task<IActionResult> removePlannedDeleteStage(StagePlanningRemoveCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return response.status == StatusType.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete]
        public async Task<IActionResult> remove(StageRemoveCommand request, CancellationToken cancellationToken)
        {

            var response = await _mediator.Send(request, cancellationToken);
            return response.status == StatusType.Success ? Ok(response) : BadRequest(response);
        }

    }
}
