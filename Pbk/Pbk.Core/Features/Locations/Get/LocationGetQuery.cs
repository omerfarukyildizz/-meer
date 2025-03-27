using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Core.Features.Users;
using Pbk.Core.Utilities.IResults;
using Pbk.Entities.Dto;
using Pbk.Entities.Dto.Location;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Pbk.Core.Features.Locations.Get
{
    public sealed record LocationGetQuery(string? search, int? DepartmentId) : IRequest<APIResponse>
    {
        internal sealed class LocationGetQueryHandler : IRequestHandler<LocationGetQuery, APIResponse>
        {
            private readonly ILocationRepository _locationRepository;
            private readonly IMapper _mapper;
            private readonly IAuthorityRepository _authorityRepository;
            private readonly IUserManager _userManager;
            private readonly IDepartmentRepository _departmentRepository;
            private readonly ICountryRepository _countryRepository;
            private readonly IUserRepository _userRepository;
            private readonly IPlaceRepository _placeRepository;


            public LocationGetQueryHandler(ILocationRepository locationRepository, IMapper mapper, IAuthorityRepository authorityRepository, IUserManager userManager, IDepartmentRepository departmentRepository, ICountryRepository countryRepository, IPlaceRepository placeRepositorys, IUserRepository userRepository, IPlaceRepository placeRepository)
            {
                _locationRepository = locationRepository;
                _mapper = mapper;
                _authorityRepository = authorityRepository;
                _userManager = userManager;
                _departmentRepository = departmentRepository;
                _countryRepository = countryRepository;
                _userRepository = userRepository;
                _placeRepository = placeRepository;
            }

            public async Task<APIResponse> Handle(LocationGetQuery request, CancellationToken cancellationToken)
            {
                try
                {

                    var roleId = _userManager.UserInfo().RoleId;
                    int userId = _userManager.UserInfo().UserId;

                    //var depList = roleId != 1 ? _userManager.getDepartmansPagePerms("Locations", "get") : null;
                    var depList = _userManager.getDepartmansPagePerms("Locations", "get");

                    // LINQ Sorgusu
                    var query = from location in _locationRepository.GetWhere(w => w.IsPassive == false)
                                join country in _countryRepository.GetAll() on location.CountryId equals country.CountryId into countryGroup
                                from country in countryGroup.DefaultIfEmpty()
                                join place in _placeRepository.GetAll () on location.PlaceId equals place.PlaceId into placeGroup
                                from place in placeGroup.DefaultIfEmpty()
                                join department in _departmentRepository.GetAll() on location.DepartmentId equals department.DepartmentId into departmentGroup
                                from department in departmentGroup.DefaultIfEmpty()
                                join user in _userRepository.GetAll() on location.InsUser equals user.UserId into userGroup
                                from user in userGroup.DefaultIfEmpty()
                                where
                                    (
                                        // Eğer adminse tüm departmanları getir, değilse sadece yetkili departmanları getir
                                        (roleId == 1) ||
                                        (roleId != 1 && depList.Contains(location.DepartmentId))
                                    ) &&
                                    (
                                        // Eğer departman seçilmemişse yetkili olunan departmanları listele
                                        (!request.DepartmentId.HasValue || location.DepartmentId == request.DepartmentId.Value)
                                    ) &&
                                    (
                                        // Arama filtresi
                                        string.IsNullOrEmpty(request.search) ||
                                        location.LocationName.StartsWith(request.search) ||
                                        location.Address.StartsWith(request.search) ||
                                        place.PlaceName.StartsWith(request.search)
                                    )
                                select new GetAllLocationDto
                                {
                                    LocationId = location.LocationId,
                                    DepartmentId = department != null ? department.DepartmentId : (int?)null,
                                    DepartmentName = department != null ? department.DepartmentName : null,
                                    LocationName = location.LocationName,
                                    Address = location.Address,
                                    State = place != null ? place.State : null,
                                    PlaceId = place != null ? place.PlaceId : (int?)null,
                                    PlaceName = place != null ? place.PlaceName : null,
                                    CountryId = country != null ? country.CountryId : (int?)null,
                                    CountryName = country != null ? country.CountryName : null,
                                    Phone = location.Phone,
                                    PostalCode = location.PostalCode,
                                    Latitude = location.Latitude,
                                    Longitude = location.Longitude,
                                    InsUser = location.InsUser,
                                    UserName = user != null ? user.UserName : null
                                };
                    var data = query.ToList();

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
