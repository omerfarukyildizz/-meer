using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Core.Utilities.Uniq;
using Pbk.Entities.Dto.Voyage;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Voyages.Get
{
 
    public sealed record VoyageByDepartmentIdGetQuery(int departmentId , bool? isAddToExistingVoyage, string? search) : IRequest<APIResponse>
    {
        internal sealed class VoyageByDepartmentIdGetQueryHandler : IRequestHandler<VoyageByDepartmentIdGetQuery, APIResponse>
        {
            private readonly IVoyageRepository _voyageRepository;
            private readonly IVehicleRepository _vehicleRepository;
            private readonly IShipmentRepository _shipmentRepository;
            private readonly IStageRepository _stageRepository;
            private readonly IMapper _mapper;

            public VoyageByDepartmentIdGetQueryHandler(IVoyageRepository voyageRepository, IVehicleRepository vehicleRepository, IMapper mapper, IShipmentRepository shipmentRepository, IStageRepository stageRepository)
            {
                _voyageRepository = voyageRepository;
                _vehicleRepository = vehicleRepository;
                _mapper = mapper;
                _shipmentRepository = shipmentRepository;
                _stageRepository = stageRepository;
            }

            public async Task<APIResponse> Handle(VoyageByDepartmentIdGetQuery request, CancellationToken cancellationToken)
            {
                try
                {// (Regex_Helper.IsNumber(request.search) ? v.VoyageId = Convert.ToInt32(request.search) : veh.Plate.Contains(request.search)) : 1==1)
                    bool isNumber=false;
                    var isSearch = !string.IsNullOrEmpty(request.search) && !string.IsNullOrWhiteSpace(request.search);
                    if (isSearch)
                    {
                         isNumber = Regex_Helper.IsNumber(request.search);

                    }

                    var data = (from v in _voyageRepository.GetWhere(w => w.IsPassive == false && w.DepartmentId == request.departmentId)
                                join veh in _vehicleRepository.GetWhere(w => w.IsPassive == false) on v.TruckId equals veh.VehicleId into vehGroup
                                from veh in vehGroup.DefaultIfEmpty()
                                join s in _stageRepository.GetWhere(w => w.IsPassive == false) on v.VoyageId equals s.VoyageId into sGroup
                                from s in sGroup.DefaultIfEmpty()
                                join sh in _shipmentRepository.GetWhere(w => w.IsPassive == false) on s.ShipmentId equals sh.ShipmentId into shGroup
                                from sh in shGroup.DefaultIfEmpty()
                                where (
                                  request.isAddToExistingVoyage==true ? v.StatusTypeId != 5 : v.StatusTypeId == 5) 
                                 && 
                                  (isSearch  ?  ((isNumber ? v.VoyageId == Convert.ToInt32(request.search) : veh.Plate.Contains(request.search)))  : 1==1 )
                                select new VoyageVATRateDto
                                {
                                    VoyageId = v.VoyageId,
                                    Plate = veh.Plate, 
                                    VATRate = sh.VATRate
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
