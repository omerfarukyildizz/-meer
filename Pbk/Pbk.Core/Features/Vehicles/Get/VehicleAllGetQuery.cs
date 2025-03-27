using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Core.Features.Users;
using Pbk.Entities.Dto;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Vehicles.Get
{


    public sealed record VehicleAllGetQuery(int? DepartmentId) : IRequest<APIResponse>
    {
        internal sealed class VehicleAllGetQueryHandler : IRequestHandler<VehicleAllGetQuery, APIResponse>
        {
            private readonly IVehicleRepository _vehicleRepository;
            private readonly ICarrierRepository _carrierRepository;
            private readonly IUserManager _userManager;
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;

            public VehicleAllGetQueryHandler(IMapper mapper, IVehicleRepository vehicleRepository, IVehicleTypeRepository vehicleTypeRepository, ICarrierRepository carrierRepository, IUserManager userManager, IUserRepository userRepository)
            {
                _mapper = mapper;
                _vehicleRepository = vehicleRepository;
                _carrierRepository = carrierRepository;
                _userManager = userManager;
                _userRepository = userRepository;
            }

            public async Task<APIResponse> Handle(VehicleAllGetQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var roleId = _userManager.UserInfo().RoleId;
                    int userId = _userManager.UserInfo().UserId;

                    var depList = _userManager.getDepartmansPagePerms("Vehicles", "Get");
                    int? selectedDepartmentId = request.DepartmentId; // Gelen departmentId, null ise "hepsi" anlamına gelir

                    var data = (from vehicle in _vehicleRepository.GetWhere(x => x.IsPassive == false)
                                join carrier in _carrierRepository.GetAll() on vehicle.CarrierId equals (int?)carrier.CarrierId into carrierGroup
                                from carrier in carrierGroup.DefaultIfEmpty()
                                where
                                    // RoleId 1 (Admin) olanlar
                                    (roleId == 1 && (!selectedDepartmentId.HasValue || vehicle.DepartmentId == selectedDepartmentId)) ||
                                    // RoleId 1 olmayanlar
                                    (roleId != 1 &&
                                        ((selectedDepartmentId.HasValue && vehicle.DepartmentId == selectedDepartmentId) ||
                                         (!selectedDepartmentId.HasValue && depList.Contains(vehicle.DepartmentId))))
                                select new
                                {
                                    VehicleId = vehicle.VehicleId,
                                    VehicleTypeId = vehicle.VehicleTypeId,
                                    VehicleTypeName = vehicle.VehicleType.VehicleTypeName,
                                    Plate = vehicle.Plate,
                                    DepartmentId = vehicle.DepartmentId,
                                    DepartmentName = vehicle.Department.DepartmentName,
                                    DepartmentCode = vehicle.Department.Code,
                                    IsPassive = vehicle.IsPassive,
                                    IsRented = vehicle.IsRented,
                                    ProjectId = vehicle.ProjectId,
                                    ProjectName = vehicle.Project.ProjectName,
                                    DocumentId = vehicle.DocumentId,
                                    InsUser = vehicle.InsUser,
                                    InsTime = vehicle.InsTime,
                                    UpdUser = vehicle.UpdUser,
                                    UpdTime = vehicle.UpdTime,
                                    CustomerId = vehicle.CustomerId,
                                    CustomerName = vehicle.Customer.CustomerName,
                                    TuvInspection = vehicle.TuvInspection,
                                    SafetyInspection = vehicle.SafetyInspection,
                                    CarrierId = vehicle.CarrierId,
                                    CarrierName = carrier != null ? carrier.CarrierName : null // Null kontrolü
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
