using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Core.Features.User;
using Pbk.Core.Utilities.IResults;
using Pbk.Entities.Models;
using Pbk.Entities.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Pbk.Core.Features.Stages.Remove.StagePlanning
{
  

    internal sealed class StagePlanningRemoveCommandHandler : IRequestHandler<StagePlanningRemoveCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly IStageRepository _stageRepository;
        private readonly IPlannedStageRepository _plannedStageRepository;
        private readonly IDynamicEmptyKmRepositor _dynamicEmptyKmRepositor;
        private readonly IUnitOfWork _unitOfWork;

        public StagePlanningRemoveCommandHandler(ITranslate tanslate, IMapper mapper, IStageRepository stageRepository, IUnitOfWork unitOfWork, IPlannedStageRepository plannedStageRepository, IDynamicEmptyKmRepositor dynamicEmptyKmRepositor)
        {
            _tanslate = tanslate;
            _stageRepository = stageRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _plannedStageRepository = plannedStageRepository;
            _dynamicEmptyKmRepositor = dynamicEmptyKmRepositor;
        }

        public async Task<APIResponse> Handle(StagePlanningRemoveCommand request, CancellationToken cancellationToken)
        {
            try
            {
                
                var plannedStage = _plannedStageRepository.GetWhere(w=>w.StageId==request.StageId && w.VehicleId==request.VehicleId && w.IsPassive==false).FirstOrDefault();
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
                var liste = _plannedStageRepository.GetWhere(d => d.VehicleId == request.VehicleId && !d.IsPassive && d.PlanningSequence > plannedStage.PlanningSequence).ToList();
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

                var msg = "";

                try
                {

                    var data = _plannedStageRepository.GetWhere(w => w.VehicleId == request.VehicleId && !w.IsPassive).OrderBy(w => w.PlanningSequence).FirstOrDefault();
                    if ((data.PlanningSequence ?? 1) == 1)
                    {
                        var dynamicKM = await _stageRepository.getDynamicKM(data.VehicleId ?? 0);
                        if (dynamicKM != null)
                        {
                            var KontrolDynamic = _dynamicEmptyKmRepositor.GetWhere(w => w.VehicleId == data.VehicleId).FirstOrDefault();
                            if (KontrolDynamic == null)
                            {
                                if (data.VehicleId > 0 && data.VehicleId != null)
                                {
                                    var newDynemicKM = new DynamicEmptyKm();
                                    newDynemicKM.CalculatedKm = dynamicKM;
                                    newDynemicKM.VehicleId = data.VehicleId ?? 0;
                                    newDynemicKM.InsTime = DateTime.Now;
                                    await _dynamicEmptyKmRepositor.AddAsync(newDynemicKM);
                                }
                            }
                            else
                            {
                                KontrolDynamic.CalculatedKm = dynamicKM;
                                _dynamicEmptyKmRepositor.Update(KontrolDynamic);
                            }

                            msg = dynamicKM.ToString();

                            await _unitOfWork.SaveChangesAsync(cancellationToken);

                        }
                    }

                }catch (Exception ex)  {   }

                return new(status: OperationResult.Success, messages: msg, stage);
            }
            catch (Exception ex)
            {
                return new(status: OperationResult.Error, messages: ex.Message, null);
            }

        }

    }


}
