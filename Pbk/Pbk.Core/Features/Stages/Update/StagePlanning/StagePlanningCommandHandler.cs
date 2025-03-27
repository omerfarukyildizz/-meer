using AutoMapper;
using Azure.Core;
using Pbk.Core.Features.Response;
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
using System.Threading;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Pbk.Core.Features.Stages.Update.StagePlanning
{
    // owned
    internal sealed class StagePlanningCommandHandler : IRequestHandler<StagePlanningCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly IStageRepository _stageRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IAuthorityRepository _authorityRepository;
        private readonly IPlannedStageRepository _plannedStageRepository;
        private readonly IDynamicEmptyKmRepositor _dynamicEmptyKmRepositor;
        private readonly IVoyageRepository _voyageRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;

        public StagePlanningCommandHandler(ITranslate tanslate, IMapper mapper, IStageRepository stageRepository, IUnitOfWork unitOfWork, IUserManager userManager, IShipmentRepository shipmentRepository, IVehicleRepository vehicleRepository, IAuthorityRepository authorityRepository, IPlannedStageRepository plannedStageRepository, IDynamicEmptyKmRepositor dynamicEmptyKmRepositor, IVoyageRepository voyageRepository)
        {
            _tanslate = tanslate;
            _mapper = mapper;
            _stageRepository = stageRepository;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _shipmentRepository = shipmentRepository;
            _vehicleRepository = vehicleRepository;
            _authorityRepository = authorityRepository;
            _plannedStageRepository = plannedStageRepository;
            _dynamicEmptyKmRepositor = dynamicEmptyKmRepositor;
            _voyageRepository = voyageRepository;
        }


        ///https://barsan.atlassian.net/wiki/spaces/NE/pages/180781057/Domestic+Shipments owned
        public async Task<APIResponse> Handle(StagePlanningCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var User = _userManager.UserInfo();

                var stage = _stageRepository.GetByIdAsync(w => w.StageId == request.StageId).Result;
                if (stage == null)
                    return new(status: OperationResult.Error, messages: "Stage bulunamadı", null);

                var vehicle = _vehicleRepository.GetByIdAsync(b=>b.VehicleId==request.VehicleId).Result;
                if (vehicle == null)
                    return new(status: OperationResult.Error, messages: "Vehicle bulunamadı", null);

                var shipment = _shipmentRepository.GetByIdAsync(p => p.ShipmentId == stage.ShipmentId).Result;

                if (shipment == null)
                    return new(status: OperationResult.Error, messages: "Shipment bulunamadı", null);

                // --KURALLAR--
                //1. KURAL Stage Waiting olup olmadığı kontrol ediliyor.
                if (stage.StatusTypeId!=1) // waiting = 1
                    return new(status: OperationResult.Error, messages: "Stage statüsü Waiting olmalı.", null);

                //2. KURAL  Shipment'ın PlanningDepartmentId değeri var ise yani NULL değil ise o zaman Authority tablosundan kullanıcının PlanningDepartmentId için 'Planning' yetkisi olup olmadığı kontrol edilir.


                bool isPlaning = shipment.PlanningDepartmentId > 0;
                var departman = isPlaning ? shipment.PlanningDepartmentId : shipment.DepartmentId;

                bool planningCheck=  _userManager.isPermesion("Shipments", "Planning", departman);
                if (!planningCheck)
                {
                     
                    return new(status: OperationResult.Error, messages: isPlaning ? "This stage will be planned by the Planning Department." : "You do not have permission to Planning this stage(s)", null);

                }

                //3. LTL ve FTL Kontrolleri
                 
                 string shipmentTypeCheck =  _plannedStageRepository.GetCheckStagePlanningByVehicleId(request.StageId,request.VehicleId);
                if (shipmentTypeCheck!="OK" && request.LTLandFTLControl==true)
                {
                    return new(status: OperationResult.Check, messages: shipmentTypeCheck, "shipmentTypeCheck");
                }


                var StagePlanlingCheckRow =
                    _plannedStageRepository.GetWhere(w => w.VehicleId == request.VehicleId && w.IsPassive == false).OrderByDescending(w => w.PlanningSequence).FirstOrDefault();

                /*
                var StagePlanlingCheckRowTime =
                    _stageRepository.GetWhere(w => w.VoyageId == stage.VoyageId && w.IsPassive == false).OrderByDescending(w => w.VoyageSequence).FirstOrDefault();
                */
                var StagePlanlingCheck = DateTime.Now;
                //var StagePlanlingCheck = StagePlanlingCheckRowTime.UnloadingTime;

                
                
                var vehicleList = _voyageRepository.GetPlanningOverview(vehicle.DepartmentId, _userManager.UserInfo().RoleId, _userManager.UserInfo().UserId);
                if (vehicleList != null)
                {
                    var findVehicle = vehicleList.Where(w => w.VehicleId == request.VehicleId).FirstOrDefault();
                    if(findVehicle != null)
                    {
                        if(findVehicle.ArrivalTime != null)
                        {
                            StagePlanlingCheck = findVehicle.ArrivalTime ??  DateTime.Now ;
                        }
                    }
                }

             

                if (StagePlanlingCheck != null) { 
                   
                    if(stage.LoadingTime.Date < StagePlanlingCheck.Date)
                    {
                        return new(status: OperationResult.Error, messages: "The loading time cannot be earlier than the arrival date of the current voyage.", null);
                    }

                    if (request.LoadingTimeArrivalTimeNextControl == true &&stage.LoadingTime.Date == StagePlanlingCheck.Date && stage.LoadingTime < StagePlanlingCheck)
                    {
                        return new(status: OperationResult.Check, messages: "The loading time is earlier than the arrival time of the current voyage, but you can proceed", "isLoadingTimeArrivalTimeNext");
                    }

                }

                // 4 kural

                var checkDep = (shipment.PlanningDepartmentId==null || shipment.PlanningDepartmentId<1) ? shipment.DepartmentId : shipment.PlanningDepartmentId; 
                
                bool departmanCheck = (checkDep == vehicle.DepartmentId);

                if (!departmanCheck)
                {
                    return new(status: OperationResult.Error, messages: "You cannot assign this vehicle to the stage(s) because the vehicle's department does not match the shipment's department or planning department.", null);
                }


                // 5. kural


                var checkPlan =  _plannedStageRepository.GetByIdAsync(w => w.VehicleId == request.VehicleId && w.StageId == request.StageId).Result;

                if(checkPlan != null)
                {
                    checkPlan.IsPassive = false;
                    checkPlan.PlanningSequence = ((StagePlanlingCheckRow?.PlanningSequence ?? 0) + 1);

                    _plannedStageRepository.Update(checkPlan);
                }
                else
                {

                    var planet = new PlannedStage();
                    planet.StageId = request.StageId;
                    planet.VehicleId = request.VehicleId;
                    planet.InsUser = User.UserId;
                    planet.PlanningSequence = ((StagePlanlingCheckRow?.PlanningSequence ?? 0) + 1);

                    await _plannedStageRepository.AddAsync(planet, cancellationToken);
                  
                }

                stage.StatusTypeId = 2;
                _stageRepository.Update(stage);
                await _unitOfWork.SaveChangesAsync(cancellationToken);


                // dynamicKMcalculation((StagePlanlingCheckRow?.PlanningSequence ?? 0), request.VehicleId,0);


                var msg = "";
                if ((StagePlanlingCheckRow?.PlanningSequence ?? 0) == 0)
                {
                    var dynamicKM = await _stageRepository.getDynamicKM(request.VehicleId);
                    if (dynamicKM != null)
                    {
                        var KontrolDynamic = _dynamicEmptyKmRepositor.GetWhere(w => w.VehicleId == request.VehicleId).FirstOrDefault();
                        if (KontrolDynamic == null)
                        {
                            var newDynemicKM = new DynamicEmptyKm();
                            newDynemicKM.CalculatedKm = dynamicKM;
                            newDynemicKM.VehicleId = request.VehicleId;
                            newDynemicKM.InsTime = DateTime.Now;
                            await _dynamicEmptyKmRepositor.AddAsync(newDynemicKM);
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


                return new(status: OperationResult.Success, messages: msg, null);
            }
            catch (Exception ex)
            {
                return new(status: OperationResult.Error, messages: ex.Message, null);
            }

        }




        public async void dynamicKMcalculation(int PlanningSequence, int VehicleId, int kosul )
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
