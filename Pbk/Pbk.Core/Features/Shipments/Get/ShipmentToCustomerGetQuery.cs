using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Core.Features.Users;
using Pbk.Core.Utilities.Uniq;
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
    public sealed record ShipmentToCustomerGetQuery(string? search,int departmentId) : IRequest<APIResponse>
    {
        internal sealed class ShipmentToCustomerGetQueryHandler : IRequestHandler<ShipmentToCustomerGetQuery, APIResponse>
        {
            private readonly IShipmentRepository _shipmentRepository;
            private readonly ICustomerRepository _customerRepository;
            private readonly IUserManager _userManager;
            private readonly IMapper _mapper;

            public ShipmentToCustomerGetQueryHandler(IShipmentRepository shipmentRepository, ICustomerRepository customerRepository, IUserManager userManager, IMapper mapper)
            {
                _shipmentRepository = shipmentRepository;
                _customerRepository = customerRepository;
                _userManager = userManager;
                _mapper = mapper;
            }


            //Shipment Type Dropdown
            public async Task<APIResponse> Handle(ShipmentToCustomerGetQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    if (request.departmentId==0 || request.departmentId==null)
                    {
                        return new(status: StatusType.Error, messages: "Department is required.", null);
                    }
                    var isNumber = (string.IsNullOrEmpty(request.search) || string.IsNullOrWhiteSpace(request.search)) ? false :  Regex_Helper.IsNumber(request.search);

                    var data = (from s in _shipmentRepository.GetWhere(x=>x.DepartmentId== request.departmentId && x.IsPassive==false)
                                  join c in _customerRepository.GetAll()
                                  on s.CustomerId equals c.CustomerId
                                  where 

                                      ((
                                      (!string.IsNullOrWhiteSpace(request.search) && !string.IsNullOrWhiteSpace(request.search))
                                      ? 
                                       ( isNumber ? s.ShipmentId == Convert.ToUInt32( request.search)  : c.CustomerName.StartsWith(request.search) )
                                      
                                      : 1==1))

                                        && s.StatusTypeId ==5
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
