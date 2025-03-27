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
 
    public sealed record StageByDepartmentIdGetQuery(int departmentId) : IRequest<APIResponse>
    {
        internal sealed class StageByDepartmentIdGetQueryHandler : IRequestHandler<StageByDepartmentIdGetQuery, APIResponse>
        {
            private readonly IStageRepository _stageRepository;
            private readonly IShipmentRepository _shipmentRepository;
            private readonly ILocationRepository _locationRepository;
            private readonly IVoyageRepository _voyageRepository;

            public StageByDepartmentIdGetQueryHandler(IStageRepository stageRepository, IShipmentRepository shipmentRepository,ILocationRepository locationRepository,   IVoyageRepository voyageRepository )
            {
                _stageRepository = stageRepository;
                _shipmentRepository = shipmentRepository;
                _locationRepository = locationRepository;
                _voyageRepository = voyageRepository;
            }

            public async Task<APIResponse> Handle(StageByDepartmentIdGetQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    if (request.departmentId == 0 || request.departmentId == 0)
                    {
                        return new APIResponse(status: StatusType.Error, messages: "Department ID cannot be null.", null);
                    }
                
                    var data = (from st in _stageRepository.GetAll()
                                join s in _shipmentRepository.GetAll() on st.ShipmentId equals s.ShipmentId into shipments
                                from s in shipments.DefaultIfEmpty()
                                join srcLoc in _locationRepository.GetAll() on st.SourceLocationId equals srcLoc.LocationId into sourceLocations
                                from srcLoc in sourceLocations.DefaultIfEmpty()
                                join tgtLoc in _locationRepository.GetAll() on st.TargetLocationId equals tgtLoc.LocationId into targetLocations
                                from tgtLoc in targetLocations.DefaultIfEmpty()
                                where s.DepartmentId == request.departmentId && st.IsPassive == false && s.StatusTypeId==5 && st.StatusTypeId==5
                                orderby st.VoyageSequence ascending
                                select new
                                {
                                    s.ShipmentId,
                                    st.StageId,
                                    SourceLocationId = srcLoc.LocationId,
                                    SourceLocationName = srcLoc.LocationName,
                                    TargetLocationId = tgtLoc.LocationId,
                                    TargetLocationName = tgtLoc.LocationName,
                                    VatRate=s.VATRate
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
