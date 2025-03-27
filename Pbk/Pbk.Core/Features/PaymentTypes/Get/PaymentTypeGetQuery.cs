using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.PaymentTypes.Get
{
 
    public sealed record PaymentTypeGetQuery(string? search) : IRequest<APIResponse>
    {
        internal sealed class PaymentTypeGetQueryHandler : IRequestHandler<PaymentTypeGetQuery, APIResponse>
        {
            private readonly IParameterRepository  _parameterRepository;
            private readonly IParameterValueRepository _parameterValueRepository;
            private readonly IMapper _mapper;

            public PaymentTypeGetQueryHandler(IParameterRepository parameterRepository, IParameterValueRepository parameterValueRepository, IMapper mapper)
            {
                _parameterRepository = parameterRepository;
                _parameterValueRepository = parameterValueRepository;
                _mapper = mapper;
            }

            public async Task<APIResponse> Handle(PaymentTypeGetQuery request, CancellationToken cancellationToken)
            {
                try
                {

                    var data = (from pv in _parameterValueRepository.GetAll().Select( w=>  new { ParameterId=w.ParameterId, ParameterValueId =  w.ParameterValueId, Code = w.Code })
                                join p in _parameterRepository.GetWhere(p=> p.ParameterName == "FreightPaymentType" && p.CategoryName == "Payment")
                                on pv.ParameterId equals p.ParameterId
                                where (string.IsNullOrEmpty(request.search) ||
                                                        pv.Code.StartsWith(request.search))
                                select new
                                {
                                    ParameterValueId=pv.ParameterValueId,
                                    Code = pv.Code
                                }).Take(string.IsNullOrWhiteSpace(request.search) ? 500 : int.MaxValue).ToList();
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
