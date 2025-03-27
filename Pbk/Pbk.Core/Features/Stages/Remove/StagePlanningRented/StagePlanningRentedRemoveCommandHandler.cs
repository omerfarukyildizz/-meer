using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Core.Features.Stages.Remove.StagePlanning;
using Pbk.Core.Features.User;
using Pbk.Core.Utilities.IResults;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Stages.Remove.StagePlanningRented
{
   

    internal sealed class StagePlanningRentedRemoveCommandHandler : IRequestHandler<StagePlanningRentedRemoveCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly IStageRepository _stageRepository;
        private readonly IPlannedStageRepository _plannedStageRepository;
        private readonly IUnitOfWork _unitOfWork;

        public StagePlanningRentedRemoveCommandHandler(ITranslate tanslate, IMapper mapper, IStageRepository stageRepository, IUnitOfWork unitOfWork, IPlannedStageRepository plannedStageRepository)
        {
            _tanslate = tanslate;
            _stageRepository = stageRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _plannedStageRepository = plannedStageRepository;
        }

        public async Task<APIResponse> Handle(StagePlanningRentedRemoveCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var plannedStage = _plannedStageRepository.GetWhere(w => w.StageId == request.StageId && w.VehicleId == request.CarrierId && w.IsPassive == false).FirstOrDefault();
                var stage = _stageRepository.GetWhere(x => x.IsPassive == false && x.StageId == request.StageId).FirstOrDefault();
                if (stage == null)
                {
                    return new(status: OperationResult.Error, messages: "Geçersiz stage bilgisi.", null);

                }
                if (plannedStage == null)
                {
                    return new(status: OperationResult.Error, messages: "Geçersiz planned bilgisi.", null);

                }
                plannedStage.IsPassive = true;
                stage.StatusTypeId = 1;
                var liste = _plannedStageRepository.GetWhere(d => d.CarrierId == request.CarrierId && !d.IsPassive && d.PlanningSequence > plannedStage.PlanningSequence).ToList();
                if (liste.Count > 0)
                {
                    foreach (var item in liste)
                    {
                        item.PlanningSequence--;
                        _plannedStageRepository.Update(item);
                    }
                }


                _stageRepository.Update(stage);
                _plannedStageRepository.Update(plannedStage);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new(status: OperationResult.Success, messages: "", stage);
            }
            catch (Exception ex)
            {
                return new(status: OperationResult.Error, messages: ex.Message, null);
            }

        }

    }
}
