using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Core.Features.Users;
using Pbk.Entities.Dto;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Pbk.Core.Features.Drivers.Get
{


    public sealed record DriverGetQuery(string? search, int? DepartmentId) : IRequest<APIResponse>
    {
        internal sealed class DriverGetQueryHandler : IRequestHandler<DriverGetQuery, APIResponse>
        {
            private readonly IDriverRepository _driverRepository;
            private readonly IVehicleRepository _vehicleRepository;
            private readonly IDepartmentRepository _departmentRepository;
            private readonly IUserManager _userManager;
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;

            public DriverGetQueryHandler(IDriverRepository driverRepository, IMapper mapper, IVehicleRepository vehicleRepository, IDepartmentRepository departmentRepository, IUserManager userManager, IUserRepository userRepository)
            {
                _driverRepository = driverRepository;
                _mapper = mapper;
                _vehicleRepository = vehicleRepository;
                _departmentRepository = departmentRepository;
                _userManager = userManager;
                _userRepository = userRepository;
            }

            public async Task<APIResponse> Handle(DriverGetQuery request, CancellationToken cancellationToken)
            {
                try
                {

                    var roleId = _userManager.UserInfo().RoleId;
                    int userId = _userManager.UserInfo().UserId;

                    var depList = _userManager.getDepartmansPagePerms("Drivers", "get");
                    int? selectedDepartmentId = null; // NULL: "ALL" anlamına gelir

                    // Kullanıcı bilgilerini al
                    var users = _userRepository.GetAll().ToDictionary(u => u.UserId, u => u.UserName); 

                    // LINQ Sorgusu
                    var data = (from driver in _driverRepository.GetWhere(w => w.IsPassive == false)
                                join vehicle in _vehicleRepository.GetAll()
                                on driver.VehicleId equals vehicle.VehicleId into vehicleGroup
                                from vehicle in vehicleGroup.DefaultIfEmpty()
                                join department in _departmentRepository.GetAll()
                                on driver.DepartmentId equals department.DepartmentId into departmentGroup
                                from department in departmentGroup.DefaultIfEmpty()
                                where
                                      // Eğer departman seçilmemişse yetkili olunan departmanları listele
                                    (!request.DepartmentId.HasValue && depList.Contains(driver.DepartmentId)) ||
                                    // Eğer departman seçilmişse yalnızca o departmanın verilerini listele
                                    (request.DepartmentId.HasValue && driver.DepartmentId == request.DepartmentId.Value) &&
                                    (string.IsNullOrEmpty(request.search) ||
                                     driver.DriverName.StartsWith(request.search))
                                select new GetDriversAndVehicleDto
                                {
                                    DriverId = driver.DriverId,
                                    VehicleId = driver.VehicleId,
                                    Plate = vehicle.Plate,
                                    DepartmentId = department.DepartmentId,
                                    DriverName = driver.DriverName,
                                    DepartmentName = department.DepartmentName,
                                    EdiCode = driver.EdiCode,
                                    IntegratedAccountCode = driver.IntegratedAccountCode,
                                    IsPassive = driver.IsPassive,
                                    InsUser = driver.InsUser,
                                    InsTime = driver.InsTime,
                                    UpdUser = driver.UpdUser,
                                    UpdTime = driver.UpdTime,
                                    VehicleTypeId = vehicle.VehicleType.VehicleTypeId,
                                    VehicleTypeName = vehicle.VehicleType.VehicleTypeName
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
