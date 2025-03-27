using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Entities.Dto;
using Pbk.Entities.Dto.Country;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.PlannedStages.Get
{

    public sealed record PlannedStageGetQuery(int vehicleId) : IRequest<APIResponse>
    {
        internal sealed class PlannedStageGetQueryHandler : IRequestHandler<PlannedStageGetQuery, APIResponse>
        {
            private readonly IPlannedStageRepository _plannedStageRepository;
            private readonly IStageRepository _stageRepository;
            private readonly IShipmentRepository _shipmentRepository;
            private readonly IDepartmentRepository _departmentRepository;
            private readonly ILocationRepository _locationRepository;
            private readonly IVehicleRepository _vehicleRepository;
            private readonly IDriverRepository _driverRepository;
            private readonly IMapper _mapper;

            public PlannedStageGetQueryHandler(IPlannedStageRepository plannedStageRepository, IStageRepository stageRepository, IShipmentRepository shipmentRepository, IDepartmentRepository departmentRepository, ILocationRepository locationRepository, IMapper mapper, IDriverRepository driverRepository, IVehicleRepository vehicleRepository)
            {
                _plannedStageRepository = plannedStageRepository;
                _stageRepository = stageRepository;
                _shipmentRepository = shipmentRepository;
                _departmentRepository = departmentRepository;
                _locationRepository = locationRepository;
                _mapper = mapper;
                _driverRepository = driverRepository;
                _vehicleRepository = vehicleRepository;
            }

            public async Task<APIResponse> Handle(PlannedStageGetQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var data = (from ps in _plannedStageRepository.GetWhere(w=>w.IsPassive == false)
                                join st in _stageRepository.GetWhere(w=>w.IsPassive==false) on ps.StageId equals st.StageId  
                                join s in _shipmentRepository.GetWhere(w=>w.IsPassive == false) on st.ShipmentId equals s.ShipmentId  
                                join dep in _departmentRepository.GetAll() on s.DepartmentId equals dep.DepartmentId 
                                join l1 in _locationRepository.GetAll() on st.SourceLocationId equals l1.LocationId  
                                join l2 in _locationRepository.GetAll() on st.TargetLocationId equals l2.LocationId
                                join vc in _vehicleRepository.GetAll() on ps.VehicleId equals vc.VehicleId into vehicles
                                from vc in vehicles.DefaultIfEmpty()
                                join dr in _driverRepository.GetAll() on ps.VehicleId equals dr.VehicleId into drivers
                                from dr in drivers.DefaultIfEmpty()
                                where ps.IsPassive == false && ps.VehicleId == request.vehicleId
                                select new
                                {
                                    st.StageId,
                                    StageDepartment = dep.Code,
                                    SourceLocationName = l1.LocationName,
                                    TargetLocationName = l2.LocationName,
                                    st.LoadingTime,
                                    st.UnloadingTime,
                                    st.StageKM,
                                    st.StageNumber,
                                    ps.PlannedStageId,
                                    ps.VehicleId,
                                    s.ShipmentId,
                                    ps.PlanningSequence,
                                    DriverId = dr.DriverId == null ? 0 : dr.DriverId,
                                    DriverName = dr.DriverName == null ? "" : dr.DriverName,
                                    VoyageDepartmentId = (s.PlanningDepartmentId != null && s.PlanningDepartmentId >0 ) ? s.PlanningDepartmentId : s.DepartmentId,
                                }).OrderBy(w=>w.PlanningSequence).ToList();



                    return new(status: StatusType.Success, messages: "", data);
                }
                catch (Exception ex)
                {
                    return new(status: StatusType.Error, messages: ex?.InnerException?.Message ?? ex?.Message, null);
                }
            }
        }

    }
}
