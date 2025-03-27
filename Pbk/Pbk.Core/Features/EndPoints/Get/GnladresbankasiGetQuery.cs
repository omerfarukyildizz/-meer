using Pbk.Core.Features.Response;
using Pbk.Entities.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.EndPoints.Get
{

    public sealed record GnladresbankasiGetQuery(string departmentCode) : IRequest<APIResponse>
    {
        internal sealed class GnladresbankasiGetQueryHandler : IRequestHandler<GnladresbankasiGetQuery, APIResponse>
        {
            private readonly IEndPointRepository _endPointRepository;

            public GnladresbankasiGetQueryHandler(IEndPointRepository endPointRepository)
            {
                _endPointRepository = endPointRepository;
            }

            public async Task<APIResponse> Handle(GnladresbankasiGetQuery request, CancellationToken cancellationToken)
            {
                try
                {

                    //var data = _endPointRepository.getContext.Set<Pbk.Entities.Models.Gnladresbankasi>() // Dinamik tablo seçimi
                    //    .Where(x => x.gonderici_alici == true && x.YurtDisiBglDepartman == request.departmentCode) // Filtreleme
                    //    .ToList();

                    return new(status: StatusType.Success, messages: "", null);

                }
                catch (Exception ex)
                {
                    return new(status: StatusType.Error, messages: ex?.InnerException?.Message ?? ex?.Message, null);
                }
            }
        }
    }
}
