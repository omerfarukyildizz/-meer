using AutoMapper;
using Pbk.Core.Features.User;
using Pbk.Core.Features.Response;
using Pbk.Core.Utilities.IResults;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pbk.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Pbk.Core.Features.Users.Manager;
using Pbk.Core.Features.Users;

namespace Pbk.Core.Features.Stages.Update.AddToExistingVoyage
{
    internal sealed class StageAddToExistingVoyageCommandHandler : IRequestHandler<StageAddToExistingVoyageCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly IStageRepository _stageRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;
        private readonly IVoyageRepository _voyageRepository;
        private readonly IPlannedStageRepository _plannedStageRepository;
        public StageAddToExistingVoyageCommandHandler(IUserManager userManager, ITranslate tanslate, IMapper mapper, IStageRepository stageRepository, IUnitOfWork unitOfWork, IVoyageRepository voyageRepository, IPlannedStageRepository plannedStageRepository)
        {
            _tanslate = tanslate;
            _stageRepository = stageRepository;
            _mapper = mapper;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _voyageRepository = voyageRepository;
            _plannedStageRepository = plannedStageRepository;
        }

        public async Task<APIResponse> Handle(StageAddToExistingVoyageCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var UserId = _userManager.UserInfo().UserId;

                var yetkiSor = _userManager.isPermesion("Voyages", "Create", request.departmentId);
                if (!yetkiSor)
                {
                    return new(status: OperationResult.Error, messages: "You do not have authorization.", null);
                }


                if (request.StageIds.Count < 1)
                {
                    return new(status: OperationResult.Error, messages: "Please select the stages", null);
                }


                if (request.VoyageId == null || request.VoyageId == 0)
                {
                    return new(status: OperationResult.Error, messages: "Please select the Voyage", null);
                }


                var stagesData = _stageRepository.GetWhere(w => request.StageIds.Contains(w.StageId) && w.IsPassive == false).ToList();
                if (stagesData.Count < 1)
                {
                    return new(status: OperationResult.Error, messages: "Stages not found.", null);
                }


                var voyage = await _voyageRepository.GetByIdAsync(w => w.VoyageId == request.VoyageId && w.IsPassive == false, cancellationToken);
                if (voyage == null)
                {
                    return new(status: OperationResult.Error, messages: "Voyage not found.", null);
                }


                var maxSeq = _stageRepository.GetWhere(w => w.IsPassive == false && w.VoyageId == request.VoyageId).Max(w => w.VoyageSequence) ?? 0;


                foreach (var item in stagesData.OrderBy(w => w.LoadingTime))
                {
                    maxSeq++;
                    item.VoyageId = request.VoyageId;
                    item.VoyageSequence = maxSeq;
                    item.StatusTypeId = 3;
                    item.UpdUser = UserId;
                    item.UpdTime = DateTime.Now;
                    _stageRepository.Update(item);
                }


                if (request.isSenderVoyageAddStage == true)
                {
                    var stages = stagesData.Select(w => w.StageId).ToList();
                    var planeds = _plannedStageRepository.GetWhere(w => stages.Contains(w.StageId) && !w.IsPassive).ToList();
                    if (planeds.Count > 0)
                    {
                        foreach (var item in planeds)
                        {
                            item.IsPassive = true;
                            _plannedStageRepository.Update(item);
                        }
                    }
                }



                await _unitOfWork.SaveChangesAsync();


                return new(status: OperationResult.Success, messages: "", null);
            }
            catch (Exception ex)
            {
                return new(status: OperationResult.Error, messages: ex.Message, null);
            }

        }

    }

}
