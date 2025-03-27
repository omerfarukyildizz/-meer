using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Core.Features.User;
using Pbk.Core.Features.Users;
using Pbk.Core.Utilities.IResults;
using Pbk.Entities.Models;
using Pbk.Entities.Models2;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Stages.Update.PlanningSequence
{

    internal sealed class PlanningSequenceCommandHandler : IRequestHandler<PlanningSequenceCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly IStageRepository _stageRepository;
        private readonly IPlannedStageRepository _plannedStageRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;
        private readonly IDynamicEmptyKmRepositor _dynamicEmptyKmRepositor;



        public PlanningSequenceCommandHandler(IUserManager userManager, ITranslate tanslate, IMapper mapper, IStageRepository stageRepository, IUnitOfWork unitOfWork, IPlannedStageRepository plannedStageRepository, IDynamicEmptyKmRepositor dynamicEmptyKmRepositor)
        {
            _tanslate = tanslate;
            _stageRepository = stageRepository;
            _mapper = mapper;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _plannedStageRepository = plannedStageRepository;
            _dynamicEmptyKmRepositor = dynamicEmptyKmRepositor;
        }

        public async Task<APIResponse> Handle(PlanningSequenceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var UserId = _userManager.UserInfo().UserId;

                Entities.Models.PlannedStage data = await _plannedStageRepository.GetByIdAsync(w => w.PlannedStageId == request.PlannedStageId, cancellationToken);

                if (data == null)
                {
                    return new(status: OperationResult.Error, messages: "Kayıt Bulunamadı.", null);
                }

                if (data.PlanningSequence > request.PlanningSequence)
                {
                    // Yükselen sıralama durumunda, diğer sıralar bir artırılır.
                    var liste = _plannedStageRepository.GetWhere(w => w.VehicleId == data.VehicleId
                                                                      && !w.IsPassive
                                                                      && w.PlanningSequence >= request.PlanningSequence
                                                                      && w.PlanningSequence < data.PlanningSequence
                                                                      && w.PlannedStageId != request.PlannedStageId)
                                                        .OrderBy(w => w.PlanningSequence)
                                                        .ToList();

                    data.PlanningSequence = request.PlanningSequence;

                    foreach (var item in liste)
                    {
                        item.PlanningSequence++;
                        _plannedStageRepository.Update(item);
                    }
                }
                else if (data.PlanningSequence < request.PlanningSequence)
                {
                    // Azalan sıralama durumunda, diğer sıralar bir azaltılır.
                    var liste = _plannedStageRepository.GetWhere(w => w.VehicleId == data.VehicleId
                                                                      && !w.IsPassive
                                                                      && w.PlanningSequence <= request.PlanningSequence
                                                                      && w.PlanningSequence > data.PlanningSequence
                                                                      && w.PlannedStageId != request.PlannedStageId)
                                                        .OrderByDescending(w => w.PlanningSequence)
                                                        .ToList();

                    data.PlanningSequence = request.PlanningSequence;

                    foreach (var item in liste)
                    {
                        item.PlanningSequence--;
                        _plannedStageRepository.Update(item);
                    }
                }

                _plannedStageRepository.Update(data);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                var msg = "";
                if (data.VehicleId.HasValue && data.VehicleId>0)
                {

                    if ((data.PlanningSequence ?? 0) == 1 )
                    {
                        var dynamicKM = await _stageRepository.getDynamicKM(data.VehicleId ?? 0);
                        if (dynamicKM != null)
                        {
                            var KontrolDynamic = _dynamicEmptyKmRepositor.GetWhere(w => w.VehicleId == data.VehicleId).FirstOrDefault();
                            if (KontrolDynamic == null)
                            {
                                if(data.VehicleId>0 && data.VehicleId != null)
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








                    // dynamicKMcalculation(data.PlanningSequence ?? 0, data.VehicleId ?? 0, 1);
                }


                return new(status: OperationResult.Success, messages: msg, data);
            }
            catch (Exception ex)
            {
                return new(status: OperationResult.Error, messages: ex.Message, null);
            }

        }

        public async void dynamicKMcalculation(int PlanningSequence, int VehicleId, int kosul)
        {
            if ((PlanningSequence) == kosul)
            {
                var dynamicKM = await _stageRepository.getDynamicKM(VehicleId);
                if (dynamicKM != null)
                {
                    var KontrolDynamic = _dynamicEmptyKmRepositor.GetWhere(w => w.VehicleId == VehicleId).FirstOrDefault();
                    if (KontrolDynamic == null)
                    {
                        var newDynemicKM = new DynamicEmptyKm();
                        newDynemicKM.CalculatedKm = dynamicKM;
                        newDynemicKM.VehicleId = VehicleId;
                        newDynemicKM.InsTime = DateTime.Now;
                        await _dynamicEmptyKmRepositor.AddAsync(newDynemicKM);
                    }
                    else
                    {
                        KontrolDynamic.CalculatedKm = dynamicKM;
                        _dynamicEmptyKmRepositor.Update(KontrolDynamic);

                    }
                    await _unitOfWork.SaveChangesAsync();
                }
            }
        }

    }

}
