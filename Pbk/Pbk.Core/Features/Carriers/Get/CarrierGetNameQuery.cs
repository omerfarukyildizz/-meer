using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Core.Features.Users;
using Pbk.Core.Utilities.IResults;
using Pbk.Entities.Dto;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Carriers.Get
{
   

    public sealed record CarrierGetNameQuery(string? search, int departmentId) : IRequest<APIResponse>
    {
        internal sealed class CarrierGetNameQueryHandler : IRequestHandler<CarrierGetNameQuery, APIResponse>
        {
            private readonly ICarrierRepository _carrierRepository;
            private readonly IUserManager _userManager;
            private readonly IMapper _mapper;
            public CarrierGetNameQueryHandler(ICarrierRepository carrierRepository, IMapper mapper, IUserManager userManager)
            {
                _carrierRepository = carrierRepository;
                _mapper = mapper;
                _userManager = userManager;
            }

            public async Task<APIResponse> Handle(CarrierGetNameQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    if (request.departmentId==null || request.departmentId == 0)
                    {
                        return new(status: StatusType.Error, messages: "Department boş olamaz.", null);

                    }
                    if (!_userManager.isPermesion("Carriers", "Get", null))
                    {
                        return new(status: OperationResult.Error, messages: "Yetkiniz Yok.", null);
                    }
                    var data = (from carrier in _carrierRepository.GetWhere(w => w.IsPassive == false && w.DepartmentId == request.departmentId)
                                where (string.IsNullOrWhiteSpace(request.search))
                                      || (!string.IsNullOrWhiteSpace(request.search) && carrier.CarrierName.StartsWith(request.search))
                                select new 
                                {
                                    CarrierId = carrier.CarrierId,
                                    CarrierName = carrier.CarrierName,
                                    CarrierEmail= carrier.Email
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
