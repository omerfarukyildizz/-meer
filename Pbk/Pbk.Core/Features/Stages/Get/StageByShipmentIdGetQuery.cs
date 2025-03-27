using Pbk.Core.Features.Response;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Linq;

namespace Pbk.Core.Features.Stages.Get
{

    public sealed record StageByShipmentIdGetQuery(int shipmentId) : IRequest<APIResponse>
    {
        internal sealed class StageByShipmentIdGetQueryHandler : IRequestHandler<StageByShipmentIdGetQuery, APIResponse>
        {
            private readonly IStageRepository _stageRepository;
            private readonly IShipmentRepository _shipmentRepository;
            private readonly IDepartmentRepository _departmentRepository;
            private readonly ILocationRepository _locationRepository;
            private readonly IStatusTypeRepository _statusTypeRepository;
            private readonly IPlannedStageRepository _plannedStageRepository;
            private readonly IUnitOfWork _unitOfWork;

            private readonly IVoyageRepository _voyageRepository;
            private readonly IVehicleRepository _vehicleRepository;
            private readonly IDriverRepository _driverRepository;

            public StageByShipmentIdGetQueryHandler(IStageRepository stageRepository, IShipmentRepository shipmentRepository, IDepartmentRepository departmentRepository, ILocationRepository locationRepository, IStatusTypeRepository statusTypeRepository, IVoyageRepository voyageRepository, IPlannedStageRepository plannedStageRepository, IVehicleRepository vehicleRepository, IDriverRepository driverRepository, IUnitOfWork unitOfWork)
            {
                _stageRepository = stageRepository;
                _shipmentRepository = shipmentRepository;
                _departmentRepository = departmentRepository;
                _locationRepository = locationRepository;
                _statusTypeRepository = statusTypeRepository;
                _voyageRepository = voyageRepository;
                _plannedStageRepository = plannedStageRepository;
                _vehicleRepository = vehicleRepository;
                _driverRepository = driverRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<APIResponse> Handle(StageByShipmentIdGetQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    if (request.shipmentId == 0 || request.shipmentId == 0)
                    {
                        return new APIResponse(status: StatusType.Error, messages: "Shipment ID cannot be null.", null);
                    }

                    var data = (from st in _stageRepository.GetAll()
                                join s in _shipmentRepository.GetAll() on st.ShipmentId equals s.ShipmentId into shipments
                                from s in shipments.DefaultIfEmpty()
                                join dep in _departmentRepository.GetAll() on s.DepartmentId equals dep.DepartmentId into departments
                                from dep in departments.DefaultIfEmpty()
                                join srcLoc in _locationRepository.GetAll() on st.SourceLocationId equals srcLoc.LocationId into sourceLocations
                                from srcLoc in sourceLocations.DefaultIfEmpty()
                                join tgtLoc in _locationRepository.GetAll() on st.TargetLocationId equals tgtLoc.LocationId into targetLocations
                                from tgtLoc in targetLocations.DefaultIfEmpty()
                                join stat in _statusTypeRepository.GetAll() on st.StatusTypeId equals stat.StatusTypeId into statusTypes
                                from stat in statusTypes.DefaultIfEmpty()


                                join ps in _plannedStageRepository.GetWhere(w => !w.IsPassive) on st.StageId equals ps.StageId into plannedStages
                                from ps in plannedStages.DefaultIfEmpty()

                                join vc in _vehicleRepository.GetAll() on ps.VehicleId equals vc.VehicleId into vehicles
                                from vc in vehicles.DefaultIfEmpty()

                                where st.ShipmentId == request.shipmentId && st.IsPassive==false
                                orderby st.VoyageSequence ascending
                                select new StageData
                                {
                                    StageId = st.StageId,
                                    ShipmentId =   st.ShipmentId,
                                    StageDepartment = dep.DepartmentName,
                                    StageNumber = st.StageNumber,
                                    LoadingTime = st.LoadingTime,
                                    UnloadingTime = st.UnloadingTime,
                                    sourceLocationId = st.SourceLocationId,
                                    TargetLocationId = st.TargetLocationId,
                                    SourceLocationName = srcLoc.LocationName,
                                    LocationId = tgtLoc.LocationId,
                                    TargetLocationName = tgtLoc.LocationName,
                                    StatusType = stat.StatusName,
                                    StageKM =  st.StageKM,
                                    VoyageSequence = st.VoyageSequence,
                                    VehicleId = vc != null ? vc.VehicleId : (int?)null,
                                    Plate = vc.Plate,
                                    DepartmentId= dep.DepartmentId,


                                }).ToList();


                    var getKmZero = data.Where(w => w.StageKM == null || w.StageKM == 0).Select(w => w.StageId).ToList();

                    if (getKmZero.Any())
                    {
                        var upList = _stageRepository.GetWhere(w => getKmZero.Contains(w.StageId)).ToList();
                        if (upList.Any())
                        {
                            var tasks = upList.Select(async item =>
                            {
                                var km = await _stageRepository.getKm(item.StageId);
                                item.StageKM = km < 1 ? 1 : km;
                                _stageRepository.Update(item);
                                var stageData = data.Find(w => w.StageId == item.StageId);
                                if (stageData != null)
                                {
                                    stageData.StageKM =  km;
                                }
                            });

                            await Task.WhenAll(tasks);
                            await _unitOfWork.SaveChangesAsync(cancellationToken);
                        }
                    }

                    return new(status: StatusType.Success, messages: string.Empty, data);
                }
                catch (Exception ex)
                {
                    return new(status: StatusType.Error, messages: ex?.InnerException?.Message ?? ex?.Message, null);
                }
            }
        }

    }
}
public class StageData
{
    public int? StageId { get; set; }
    public int? ShipmentId { get; set; }
    public int? DepartmentId { get; set; }
    public string? StageDepartment { get; set; }
    public int? StageNumber { get; set; }
    public int? sourceLocationId { get; set; }
    public int? TargetLocationId { get; set; }

    public int? LocationId { get; set; }

    public DateTime? LoadingTime { get; set; }
    public DateTime? UnloadingTime { get; set; }
    public string? SourceLocationName { get; set; }
    public string? TargetLocationName { get; set; }
    public string? StatusType { get; set; }
    public decimal? StageKM { get; set; }
    public int? VoyageSequence { get; set; }
    public int? VehicleId { get; set; }
    public string? Plate { get; set; }
}