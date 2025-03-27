using AutoMapper;
using Pbk.Core.Features.User;
using Pbk.Core.Features.Response;
using Pbk.Core.Utilities.IResults;
using Pbk.Entities.Repositories;
using Pbk.Core.Features.Users;
using Pbk.Core.Features.Users;
using MediatR;
using Pbk.Entities.Models;
using Pbk.Entities.Models2;
namespace Pbk.Core.Features.Voyages.Create
{
    internal sealed class VoyageCreateCommandHandler : IRequestHandler<VoyageCreateCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly IVoyageRepository _voyageRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;
        private readonly IPlannedStageRepository _plannedStageRepository;
        private readonly IStageRepository _stageRepository;
        private readonly IDynamicEmptyKmRepositor _dynamicEmptyKmRepositor;

        public VoyageCreateCommandHandler(IUserManager userManager, ITranslate tanslate, IMapper mapper, IVoyageRepository voyageRepository, IUnitOfWork unitOfWork, IPlannedStageRepository plannedStageRepository, IStageRepository stageRepository, IDynamicEmptyKmRepositor dynamicEmptyKmRepositor, IVehicleRepository vehicleRepository)
        {
            _tanslate = tanslate;
            _voyageRepository = voyageRepository;
            _mapper = mapper;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _plannedStageRepository = plannedStageRepository;
            _stageRepository = stageRepository;
            _dynamicEmptyKmRepositor = dynamicEmptyKmRepositor;
            _vehicleRepository = vehicleRepository;
        }

        public async Task<APIResponse> Handle(VoyageCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var UserId = _userManager.UserInfo().UserId;

                var TruckId = request.TruckId;

                if (!string.IsNullOrEmpty(request.plate) && !string.IsNullOrWhiteSpace(request.plate) && request.CarrierId > 0)
                {
                    var plateCheck = _vehicleRepository.GetWhere(w =>
                    w.Plate == request.plate &&
                    w.IsPassive == false &&
                    w.CarrierId == request.CarrierId).Select(w=>w.VehicleId).FirstOrDefault();
                    if (plateCheck ==null || plateCheck == 0)
                    {
                        var vehicleAdd = new Entities.Models.Vehicle();
                        vehicleAdd.CarrierId = request.CarrierId;
                        vehicleAdd.VehicleTypeId = 1;
                        vehicleAdd.Plate = request.plate;
                        vehicleAdd.DepartmentId = request.DepartmentId;
                        vehicleAdd.InsTime = DateTime.Now;
                        vehicleAdd.InsUser = _userManager.UserInfo().UserId;
                        vehicleAdd.IsPassive = false;
                        _vehicleRepository.AddAsync(vehicleAdd);
                        await _unitOfWork.SaveChangesAsync(cancellationToken);
                        TruckId = vehicleAdd.VehicleId;
                    }
                    else
                    {
                        TruckId = plateCheck;
                    }
                }


                Entities.Models.Voyage data = _mapper.Map<Entities.Models.Voyage>(request);
                data.InsUser = UserId;
                data.InsTime = DateTime.Now;
                data.TruckId = TruckId;
                data.CarrierId = request.CarrierId;
                data.CurrencyId = request.CurrencyId;
                data.IsPassive = false;
                await _voyageRepository.AddAsync(data, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                if (request.plannedStages !=null && request.plannedStages.Count > 0)
                {


                    List<stagesDto> stages = new List<stagesDto>();
                    if (!request.CarrierId.HasValue) { 
                    var listPlanneds = _plannedStageRepository.GetWhere(w=> request.plannedStages.Contains(w.PlannedStageId)).ToList();
                    if (listPlanneds.Count > 0)
                    {
                        foreach (var item in listPlanneds)
                        {
                            stages.Add(new stagesDto {stagesId = item.StageId,  VoyageSequence = item.PlanningSequence ?? 0});
                            item.IsPassive = true;
                            _plannedStageRepository.Update(item);
                        }
                    }
                    }
                    else
                    {
                        var VoyageSequenceOrder = 1;
                        foreach (var item in request.plannedStages)
                        {
                            stages.Add(new stagesDto { stagesId = item, VoyageSequence = VoyageSequenceOrder });
                            VoyageSequenceOrder++;
                        }

                    }

                    if (stages.Count > 0)
                    {

                        var stagesId = stages.Select(s => s.stagesId).ToList();
                        var listStages = _stageRepository.GetWhere(w => stagesId.Contains(w.StageId) && (w.VoyageId ==null || w.VoyageId ==0)  ).ToList();
                        if (listStages.Count > 0)
                        {
                            foreach (var item in listStages)
                            {
                                item.VoyageId = data.VoyageId;
                                item.StatusTypeId = 3;
                                item.VoyageSequence = stages.Find(w=>w.stagesId == item.StageId).VoyageSequence;
                                _stageRepository.Update(item);
                            }
                        }
                    }
                }



                if (!request.CarrierId.HasValue) {
                    var dynamicEmptyKM = _dynamicEmptyKmRepositor.GetWhere(w => w.VehicleId == TruckId).FirstOrDefault();
                    if (dynamicEmptyKM != null)
                    {
                        data.EmptyKm = dynamicEmptyKM.CalculatedKm;
                        _dynamicEmptyKmRepositor.Remove(dynamicEmptyKM);
                        await _unitOfWork.SaveChangesAsync(cancellationToken);
                    }
                }


                var  kalanPlaned = _plannedStageRepository.GetWhere(w => w.VehicleId == TruckId && !w.IsPassive).OrderBy(w=>w.PlanningSequence).ToList();
                var dataVehicleId = 0;
                if (kalanPlaned.Count > 0)
                {
                    var i = 1;
                    foreach (var item in kalanPlaned)
                    {
                        dataVehicleId= item.VehicleId ?? 0;
                        item.PlanningSequence = i;
                        _plannedStageRepository.Update(item);
                        i++;
                    }
                }

                var msg = "";
                if (!(request.CarrierId.HasValue || request.CarrierId == 0))
                {
               
                    try
                    {
                        var dynamicKM = await _stageRepository.getDynamicKM(dataVehicleId);
                        if (dynamicKM != null)
                        {
                            var KontrolDynamic = _dynamicEmptyKmRepositor.GetWhere(w => w.VehicleId == dataVehicleId).FirstOrDefault();
                            if (KontrolDynamic == null)
                            {
                                if (dataVehicleId > 0 && dataVehicleId != null)
                                {
                                    var newDynemicKM = new DynamicEmptyKm();
                                    newDynemicKM.CalculatedKm = dynamicKM;
                                    newDynemicKM.VehicleId = dataVehicleId;
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
                        }


                    }
                    catch (Exception ex) { }
                }


                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new(status: OperationResult.Success, messages:msg, data);
            }
            catch (Exception ex)
            {
                return new(status: OperationResult.Error, messages: ex.Message, null);
            }

        }

    }



}

public class stagesDto
{
    public int stagesId { get; set; }
    public int VoyageSequence { get; set; }
}
