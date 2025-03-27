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
    

    public sealed record CostItemByDepartmentIdGetQuery(int departmentId) : IRequest<APIResponse>
    {
        internal sealed class CostItemByDepartmentIdGetQueryHandler : IRequestHandler<CostItemByDepartmentIdGetQuery, APIResponse>
        {
            private readonly ICostItemRepository _costItemRepository;
            private readonly IDepartmentRepository _departmentRepository;
            private readonly IExpenseCodeRepository _expenseCodeRepository;
            private readonly ISectorRepository _sectorRepository;
            private readonly ICurrencyRepository _currencyRepository;

            public CostItemByDepartmentIdGetQueryHandler(ICostItemRepository costItemRepository, IDepartmentRepository departmentRepository, IExpenseCodeRepository expenseCodeRepository, ISectorRepository sectorRepository, ICurrencyRepository currencyRepository)
            {
                _costItemRepository = costItemRepository;
                _departmentRepository = departmentRepository;
                _expenseCodeRepository = expenseCodeRepository;
                _sectorRepository = sectorRepository;
                _currencyRepository = currencyRepository;
            }


            public async Task<APIResponse> Handle(CostItemByDepartmentIdGetQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    if (request.departmentId == null || request.departmentId == 0)
                    {
                        return new(status: StatusType.Success, messages: "Department boş olamaz.", null);

                    }
                    var data = from cost in _costItemRepository.GetWhere(x => x.DepartmentId == request.departmentId && x.IsPassive == false)
                               join department in _departmentRepository.GetAll() on cost.DepartmentId equals department.DepartmentId
                               join expense in _expenseCodeRepository.GetAll() on cost.ExpenseCodeId equals expense.ExpenseCodeId
                               join curreny in _currencyRepository.GetAll() on cost.CurrencyId  equals curreny.CurrencyId
                               join sector in _sectorRepository.GetAll () on cost.SectorId equals sector.SectorId
                                select new
                                {
                                    CostItemId = cost.CostItemId,
                                    ShipmentId = cost.ShipmentId,
                                    StageId = cost.StageId,
                                    VoyageId = cost.VoyageId,
                                    DepartmentId = cost.DepartmentId,
                                    DepartmentName = department.DepartmentName,
                                    Vendor = cost.Vendor,
                                    ExpenseCodeId = cost.ExpenseCodeId,
                                    ExpenseCodeName = expense.ExpenseCodeName,
                                    SectorId = cost.SectorId,
                                    SectorName = sector.SectorName,
                                    Amount = cost.Amount,
                                    CurrencyId = cost.CurrencyId,
                                    CurrencyCode = curreny.CurrencyCode,
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
