using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Core.Features.Users;
using Pbk.Entities.Dto;
using Pbk.Entities.Dto.Deparment;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Departments.Get
{


    public sealed record DepartmentGetAllQuery : IRequest<APIResponse>
    {
        internal sealed class DepartmentGetAllQueryHandler : IRequestHandler<DepartmentGetAllQuery, APIResponse>
        {
            private readonly IDepartmentRepository _departmentRepository;
            private readonly IMapper _mapper;
            private readonly ICountryRepository _countryRepository;
            private readonly IPlaceRepository _placeRepository;
            private readonly ICurrencyRepository _currencyRepository;
            private readonly IUserManager _userManager;

            public DepartmentGetAllQueryHandler(IDepartmentRepository departmentRepository, IMapper mapper, ICountryRepository countryRepository, IPlaceRepository placeRepository, IUserManager userManager, ICurrencyRepository currencyRepository)
            {
                _departmentRepository = departmentRepository;
                _mapper = mapper;
                _countryRepository = countryRepository;
                _placeRepository = placeRepository;
                _userManager = userManager;
                _currencyRepository = currencyRepository;
            }

            public async Task<APIResponse> Handle(DepartmentGetAllQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    if (!_userManager.isPermesion("Departments", "Get", null))
                    {
                        return new(status: StatusType.Error, messages: "Yetkiniz yok.", null);
                    }

                    var roleId = _userManager.UserInfo().RoleId;
                    int userId = _userManager.UserInfo().UserId;

                    var depList = _userManager.getDepartmansPagePerms("Departments", "Get");

                    var data = (from department in _departmentRepository.GetWhere(w => w.IsPassive == false)
                                join country in _countryRepository.GetAll() on department.CountryId equals country.CountryId into countryGroup
                                from country in countryGroup.DefaultIfEmpty()
                                join place in _placeRepository.GetAll() on department.PlaceId equals place.PlaceId into placeGroup
                                from place in placeGroup.DefaultIfEmpty()
                                join currency in _currencyRepository.GetAll() on department.CurrencyId equals currency.CurrencyId into currencyGroup
                                from currency in currencyGroup.DefaultIfEmpty()
                                where
                                // Admin kullanıcılar için
                                (roleId == 1) ||
                                // Admin olmayan kullanıcılar için
                                (roleId != 1 && depList.Contains(department.DepartmentId))
                                select new GetDepartmentsListDto
                                    {
                                        DepartmentId = department.DepartmentId,
                                        Code = department.Code,
                                        DepartmentName = department.DepartmentName,
                                        InvoiceCurrency = department.InvoiceCurrency,
                                        CommercialAccount = department.CommercialAccount,
                                        BlockedAccount = department.BlockedAccount,
                                        OverdraftAccount = department.OverdraftAccount,
                                        Director = department.Director,
                                        DirectorEmail = department.DirectorEmail,
                                        Email = department.Email,
                                        Address = department.Address,
                                        PlaceId = department.PlaceId,
                                        CountryId = department.CountryId,
                                        PostalCode = department.PostalCode,
                                        SAPCompanyCode = department.SAPCompanyCode,
                                        IsPassive = department.IsPassive,
                                        CurrencyId = department.CurrencyId,
                                        CurrencyName = currency.CurrencyCode,
                                        YdInvoiceNo = department.YdInvoiceNo,
                                        YdInvoicePrefix = department.YdInvoicePrefix,
                                        Phone = department.Phone,
                                        State = place.State,
                                        CountryName = country.CountryName,
                                        PlaceName = place.PlaceName,
                                        DocumentId = department.Document.DocumentId
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
