using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Entities.Dto;
using Pbk.Entities.Dto.Customer;
using Pbk.Entities.Models2;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Customers.Get
{


    public sealed record CustomerNameGetQuery(int departmentId, string? search) : IRequest<APIResponse>
    {
        internal sealed class CustomerNameGetQueryHandler : IRequestHandler<CustomerNameGetQuery, APIResponse>
        {
            private readonly ICustomerRepository _customerRepository;
            private readonly IMapper _mapper;

            public CustomerNameGetQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
            {
                _customerRepository = customerRepository;
                _mapper = mapper;
            }

            public async Task<APIResponse> Handle(CustomerNameGetQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    if (request.departmentId == null || request.departmentId == 0)
                    {
                        return new(status: StatusType.Error, messages: "Department boş olamaz.", null);
                    }
                    var data = (from customer in _customerRepository.GetWhere(w => w.IsPassive == false && w.DepartmentId==request.departmentId)
                                where (string.IsNullOrWhiteSpace(request.search)
                                          || customer.CustomerName.StartsWith(request.search)
                                          || customer.PostalCode.StartsWith(request.search))
                                      && (customer.Department.DepartmentId == request.departmentId)
                                select new
                                {
                                    CustomerId = customer.CustomerId,
                                    CustomerName = customer.CustomerName,
                                    Freight=customer.Freight,
                                    VATRate=customer.VATRate,
                                    PaymentTerms=customer.PaymentTerms,
                                    FreightPaymentType=customer.PaymentTypeId,
                                    PostalCode=customer.PostalCode
                                })
                          .Take(string.IsNullOrWhiteSpace(request.search) ? 500 : int.MaxValue)
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
