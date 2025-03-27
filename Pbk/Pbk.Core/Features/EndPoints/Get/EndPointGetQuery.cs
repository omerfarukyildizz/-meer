using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Core.Features.Users;
using Pbk.Core.Utilities.IResults;
using Pbk.Entities.Dto;
using Pbk.Entities.Dto.EndPoint;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.EndPoints.Get
{
   

    public sealed record EndPointGetQuery(int? DepartmentId, string? search) : IRequest<APIResponse>
    {
        internal sealed class EndPointGetQueryHandler : IRequestHandler<EndPointGetQuery, APIResponse>
        {
            private readonly IEndPointRepository _endPointRepository;
            private readonly IDepartmentRepository _departmentRepository;
            private readonly ICountryRepository _countryRepository;
            private readonly IPlaceRepository _placeRepository;
            private readonly IMapper _mapper;
            private readonly IUserRepository _userRepository;
            private readonly IUserManager _userManager;
            public EndPointGetQueryHandler(IMapper mapper, IEndPointRepository endPointRepository, ICountryRepository countryRepository, IPlaceRepository placeRepository, IDepartmentRepository departmentRepository, IUserRepository userRepository, IUserManager userManager)
            {
                _endPointRepository = endPointRepository;
                _mapper = mapper;
                _countryRepository = countryRepository;
                _placeRepository = placeRepository;
                _departmentRepository = departmentRepository;
                _userRepository = userRepository;
                _userManager = userManager;
            }

            public async Task<APIResponse> Handle(EndPointGetQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    // Kullanıcı bilgilerini al
                    var roleId = _userManager.UserInfo().RoleId;
                    int userId = _userManager.UserInfo().UserId;

                    // Kullanıcının yetkili olduğu departmanların listesi
                    var depList = _userManager.getDepartmansPagePerms("EndPoints", "Get") ?? new List<int>();

                    // LINQ sorgusu
                    var query = from point in _endPointRepository.GetWhere(w => w.IsPassive == false)
                                join country in _countryRepository.GetAll() on point.CountryId equals country.CountryId into countryGroup
                                from country in countryGroup.DefaultIfEmpty()
                                join place in _placeRepository.GetAll() on point.PlaceId equals place.PlaceId into placeGroup
                                from place in placeGroup.DefaultIfEmpty()
                                join department in _departmentRepository.GetAll() on point.DepartmentId equals department.DepartmentId into departmentGroup
                                from department in departmentGroup.DefaultIfEmpty()
                                join user in _userRepository.GetAll() on point.InsUser equals user.UserId into userGroup
                                from user in userGroup.DefaultIfEmpty()
                                where
                                    (
                                        // Eğer adminse tüm departmanları getir, değilse sadece yetkili departmanları getir
                                        (roleId == 1) ||
                                        (roleId != 1 && depList.Contains(point.DepartmentId))
                                    ) &&
                                    (
                                        // Eğer departman seçilmemişse yetkili olunan departmanları listele
                                        (!request.DepartmentId.HasValue || point.DepartmentId == request.DepartmentId.Value)
                                    ) &&
                                    (
                                        // Arama filtresi
                                        string.IsNullOrEmpty(request.search) ||
                                        point.PointName.StartsWith(request.search) ||
                                        point.Address.StartsWith(request.search) ||
                                        place.PlaceName.StartsWith(request.search)
                                    )
                                select new EndPointDto
                                {
                                    PointId = point.PointId,
                                    DepartmentId = department != null ? department.DepartmentId : (int?)null,
                                    DepartmentName = department != null ? department.DepartmentName : null,
                                    PointName = point.PointName,
                                    Address = point.Address,
                                    State = place != null ? place.State : null,
                                    PlaceId = place != null ? place.PlaceId : (int?)null,
                                    PlaceName = place != null ? place.PlaceName : null,
                                    CountryId = country != null ? country.CountryId : (int?)null,
                                    CountryName = country != null ? country.CountryName : null,
                                    Phone = point.Phone,
                                    PostalCode = point.PostalCode,
                                    RelatedPerson = point.RelatedPerson,
                                    Email = point.Email,
                                    Reference = point.Reference,
                                    BarsisAdrBankCode = point.BarsisAdrBankCode,
                                    Latitude = point.Latitude,
                                    Longitude = point.Longitude,
                                    IsPassive = point.IsPassive,
                                    InsUser = point.InsUser,
                                    UserName = user != null ? user.UserName : null
                                };

                    // Sorguyu çalıştır
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
