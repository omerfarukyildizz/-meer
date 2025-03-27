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
   

    public sealed record CarrierGetQuery(int? DepartmentId) : IRequest<APIResponse>
    {
        internal sealed class CarrierGetQueryHandler : IRequestHandler<CarrierGetQuery, APIResponse>
        {
            private readonly ICarrierRepository _carrierRepository;
            private readonly IDepartmentRepository _departmentRepository;
            private readonly IUserManager _userManager;
            private readonly IMapper _mapper;
            public CarrierGetQueryHandler(ICarrierRepository carrierRepository, IMapper mapper, IDepartmentRepository departmentRepository, IUserManager userManager)
            {
                _carrierRepository = carrierRepository;
                _mapper = mapper;
                _departmentRepository = departmentRepository;
                _userManager = userManager;
            }

            public async Task<APIResponse> Handle(CarrierGetQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    if (!_userManager.isPermesion("Carriers", "Get", request.DepartmentId))
                    {
                        return new(status: OperationResult.Error, messages: "Yetkiniz Yok.", null);
                    }

                    List<int> dep = new List<int>();
                    if (!request.DepartmentId.HasValue)
                    {
                        dep =  _userManager.getDepartmansPagePerms("Carriers", "Get");
                    }


                    var data = (from carrier in _carrierRepository.GetWhere(w => w.IsPassive == false)
                                join department in _departmentRepository.GetWhere(x=> request.DepartmentId.HasValue ?  x.DepartmentId==request.DepartmentId : dep.Contains(x.DepartmentId))
                                on carrier.DepartmentId equals department.DepartmentId
                                select new 
                                {
                                    CarrierId = carrier.CarrierId,
                                    DepartmentId = department.DepartmentId,
                                    DepartmentName = department.DepartmentName,
                                    CarrierName = carrier.CarrierName,
                                    TimocomId = carrier.TimocomId,
                                    SAPAccountCode = carrier.SAPAccountCode,
                                    PaymentTerms = carrier.PaymentTerms,
                                    DocumentId = carrier.DocumentId,
                                    ContactPerson = carrier.ContactPerson,
                                    Email = carrier.Email,
                                    Phone = carrier.Phone,
                                    IsPassive = carrier.IsPassive,
                                    InsUser = carrier.InsUser,
                                    InsTime = carrier.InsTime,
                                    UpdUser = carrier.UpdUser,
                                    UpdTime = carrier.UpdTime
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
