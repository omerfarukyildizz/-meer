using AutoMapper;
using Pbk.Core.Features.User;
using Pbk.Core.Features.Response;
using Pbk.Core.Utilities.IResults;
using Pbk.Entities.Repositories;
using MediatR;
using Pbk.Core.Features.Users;
namespace Pbk.Core.Features.Stages.Remove
{
 

    internal sealed class StageRemoveCommandHandler : IRequestHandler<StageRemoveCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly IStageRepository _stageRepository;
        private readonly IPlannedStageRepository _plannedStageRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;
        private readonly ICostItemRepository _costItemRepository;
        private readonly IInvoiceItemRepository _invoiceItemRepository;
        private readonly IShipmentRepository _shipmentRepository;
        public StageRemoveCommandHandler(ITranslate tanslate, IMapper mapper, IStageRepository stageRepository, IUnitOfWork unitOfWork, IUserManager userManager, IPlannedStageRepository plannedStageRepository, ICostItemRepository costItemRepository, IInvoiceItemRepository invoiceItemRepository, IShipmentRepository shipmentRepository)
        {
            _tanslate = tanslate;
            _stageRepository = stageRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _plannedStageRepository = plannedStageRepository;
            _costItemRepository = costItemRepository;
            _invoiceItemRepository = invoiceItemRepository;
            _shipmentRepository = shipmentRepository;
        }

        public async Task<APIResponse> Handle(StageRemoveCommand request, CancellationToken cancellationToken)
        {
            try
            {   
                // 1. Stage bilgilerini al
                var stage = _stageRepository.GetWhere(x=>x.StageId==request.StageId && x.IsPassive == false).FirstOrDefault();
                if (stage == null)
                {
                    return new(status: OperationResult.Error, messages: "Stage not found or already passive.", null);
                }
                if (!_userManager.isPermesion("Stages", "Remove", request.DepartmentId))
                {
                    return new(status: OperationResult.Error, messages: "You do not have permission to delete this stage", null);
                }

                var user = _userManager.UserInfo().UserId;

                var checkInCostItem = _costItemRepository.GetWhere(x => x.StageId == request.StageId).Any();
                var checkInInvoiceItem = _invoiceItemRepository.GetWhere(x => x.StageId == request.StageId).Any();
                if (checkInInvoiceItem)
                {
                    return new(status: OperationResult.Error, messages: "This stage has financial records. Please delete the following CostItem(s) before proceeding.", null);
                }
                if (checkInCostItem)
                {
                    return new(status: OperationResult.Error, messages: "This stage has financial records. Please delete the following InvoiceItem(s) before proceeding.", null);
                }
                if (stage.StatusTypeId== 3 || stage.StatusTypeId == 4)
                {
                    return new(status: OperationResult.Error, messages: "This stage is linked to a voyage. Please unassign the stage from the voyage [VoyageId] first.", null);

                }
                if (stage.StatusTypeId == 5 )
                {
                    return new(status: OperationResult.Error, messages: "You cannot delete a stage with status 'Done'. Please contact IT support for assistance.", null);

                }
                // 2. Shipment bilgilerini al
                var shipment = _shipmentRepository.GetWhere(sh => sh.ShipmentId == stage.ShipmentId && sh.IsPassive == false).FirstOrDefault();
                if (shipment == null)
                {
                    return new(status: OperationResult.Error, messages: "Shipment not found or already passive.", null);
                }
                // 3. Shipment içerisindeki Stage sayısını kontrol et
                var stageCount = _stageRepository.GetWhere(s => s.ShipmentId == shipment.ShipmentId && s.IsPassive == false).Count();
                var plannedStages = _plannedStageRepository.GetWhere(ps => ps.StageId == stage.StageId && ps.IsPassive == false).ToList();

                if (stage.StatusTypeId==1)
                {
                    if (stageCount == 1)
                    {
                        shipment.IsPassive = true;
                        shipment.UpdTime = DateTime.Now;
                        shipment.UpdUser = user;
                        _shipmentRepository.Update(shipment);

                        stage.IsPassive = true;
                        stage.UpdTime = DateTime.Now;
                        stage.UpdUser = user;
                        _stageRepository.Update(stage);

                        await _unitOfWork.SaveChangesAsync(); // Değişiklikleri kaydet
                        return new(status: OperationResult.Success, messages: "", stage);

                    }
                    else
                    {
                        // Sadece Stage'in IsPassive alanını güncelle
                        stage.IsPassive = true;
                        stage.UpdTime = DateTime.Now;
                        stage.UpdUser = user;
                        _stageRepository.Update(stage);

                        await _unitOfWork.SaveChangesAsync(); // Değişiklikleri kaydet
                        return new(status: OperationResult.Success, messages: "", stage);
                    }

                }
                if (stage.StatusTypeId == 2)
                {
                    foreach (var plannedStage in plannedStages)
                    {
                        plannedStage.IsPassive = true;
                        _plannedStageRepository.Update(plannedStage);
                    }

                    // Hem Shipment hem de Stage'in IsPassive alanını güncelle
                    shipment.IsPassive = true;
                    shipment.UpdTime = DateTime.Now;
                    shipment.UpdUser = user;
                    _shipmentRepository.Update(shipment);

                    stage.IsPassive = true;
                    stage.UpdTime = DateTime.Now;
                    stage.UpdUser = user;
                    _stageRepository.Update(stage);

                    await _unitOfWork.SaveChangesAsync(); // Değişiklikleri kaydet
                    return new(status: OperationResult.Success, messages: "", stage);

                }

                // Hiçbiri yoksa stage sil
                stage.IsPassive = true;
                stage.UpdUser = _userManager.UserInfo().UserId;
                stage.UpdTime = DateTime.Now;
              
                _stageRepository.Update(stage);

                var liste = _plannedStageRepository.GetWhere(d =>  !d.IsPassive &&  d.StageId == stage.StageId ).ToList();
                if (liste.Count > 0)
                {
                    foreach (var item in liste)
                    {
                        item.IsPassive = true;
                        _plannedStageRepository.Update(item);
                    }
                }

                await _unitOfWork.SaveChangesAsync(cancellationToken);
                return new(status: OperationResult.Success, messages: "", stage);
            }
            catch (Exception ex)
            {
                return new(status: OperationResult.Error, messages: ex.Message, null);
            }

        }

    }



}
