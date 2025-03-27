using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Core.Features.Users;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Shipments.Get
{ 
    public sealed record ShipmentToCustomerByDepartmentIdGetQuery(int departmentId,string? search) : IRequest<APIResponse>
    {
        internal sealed class ShipmentToCustomerByDepartmentIdGetQueryHandler : IRequestHandler<ShipmentToCustomerByDepartmentIdGetQuery, APIResponse>
        {
            private readonly IShipmentRepository _shipmentRepository;
            private readonly ICustomerRepository _customerRepository;
            private readonly IUserManager _userManager;
            private readonly IMapper _mapper;

            public ShipmentToCustomerByDepartmentIdGetQueryHandler(IShipmentRepository shipmentRepository, ICustomerRepository customerRepository, IUserManager userManager, IMapper mapper)
            {
                _shipmentRepository = shipmentRepository;
                _customerRepository = customerRepository;
                _userManager = userManager;
                _mapper = mapper;
            }


            //Shipment Type Dropdown
            public async Task<APIResponse> Handle(ShipmentToCustomerByDepartmentIdGetQuery request, CancellationToken cancellationToken)
            {
                try
                {

                    var data = (from s in _shipmentRepository.GetAll()
                                join c in _customerRepository.GetAll()
                                on s.CustomerId equals c.CustomerId
                                where s.IsPassive == false
                                      && s.DepartmentId == request.departmentId
                                      && s.StatusTypeId == 5
                                      && (string.IsNullOrWhiteSpace(request.search)
                                          || (!string.IsNullOrWhiteSpace(request.search) && c.CustomerName.StartsWith(request.search)))
                                select new
                                {
                                    s.ShipmentId,
                                    c.CustomerName
                                });

                    if (!string.IsNullOrEmpty(request.search))
                    {
                        data = data.Take(string.IsNullOrEmpty(request.search) ? 100 : int.MaxValue);
                    }


                    return new(status: StatusType.Success, messages: "", data.ToList());
                }
                catch (Exception ex)
                {
                    return new(status: StatusType.Error, messages: ex?.InnerException?.Message ?? ex?.Message, null);
                }
            }
        }
    }
}
