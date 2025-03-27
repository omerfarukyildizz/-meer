using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Core.Features.Users;
using Pbk.Entities.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Pbk.Core.Features.Shipments.Get
{
    public sealed record ShipmentToCustomerByCostItemGetQuery(string? search,int departmentId) : IRequest<APIResponse>
    {
        internal sealed class ShipmentToCustomerByCostItemGetQueryHandler : IRequestHandler<ShipmentToCustomerByCostItemGetQuery, APIResponse>
        {
            private readonly IShipmentRepository _shipmentRepository;
            private readonly ICustomerRepository _customerRepository;
            private readonly IUserManager _userManager;
            private readonly IMapper _mapper;

            public ShipmentToCustomerByCostItemGetQueryHandler(IShipmentRepository shipmentRepository, ICustomerRepository customerRepository, IUserManager userManager, IMapper mapper)
            {
                _shipmentRepository = shipmentRepository;
                _customerRepository = customerRepository;
                _userManager = userManager;
                _mapper = mapper;
            }


            //Shipment Type Dropdown
            public async Task<APIResponse> Handle(ShipmentToCustomerByCostItemGetQuery request, CancellationToken cancellationToken)
            {
                try
                {

                    var data = (from s in _shipmentRepository.GetWhere(x=>x.StatusTypeId==5 && x.IsPassive==false && x.DepartmentId==request.departmentId)
                                join c in _customerRepository.GetAll()
                                on s.CustomerId equals c.CustomerId
                                where (string.IsNullOrWhiteSpace(request.search))
                                    || (!string.IsNullOrWhiteSpace(request.search) && c.CustomerName.StartsWith(request.search))
                                      
                                select new
                                {
                                    s.ShipmentId,
                                    c.CustomerName,
                                    s.VATRate
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
