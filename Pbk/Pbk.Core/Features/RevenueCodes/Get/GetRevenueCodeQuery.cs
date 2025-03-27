using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.RevenueCodes.Get
{
    public sealed record GetRevenueCodeQuery(int? departmentId) : IRequest<APIResponse>
    {
        internal sealed class GetRevenueCodeQueryHandler : IRequestHandler<GetRevenueCodeQuery, APIResponse>
        {
            private readonly IRevenueCodeRepository _revenueCodeRepository;
            private readonly IMapper _mapper;

            public GetRevenueCodeQueryHandler(IRevenueCodeRepository revenueCodeRepository, IMapper mapper)
            {
                _revenueCodeRepository = revenueCodeRepository;
                _mapper = mapper;
            }

            public async Task<APIResponse> Handle(GetRevenueCodeQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var data = (from revenueCode in _revenueCodeRepository.GetAll()
                                where !request.departmentId.HasValue || revenueCode.DepartmentId == request.departmentId
                                select new
                                {
                                    RevenueCodeId = revenueCode.RevenueCodeId,
                                    RevenueCodeName = revenueCode.RevenueCodeName
                                })
                            .Distinct()
                            .ToList();

                    return new(status: StatusType.Success, messages: "", data);
                }
                catch (Exception ex)
                {
                    // Hata durumunda hata mesajı döndür
                    return new(status: StatusType.Error, messages: ex?.InnerException?.Message ?? ex?.Message, null);
                }
            }
        }

    }
}
