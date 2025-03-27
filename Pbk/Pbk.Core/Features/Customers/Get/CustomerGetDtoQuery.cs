using AutoMapper;
using Pbk.Core.Features.Response;
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


    public sealed record CustomerGetDtoQuery : IRequest<APIResponse>
    {
        internal sealed class CustomerGetDtoQueryHandler : IRequestHandler<CustomerGetDtoQuery, APIResponse>
        {
            private readonly ICustomerRepository _customerRepository;
            private readonly IPlaceRepository _placeRepository;
            private readonly IDepartmentRepository _departmentRepository;
            private readonly IMapper _mapper;

            public CustomerGetDtoQueryHandler(ICustomerRepository customerRepository, IMapper mapper, IPlaceRepository placeRepository, IDepartmentRepository departmentRepository)
            {
                _customerRepository = customerRepository;
                _mapper = mapper;
                _placeRepository = placeRepository;
                _departmentRepository = departmentRepository;
            }

            public async Task<APIResponse> Handle(CustomerGetDtoQuery request, CancellationToken cancellationToken)
            {
                try
                {

                    var data = _mapper.Map<List<GetCustomerNameDto>>(_customerRepository.GetWhere(w => w.IsPassive == false).ToList());

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
