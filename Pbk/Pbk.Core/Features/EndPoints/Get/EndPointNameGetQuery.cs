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

namespace Pbk.Core.Features.EndPoints.Get
{


    public sealed record EndPointNameGetQuery(int departmentId, string? search) : IRequest<APIResponse>
    {
        internal sealed class EndPointNameGetQueryHandler : IRequestHandler<EndPointNameGetQuery, APIResponse>
        {
            private readonly IEndPointRepository _endPointRepository;
            private readonly IUserManager _userManager;
            private readonly IMapper _mapper;

            public EndPointNameGetQueryHandler(IEndPointRepository endPointRepository, IMapper mapper, IUserManager userManager)
            {
                _endPointRepository = endPointRepository;
                _mapper = mapper;
                _userManager = userManager;
            }

            public async Task<APIResponse> Handle(EndPointNameGetQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    if (request.departmentId == null)
                    {
                        return new(status: StatusType.Error, messages: "departmentId boş olamaz", null);

                    }


                    var data = (from endpoint in _endPointRepository.GetWhere(w => w.Department.IsPassive == false)
                                where
                                    (request.departmentId == null || endpoint.Department.DepartmentId == request.departmentId) && // Departman ID kontrolü
                                    (string.IsNullOrWhiteSpace(request.search)
                                        || endpoint.PointName.StartsWith(request.search)
                                        || endpoint.PostalCode.StartsWith(request.search))  
                                select new
                                {
                                    PointId = endpoint.PointId,
                                    PointName = endpoint.PointName,
                                    PostalCode = endpoint.PostalCode
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
