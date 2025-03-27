using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Entities.Dto;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Stages.Get
{
 
    public sealed record StageByVoyageIdGetQuery(int voyageId) : IRequest<APIResponse>
    {
        internal sealed class StageByVoyageIdGetQueryHandler : IRequestHandler<StageByVoyageIdGetQuery, APIResponse>
        {
            private readonly IStageRepository _stageRepository;
            private readonly IShipmentRepository _shipmentRepository;
            private readonly IDepartmentRepository _departmentRepository;
            private readonly ILocationRepository _locationRepository;
            private readonly IStatusTypeRepository _statusTypeRepository;
            private readonly IVoyageRepository _voyageRepository;

            public StageByVoyageIdGetQueryHandler(IStageRepository stageRepository, IShipmentRepository shipmentRepository, IDepartmentRepository departmentRepository, ILocationRepository locationRepository, IStatusTypeRepository statusTypeRepository, IVoyageRepository voyageRepository )
            {
                _stageRepository = stageRepository;
                _shipmentRepository = shipmentRepository;
                _departmentRepository = departmentRepository;
                _locationRepository = locationRepository;
                _statusTypeRepository = statusTypeRepository;
                _voyageRepository = voyageRepository;
            }

            public async Task<APIResponse> Handle(StageByVoyageIdGetQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    if (request.voyageId == 0 || request.voyageId == 0)
                    {
                        return new APIResponse(status: StatusType.Error, messages: "Voyage ID cannot be null.", null);
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
                                where st.VoyageId == request.voyageId && st.IsPassive == false
                                orderby st.VoyageSequence ascending
                                select new
                                {
                                    st.StageId,
                                    st.ShipmentId,
                                    DepartmentId = dep.DepartmentId,
                                    StageDepartment = dep.DepartmentName,
                                    StageNumber = st.StageNumber,
                                    LoadingTime = st.LoadingTime,
                                    UnloadingTime = st.UnloadingTime,
                                    SourceLocationId = srcLoc.LocationId,
                                    SourceLocationName = srcLoc.LocationName,
                                    TargetLocationId = tgtLoc.LocationId,
                                    TargetLocationName = tgtLoc.LocationName,
                                    StatusType = stat.StatusName,
                                    StageKM = st.StageKM,
                                    VoyageSequence = st.VoyageSequence,
                                    UnloadingDescription=s.UnloadingDescription,
                                    LoadingDescription=s.LoadingDescription
                                }).ToList();

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
