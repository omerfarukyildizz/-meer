using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Core.Features.Stages.Update.PlanningSequence;
using Pbk.Core.Features.User;
using Pbk.Core.Features.Users;
using Pbk.Core.Utilities.IResults;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Stages.Update.PlanningSequenceRented
{
   
    internal sealed class PlanningSequenceRentedCommandHandler : IRequestHandler<PlanningSequenceRentedCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly IStageRepository _stageRepository;
        private readonly IPlannedStageRepository _plannedStageRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;


        public PlanningSequenceRentedCommandHandler(IUserManager userManager, ITranslate tanslate, IMapper mapper, IStageRepository stageRepository, IUnitOfWork unitOfWork, IPlannedStageRepository plannedStageRepository)
        {
            _tanslate = tanslate;
            _stageRepository = stageRepository;
            _mapper = mapper;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _plannedStageRepository = plannedStageRepository;
        }

        public async Task<APIResponse> Handle(PlanningSequenceRentedCommand request, CancellationToken cancellationToken)
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
                    var liste = _plannedStageRepository.GetWhere(w => w.CarrierId == data.CarrierId
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
                    var liste = _plannedStageRepository.GetWhere(w => w.CarrierId == data.CarrierId
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

                return new(status: OperationResult.Success, messages: "", data);
            }
            catch (Exception ex)
            {
                return new(status: OperationResult.Error, messages: ex.Message, null);
            }

        }

    }
}
