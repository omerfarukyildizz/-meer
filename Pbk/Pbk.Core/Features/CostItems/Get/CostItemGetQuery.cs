using AutoMapper;
using Pbk.Core.Features.Response;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.CostItems.Get
{
 
    public sealed record CostItemGetQuery(int? shipmentId, int? voyageId, int? stageId) : IRequest<APIResponse>
    {
        internal sealed class CostItemGetQueryHandler : IRequestHandler<CostItemGetQuery, APIResponse>
        {
            private readonly ICostItemRepository _costItemRepository;
            private readonly IMapper _mapper;

            public CostItemGetQueryHandler(ICostItemRepository costItemRepository, IMapper mapper)
            {
                _costItemRepository = costItemRepository;
                _mapper = mapper;
            }


            public async Task<APIResponse> Handle(CostItemGetQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var query = from cost in _costItemRepository.GetWhere(x=>x.IsPassive==false) 
                                select new
                                {
                                    CostItemId = cost.CostItemId,
                                    ShipmentId = cost.ShipmentId,
                                    StageId = cost.StageId,
                                    VoyageId = cost.VoyageId,
                                    DepartmentId = cost.DepartmentId,
                                    Vendor = cost.Vendor,
                                    ExpenseCodeId = cost.ExpenseCodeId,
                                    SectorId = cost.SectorId,
                                    Amount = cost.Amount,
                                    CurrencyId = cost.CurrencyId,
                                    VATRate = cost.VATRate,
                                    PaymentTerms = cost.PaymentTerms,
                                    IntegrationNo = cost.IntegrationNo,
                                    InvoiceNo = cost.InvoiceNo,
                                    InvoiceDate = cost.InvoiceDate,
                                    SAPDocumentNo = cost.SAPDocumentNo,
                                    Description = cost.Description,
                                    Year = cost.Year,
                                    BarsisCostId = cost.BarsisCostId,
                                    IsPassive = cost.IsPassive
                                };

                    // Filtreleme işlemleri
                    if (request.shipmentId.HasValue)
                    {
                        query = query.Where(w => w.ShipmentId == request.shipmentId);
                    }
                    else if (request.voyageId.HasValue)
                    {
                        query = query.Where(w => w.VoyageId == request.voyageId);
                    }
                    else if (request.stageId.HasValue)
                    {
                        query = query.Where(e=> e.StageId == request.stageId);
                    }
                    var data = query.OrderBy(e => e.CostItemId).ToList();

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
