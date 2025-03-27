using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Core.Features.Stages.Update.StagePlanning;
using Pbk.Core.Features.User;
using Pbk.Core.Features.Users;
using Pbk.Core.Utilities.IResults;
using Pbk.Entities.Models;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Pbk.Core.Features.Stages.Update.StagePlanningRented
{
    internal sealed class StagePlanningRentedCommandHandler : IRequestHandler<StagePlanningRentedCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly IStageRepository _stageRepository;
        private readonly ICarrierRepository _carrierRepository;
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IAuthorityRepository _authorityRepository;
        private readonly IPlannedStageRepository _plannedStageRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;

        public StagePlanningRentedCommandHandler(ITranslate tanslate, IMapper mapper, IStageRepository stageRepository, ICarrierRepository carrierRepository, IShipmentRepository shipmentRepository, IAuthorityRepository authorityRepository, IPlannedStageRepository plannedStageRepository, IUnitOfWork unitOfWork, IUserManager userManager)
        {
            _tanslate = tanslate;
            _mapper = mapper;
            _stageRepository = stageRepository;
            _carrierRepository = carrierRepository;
            _shipmentRepository = shipmentRepository;
            _authorityRepository = authorityRepository;
            _plannedStageRepository = plannedStageRepository;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }




        ///https://barsan.atlassian.net/wiki/spaces/NE/pages/180781057/Domestic+Shipments 
        public async Task<APIResponse> Handle(StagePlanningRentedCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var User = _userManager.UserInfo();

                var stage = _stageRepository.GetByIdAsync(w => w.StageId == request.StageId).Result;
                if (stage == null)
                    return new(status: OperationResult.Error, messages: "Stage bulunamadı", null);

                var carrier = _carrierRepository.GetByIdAsync(b => b.CarrierId == request.CarrierId).Result;
                if (carrier == null)
                    return new(status: OperationResult.Error, messages: "Carrier bulunamadı", null);

                var shipment = _shipmentRepository.GetByIdAsync(p => p.ShipmentId == stage.ShipmentId).Result;

                if (shipment == null)
                    return new(status: OperationResult.Error, messages: "Shipment bulunamadı", null);

                // --KURALLAR--
                //1. KURAL Stage Waiting olup olmadığı kontrol ediliyor.
                if (stage.StatusTypeId != 1) // waiting = 1
                    return new(status: OperationResult.Error, messages: "Stage statüsü Waiting olmalı.", null);

                //2. KURAL  Shipment'ın PlanningDepartmentId değeri var ise yani NULL değil ise o zaman Authority tablosundan kullanıcının PlanningDepartmentId için 'Planning' yetkisi olup olmadığı kontrol edilir.


                bool isPlaning = shipment.PlanningDepartmentId != null;
                var departman = isPlaning ? shipment.PlanningDepartmentId : shipment.DepartmentId;

                bool planningCheck = _userManager.isPermesion("Shipments", "Planning", departman);
                if (!planningCheck)
                {
                    return new(status: OperationResult.Error, messages: isPlaning ? "This stage will be planned by the Planning Department." : "You do not have permission to Planning this stage(s)", null);
                }

                //3. LTL ve FTL Kontrolleri

                string shipmentTypeCheck = _plannedStageRepository.GetCheckStagePlanningByCarrierId(request.StageId, request.CarrierId);
                if (shipmentTypeCheck != "OK" && request.LTLandFTLControl == true)
                {
                    return new(status: OperationResult.Check, messages: shipmentTypeCheck, "shipmentTypeCheck");
                }

                var StagePlanlingCheckRow =
                    _plannedStageRepository.GetWhere(w => w.CarrierId == request.CarrierId && w.IsPassive == false).OrderByDescending(w => w.PlanningSequence).FirstOrDefault();

                 

                // 4 kural

                bool departmanCheck = shipment.PlanningDepartmentId == carrier.DepartmentId || shipment.DepartmentId == carrier.DepartmentId;
                if (!departmanCheck)
                {
                    return new(status: OperationResult.Error, messages: "You cannot assign this carrier to the stage(s) because the carrier's department does not match the shipment's department or planning department.", null);
                }


                // 5. kural


                var checkPlan = _plannedStageRepository.GetByIdAsync(w => w.CarrierId == request.CarrierId && w.StageId == request.StageId).Result;

                if (checkPlan != null)
                {
                    checkPlan.IsPassive = false;
                    _plannedStageRepository.Update(checkPlan);
                }
                else
                {

                    var planet = new PlannedStage();
                    planet.StageId = request.StageId;
                    planet.CarrierId = request.CarrierId;
                    planet.InsUser = User.UserId;
                    planet.PlanningSequence = ((StagePlanlingCheckRow.PlanningSequence ?? 0) + 1);

                    await _plannedStageRepository.AddAsync(planet, cancellationToken);

                }


                stage.StatusTypeId = 2;
                _stageRepository.Update(stage);

                 


                await _unitOfWork.SaveChangesAsync(cancellationToken);
                return new(status: OperationResult.Success, messages: "", null);
            }
            catch (Exception ex)
            {
                return new(status: OperationResult.Error, messages: ex.Message, null);
            }

        }

    }
}
