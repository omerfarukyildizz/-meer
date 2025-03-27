using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Core.Features.Users;
using Pbk.Entities.Dto;
using Pbk.Entities.Dto.Customer;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Customers.Get
{


    public sealed record CustomerGetQuery(int? DepartmentId) : IRequest<APIResponse>
    {
        internal sealed class CustomerGetQueryHandler : IRequestHandler<CustomerGetQuery, APIResponse>
        {
            private readonly ICustomerRepository _customerRepository;
            private readonly ICountryRepository _countryRepository;
            private readonly ISectorRepository _sectorRepository;
            private readonly IDepartmentRepository _departmentRepository;
            private readonly IPlaceRepository _placeRepository;
            private readonly IPaymentTypeRepository _paymentTypeRepository;
            private readonly IUserManager _userManager;
            private readonly IMapper _mapper;

            public CustomerGetQueryHandler(ICustomerRepository customerRepository, IMapper mapper, ICountryRepository countryRepository, ISectorRepository sectorRepository, IPaymentTypeRepository paymentTypeRepository, IUserManager userManager, IDepartmentRepository departmentRepository, IPlaceRepository placeRepository)
            {
                _customerRepository = customerRepository;
                _mapper = mapper;
                _countryRepository = countryRepository;
                _sectorRepository = sectorRepository;
                _paymentTypeRepository = paymentTypeRepository;
                _userManager = userManager;
                _departmentRepository = departmentRepository;
                _placeRepository = placeRepository;
            }

            public async Task<APIResponse> Handle(CustomerGetQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var roleId = _userManager.UserInfo().RoleId;
                    int userId = _userManager.UserInfo().UserId;

                    var depList = _userManager.getDepartmansPagePerms("Customers", "Get");
                    int? selectedDepartmentId = request.DepartmentId;  


                    var data = (from customer in _customerRepository.GetWhere(x=>x.IsPassive==false)
                                join country in _countryRepository.GetAll() on customer.CountryId equals country.CountryId into countryGroup
                                from country in countryGroup.DefaultIfEmpty()
                                join sector in _sectorRepository.GetAll() on customer.SectorId equals sector.SectorId into sectorGroup
                                from sector in sectorGroup.DefaultIfEmpty()
                                join paymentType in _paymentTypeRepository.GetAll() on customer.PaymentTypeId equals paymentType.PaymentTypeId into paymentTypeGroup
                                from paymentType in paymentTypeGroup.DefaultIfEmpty()
                                join place in _placeRepository.GetAll() on customer.PlaceId equals place.PlaceId into placeGroup
                                from place in placeGroup.DefaultIfEmpty()
                                join department in _departmentRepository.GetAll() on customer.DepartmentId equals department.DepartmentId
                                where 
                                    // Admin kullanıcılar için
                                    (roleId == 1 && (!selectedDepartmentId.HasValue || customer.DepartmentId == selectedDepartmentId)) ||
                                    // Admin olmayan kullanıcılar için
                                    (roleId != 1 && (
                                        (selectedDepartmentId.HasValue && customer.DepartmentId == selectedDepartmentId) ||
                                        (!selectedDepartmentId.HasValue && depList.Contains(customer.DepartmentId))
                                    ))
                                select new 
                         {
                             CustomerId = customer.CustomerId,
                             DepartmentId = customer.Department.DepartmentId,
                             DepartmentName = customer.Department.DepartmentName,
                             CustomerName = customer.CustomerName,
                             Adress = customer.Adress,
                             AdressDetail = customer.AdressDetail,
                             PlaceId = customer.PlaceId,
                             PlaceName = place.PlaceName,
                             CountryId = customer.CountryId,
                             CountryName = country.CountryName,
                             PostalCode = customer.PostalCode,
                             Email = customer.Email,
                             Phone = customer.Phone,
                             Fax = customer.Fax,
                             IsPassive = customer.IsPassive,
                             ContactName = customer.ContactName,
                             ContactEmail = customer.ContactEmail,
                             ContactPhone = customer.ContactPhone,
                             ContactPosition = customer.ContactPosition,
                             SAPCompanyCode = customer.SAPCompanyCode,
                             PaymentTerms = customer.PaymentTerms,
                             VATRate = customer.VATRate,
                             SectorId = customer.SectorId,
                             SectorName = sector.SectorName,
                             Freight = customer.Freight,
                             PaymentTypeId = customer.PaymentTypeId,
                             PaymentTypeName = paymentType.PaymentTypeName,
                             InvoiceEmail = customer.InvoiceEmail,
                             Description = customer.Description,
                             State = place.State,
                             BarsisCustomerId = customer.BarsisCustomerId,
                             InsUser= customer.InsUser
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
