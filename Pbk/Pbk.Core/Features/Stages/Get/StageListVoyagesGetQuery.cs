using Pbk.Core.Features.Response;
using Pbk.Entities.Models;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatusType = Pbk.Core.Features.Response.StatusType;

namespace Pbk.Core.Features.Stages.Get
{
    public sealed record StageListVoyagesGetQuery(int departmentId, int voyageId) : IRequest<APIResponse>
    {
        internal sealed class StageListVoyagesGetQueryHandler : IRequestHandler<StageListVoyagesGetQuery, APIResponse>
        {
            private readonly IStageRepository _stageRepository;
            private readonly IShipmentRepository _shipmentRepository;
            private readonly ILocationRepository _locationRepository;
            private readonly IVoyageRepository _voyageRepository;
            private readonly IPlannedStageRepository _plannedStageRepository;

            public StageListVoyagesGetQueryHandler(IStageRepository stageRepository, IShipmentRepository shipmentRepository, ILocationRepository locationRepository, IVoyageRepository voyageRepository, IPlannedStageRepository plannedStageRepository)
            {
                _stageRepository = stageRepository;
                _shipmentRepository = shipmentRepository;
                _locationRepository = locationRepository;
                _voyageRepository = voyageRepository;
                _plannedStageRepository = plannedStageRepository;
            }

            public async Task<APIResponse> Handle(StageListVoyagesGetQuery request, CancellationToken cancellationToken)
            {
                try
                {
                   var voyage = _voyageRepository.GetWhere(w => w.VoyageId == request.voyageId && !w.IsPassive ).FirstOrDefault();
                    if(voyage  == null)
                    {
                        return new APIResponse(status: StatusType.Error, messages: "Voyage not found.", null);
                    }


                    if (request.departmentId == 0 || request.departmentId == 0)
                    {
                        return new APIResponse(status: StatusType.Error, messages: "Department ID cannot be null.", null);
                    }

                    var data = (from st in _stageRepository.GetAll()
                                join s in _shipmentRepository.GetAll() on st.ShipmentId equals s.ShipmentId
                                join srcLoc in _locationRepository.GetAll() on st.SourceLocationId equals srcLoc.LocationId into sourceLocations
                                from srcLoc in sourceLocations.DefaultIfEmpty()
                                join tgtLoc in _locationRepository.GetAll() on st.TargetLocationId equals tgtLoc.LocationId into targetLocations
                                from tgtLoc in targetLocations.DefaultIfEmpty()
                                where
                                    (s.PlanningDepartmentId == request.departmentId || s.DepartmentId == request.departmentId)
                                    && st.IsPassive == false
                                    && (st.StatusTypeId == 1 ||
                                       (st.StatusTypeId == 2 && _plannedStageRepository.GetAll()
                                            .Any(ps => ps.StageId == st.StageId && !ps.IsPassive && ps.VehicleId == voyage.TruckId)))
                                orderby st.VoyageSequence ascending
                                select new
                                {
                                    s.ShipmentId,
                                    st.StageId,
                                    SourceLocationId = srcLoc.LocationId,
                                    SourceLocationName = srcLoc.LocationName,
                                    TargetLocationId = tgtLoc.LocationId,
                                    TargetLocationName = tgtLoc.LocationName,
                                    st.StatusTypeId,
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
