using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Entities.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Customers.Get
{
  

    public sealed record CustomerNameByShipmentIdGetQuery(int? shipmentId, string? search) : IRequest<APIResponse>
    {
        internal sealed class CustomerNameByShipmentIdGetQueryHandler : IRequestHandler<CustomerNameByShipmentIdGetQuery, APIResponse>
        {
            private readonly ICustomerRepository _customerRepository;
            private readonly IShipmentRepository _shipmentRepository;
            private readonly IStageRepository _stageRepository;
            private readonly IMapper _mapper;

            public CustomerNameByShipmentIdGetQueryHandler(ICustomerRepository customerRepository, IMapper mapper, IShipmentRepository shipmentRepository, IStageRepository stageRepository)
            {
                _customerRepository = customerRepository;
                _mapper = mapper;
                _shipmentRepository = shipmentRepository;
                _stageRepository = stageRepository;
            }

            public async Task<APIResponse> Handle(CustomerNameByShipmentIdGetQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var data = (from c in _customerRepository.GetWhere(w => w.IsPassive == false)
                                join s in _shipmentRepository.GetAll() on c.CustomerId equals s.CustomerId
                                  where s.ShipmentId == request.shipmentId
                                  select new
                                  {
                                      c.CustomerId,
                                      c.CustomerName
                                  })
                                  .Distinct()  
                                  .ToList();

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
