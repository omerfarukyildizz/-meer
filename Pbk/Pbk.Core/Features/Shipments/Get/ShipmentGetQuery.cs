using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Core.Features.Users;
using Pbk.Entities.Dto.Shipment;
using Pbk.Entities.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Pbk.Core.Features.Shipments.Get
{
    public sealed record ShipmentGetQuery(int shipmentId) : IRequest<APIResponse>
    {
        internal sealed class ShipmentGetQueryHandler : IRequestHandler<ShipmentGetQuery, APIResponse>
        {
            private readonly IShipmentRepository _shipmentRepository;
            private readonly IEndPointRepository _endPointRepository;
            private readonly IDepartmentRepository _departmentRepository;
            private readonly ISectorRepository _sectorRepository;
            private readonly IIncoTermRepository _incoTermRepository;
            private readonly IUnitRepository _unitRepository;
            private readonly IUserManager _userManager;
            private readonly IPalletCompanyRepository _palletCompanyRepository;
            private readonly IMapper _mapper;

            public ShipmentGetQueryHandler(IShipmentRepository shipmentRepository, IEndPointRepository endPointRepository, IDepartmentRepository departmentRepository, ISectorRepository sectorRepository, IIncoTermRepository incoTermRepository, IUnitRepository unitRepository, IUserManager userManager, IPalletCompanyRepository palletCompanyRepository, IMapper mapper)
            {
                _shipmentRepository = shipmentRepository;
                _endPointRepository = endPointRepository;
                _departmentRepository = departmentRepository;
                _sectorRepository = sectorRepository;
                _incoTermRepository = incoTermRepository;
                _unitRepository = unitRepository;
                _userManager = userManager;
                _palletCompanyRepository = palletCompanyRepository;
                _mapper = mapper;
            }



            //Shipment Type Dropdown
            public async Task<APIResponse> Handle(ShipmentGetQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    if (request.shipmentId== null || request.shipmentId == 0)
                    {
                        return new(status: StatusType.Error, messages: "Shipment boş geçilemez.", null);

                    }
                    var data = (from shipment in _shipmentRepository.GetWhere(w => w.IsPassive == false)
                                join senderEndpoint in _endPointRepository.GetAll() on shipment.SenderId equals senderEndpoint.PointId into senderGroup
                                from senderEndpoint in senderGroup.DefaultIfEmpty()
                                join receiverEndpoint in _endPointRepository.GetAll() on shipment.ReceiverId equals receiverEndpoint.PointId into receiverGroup
                                from receiverEndpoint in receiverGroup.DefaultIfEmpty()
                                join department in _departmentRepository.GetAll() on shipment.DepartmentId equals department.DepartmentId into departmentGroup
                                from department in departmentGroup.DefaultIfEmpty()
                                join planningDepartment in _departmentRepository.GetAll() on shipment.PlanningDepartmentId equals planningDepartment.DepartmentId into PlanningDepartmentGroup
                                from planningDepartment in PlanningDepartmentGroup.DefaultIfEmpty()
                                join sector in _sectorRepository.GetAll() on shipment.SectorId equals sector.SectorId into sectorGroup
                                from sector in sectorGroup.DefaultIfEmpty()
                                join incoTerms in _incoTermRepository.GetAll() on shipment.IncoTermId equals incoTerms.IncoTermId into incoTermsGroup
                                from incoTerms in incoTermsGroup.DefaultIfEmpty()
                                join unit in _unitRepository.GetAll() on shipment.UnitId equals unit.UnitId into unitGroup
                                from unit in unitGroup.DefaultIfEmpty()
                                join palletCompany in _palletCompanyRepository.GetAll() on shipment.PalletCompanyId equals palletCompany.PalletCompanyId into palletCompanyGroup
                                from palletCompany in palletCompanyGroup.DefaultIfEmpty()
                                where (shipment.ShipmentId == request.shipmentId)
                                select new ShipmentDto
                                {
                                    ShipmentId = shipment.ShipmentId,
                                    DepartmentId = shipment.DepartmentId,
                                    DepartmentName = department.DepartmentName,
                                    DepartmentCode = department.Code,
                                    CustomerId = shipment.CustomerId,
                                    CustomerName = shipment.Customer.CustomerName,
                                    SenderId = shipment.SenderId,
                                    SenderName = senderEndpoint.PointName,
                                    ReceiverId = shipment.ReceiverId,
                                    ReceiverName = receiverEndpoint.PointName,
                                    LoadingTime = shipment.LoadingTime,
                                    UnloadingTime = shipment.UnloadingTime,
                                    StatusTypeId = shipment.StatusType.StatusTypeId,
                                    StatusName = shipment.StatusType.StatusName,
                                    ShipmentTypeId = shipment.ShipmentTypeId,
                                    ShipmentTypeName = shipment.ShipmentType.ShipmentTypeName,
                                    Freight = shipment.Freight,
                                    CurrencyId = shipment.CurrencyId,
                                    CurrencyCode = shipment.Currency.CurrencyCode,
                                    LoadingDescription = shipment.LoadingDescription,
                                    UnloadingDescription = shipment.UnloadingDescription,
                                    FreightPaymentType = shipment.FreightPaymentType,
                                    PlanningDepartmentId = shipment.PlanningDepartmentId,
                                    PlanningDepartmentName = planningDepartment.DepartmentName,
                                    SectorId = sector.SectorId,
                                    SectorName = sector.SectorName,
                                    IncoTermId = incoTerms.IncoTermId,
                                    IncoTermCode = incoTerms.Code,
                                    AdditionalFreight = shipment.AdditionalFreight,
                                    VatRate = shipment.VATRate,
                                    Pieces = shipment.Pieces,
                                    UnitId = shipment.UnitId,
                                    UnitName = unit.UnitName,
                                    Length = shipment.Length,
                                    Height = shipment.Height,
                                    Width = shipment.Width,
                                    Weight = shipment.Weight,
                                    LDM = shipment.LDM,
                                    PalletCompanyId = shipment.PalletCompanyId,
                                    PalletCompanyName = palletCompany.PalletCompanyName,
                                    LoadingPalletExchange = shipment.LoadingPalletExchange,
                                    UnloadingPalletExchange = shipment.UnloadingPalletExchange,
                                    PalletsAtLoad = shipment.PalletsAtLoad,
                                    PalletsAtUnload = shipment.PalletsAtUnload,
                                    IntegrationFileName = shipment.IntegrationFileName,
                                    ReferenceNo=shipment.ReferenceNo
                                }).FirstOrDefault();



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
