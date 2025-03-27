using AutoMapper;
using Pbk.Core.Features.User;
using Pbk.Core.Features.Response;
using Pbk.Core.Utilities.IResults;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pbk.Entities.Models;
using Pbk.Core.Features.Shipments.Remove;
using Pbk.Core.Features.Users;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Pbk.Entities.Models2;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
namespace Pbk.Core.Features.Shipments.Remove
{


    internal sealed class ShipmentRemoveCommandHandler : IRequestHandler<ShipmentRemoveCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly IShipmentRepository _shipmentRepository;
        private readonly ICostItemRepository _costItemRepository;
        private readonly IPlannedStageRepository _plannedStageRepository;
        private readonly IInvoiceItemRepository _invoiceItemRepository;
        private readonly IStageRepository _stageRepository;
        private readonly IUserManager _userManager;
        private readonly IUnitOfWork _unitOfWork;

        public ShipmentRemoveCommandHandler(ITranslate tanslate, IMapper mapper, IShipmentRepository shipmentRepository, IUnitOfWork unitOfWork, IUserManager userManager, ICostItemRepository costItemRepository, IInvoiceItemRepository invoiceItemRepository, IStageRepository stageRepository, IPlannedStageRepository plannedStageRepository)
        {
            _tanslate = tanslate;
            _shipmentRepository = shipmentRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _costItemRepository = costItemRepository;
            _invoiceItemRepository = invoiceItemRepository;
            _stageRepository = stageRepository;
            _plannedStageRepository = plannedStageRepository;
        }

        public async Task<APIResponse> Handle(ShipmentRemoveCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!_userManager.isPermesion("Shipments", "Remove", request.DepartmentId))
                {
                    return new(status: OperationResult.Error, messages: "You do not have permission to delete shipment", null);

                }
                var user = _userManager.UserInfo();

                

                var checkInCostItem = _costItemRepository.GetWhere(x => x.ShipmentId == request.ShipmentId);
                var checkInInvoiceItem = _invoiceItemRepository.GetWhere(x => x.ShipmentId == request.ShipmentId);
                var stageInShipment = _stageRepository.GetWhere(x => x.ShipmentId == request.ShipmentId);
                if (checkInCostItem.Count() > 0)
                {
                    return new(status: OperationResult.Error, messages: "There are financial items associated with this shipment. Please delete all related CostItems first.", null);
                }
                if (checkInInvoiceItem.Count() > 0)
                {
                    return new(status: OperationResult.Error, messages: "There are financial items associated with this shipment. Please delete all related InvoiceItems first.", null);
                }

                if (stageInShipment.Count() > 0)
                {
                    if (_costItemRepository.GetWhere(x => stageInShipment.Select(s => s.StageId).Contains(x.StageId ?? 0)).Any())
                    {
                        return new(status: OperationResult.Error, messages: "There are some financial records belong to stages. Please delete all related CostItems first.", null);
                    }

                    if (_invoiceItemRepository.GetWhere(x => stageInShipment.Select(s => s.StageId).Contains(x.StageId ?? 0)).Any())
                    {
                        return new(status: OperationResult.Error, messages: "There are some financial records belong to stages. Please delete all related InvoiceItems first.", null);
                    }



                    var done = stageInShipment.Where(x => x.StatusTypeId == 5);
                    if (done.Count() > 0)
                    {
                        return new(status: OperationResult.Error, messages: "A shipment with completed stages cannot be deleted.", null);
                    }

                    var InProgressOrOnTheWay = stageInShipment.Where(x => x.StatusTypeId == 3 || x.StatusTypeId == 4);
                    if (InProgressOrOnTheWay.Count() > 0)
                    {
                        return new(status: OperationResult.Error, messages: "Some stages within this shipment are associated with an active Voyage. Please remove the stages from the Voyage first.", null);
                    }

                    var waiting = stageInShipment.Where(x => x.StatusTypeId == 1);
                    if (waiting.Count() == stageInShipment.Count())
                    {
                        var data = _shipmentRepository.GetWhere(w => w.ShipmentId == request.ShipmentId).FirstOrDefault();
                        data.UpdTime = DateTime.Now;
                        data.UpdUser = user.UserId;
                        data.IsPassive = true;
                        _shipmentRepository.Update(data);
                        foreach (var item in waiting)
                        {
                            item.UpdUser = user.UserId;
                            item.UpdTime = DateTime.Now;
                            item.IsPassive = true;
                            _stageRepository.Update(item);

                        }
                        await _unitOfWork.SaveChangesAsync(cancellationToken);
                        return new(status: OperationResult.Success, messages: "The shipment and all its stages have been successfully deleted.", data);
                    }

                    var plannedStages = stageInShipment.Where(x => x.StatusTypeId == 2);
                    if (plannedStages.Count() == stageInShipment.Count())
                    {
                        var plannedStageIds = plannedStages.Select(x => x.StageId).ToList();
                        // PlannedStages tablosundaki ilgili StageId kayıtlarını pasifleştir
                        foreach (var stageId in plannedStageIds)
                        {
                            var plannedStage = _plannedStageRepository.GetWhere(x => x.StageId == stageId).FirstOrDefault();
                            if (plannedStage != null)
                            {
                                plannedStage.IsPassive = true;
                                _plannedStageRepository.Update(plannedStage);
                            }
                        }
                        // Shipments ve Stages tablosundaki ilgili kayıtları pasifleştir
                        foreach (var stage in stageInShipment)
                        {
                            stage.IsPassive = true;
                            stage.UpdTime = DateTime.Now;
                            stage.UpdUser = user.UserId;
                            _stageRepository.Update(stage);
                        }
                        var shipmentForPlanned = _shipmentRepository.GetWhere(w => w.ShipmentId == request.ShipmentId).FirstOrDefault();

                        if (shipmentForPlanned != null)
                        {
                            shipmentForPlanned.IsPassive = true;
                            shipmentForPlanned.UpdUser = user.UserId;
                            shipmentForPlanned.UpdTime = DateTime.Now;
                            _shipmentRepository.Update(shipmentForPlanned);
                        }

                        await _unitOfWork.SaveChangesAsync(cancellationToken);
                        return new(status: OperationResult.Error, messages: "The shipment has been deleted after being removed from the planned vehicles.", null);
                    }

                    // Planned Or Waiting
                    var plannedStagesList = stageInShipment.Where(s => s.StatusTypeId == 1).ToList();
                    var waitingStagesist = stageInShipment.Where(s => s.StatusTypeId == 2).ToList();
                    foreach (var stage in plannedStagesList)
                    {
                        var plannedStage = _plannedStageRepository.GetWhere(x => x.StageId == stage.StageId).FirstOrDefault();
                        if (plannedStage != null)
                        {
                            plannedStage.IsPassive = true;
                            _plannedStageRepository.Update(plannedStage);
                        }
                    }
                    foreach (var stage in stageInShipment)
                    {
                        stage.IsPassive = true;
                        stage.UpdTime = DateTime.Now;
                        stage.UpdUser = user.UserId;
                        _stageRepository.Update(stage);

                    }
                    var shipment = _shipmentRepository.GetWhere(s => s.ShipmentId == request.ShipmentId).FirstOrDefault();
                    if (shipment != null)
                    {
                        shipment.IsPassive = true;
                        shipment.UpdTime = DateTime.Now;
                        shipment.UpdUser = user.UserId;
                        _shipmentRepository.Update(shipment);
                    }
                    await _unitOfWork.SaveChangesAsync(cancellationToken);
                    return new(status: OperationResult.Success, messages: "The shipment has been deleted after being removed from the planned vehicles.", null);
                }
                else
                {
                    var deleteShipment = _shipmentRepository.GetWhere(x => x.ShipmentId == request.ShipmentId).FirstOrDefault();
                    deleteShipment.UpdTime = DateTime.Now;
                    deleteShipment.UpdUser = user.UserId;
                    deleteShipment.IsPassive = true;
                    _shipmentRepository.Update(deleteShipment);
                    await _unitOfWork.SaveChangesAsync(cancellationToken);
                    return new(status: OperationResult.Success, messages: "", null);
                }



            }
            catch (Exception ex)
            {
                return new(status: OperationResult.Error, messages: ex.Message, null);
            }

        }

    }



}
