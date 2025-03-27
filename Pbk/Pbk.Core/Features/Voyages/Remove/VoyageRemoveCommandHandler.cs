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
using Pbk.Core.Features.Users;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Pbk.Core.Features.Voyages.Remove
{


    internal sealed class VoyageRemoveCommandHandler : IRequestHandler<VoyageRemoveCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly IVoyageRepository _voyageRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;
        private readonly ICostItemRepository _costItemRepository;
        private readonly IInvoiceItemRepository _invoiceItemRepository;
        private readonly IStageRepository _stageRepository;


        public VoyageRemoveCommandHandler(ITranslate tanslate, IMapper mapper, IVoyageRepository voyageRepository, IUnitOfWork unitOfWork, IUserManager userManager, ICostItemRepository costItemRepository, IInvoiceItemRepository invoiceItemRepository, IStageRepository stageRepository)
        {
            _tanslate = tanslate;
            _voyageRepository = voyageRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _costItemRepository = costItemRepository;
            _invoiceItemRepository = invoiceItemRepository;
            _stageRepository = stageRepository;
        }

        public async Task<APIResponse> Handle(VoyageRemoveCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!_userManager.isPermesion("Voyages", "Remove", request.DepartmentId))
                {
                    return new(status: OperationResult.Error, messages: "You do not have permission to delete this voyage.", null);
                }

                var checkInCostItem = _costItemRepository.GetWhere(x => x.VoyageId == request.VoyageId).Any();
                var checkInInvoiceItem = _invoiceItemRepository.GetWhere(x => x.VoyageId == request.VoyageId).Any();
                if (checkInInvoiceItem)
                {
                    return new(status: OperationResult.Error, messages: "This voyage has financial records. Please delete the following CostItem(s) before proceeding.", null);
                }
                if (checkInCostItem)
                {
                    return new(status: OperationResult.Error, messages: "This voyage has financial records. Please delete the following InvoiceItem(s) before proceeding.", null);
                }
                if (_voyageRepository.GetWhere(x => x.StatusTypeId == 4 && x.VoyageId == request.VoyageId).Any())
                {
                    return new(status: OperationResult.Error, messages: "You cannot delete a voyage with status 'On the Way'. Please contact IT support for assistance.", null);
                }
                if (_voyageRepository.GetWhere(x => x.StatusTypeId == 5 && x.VoyageId == request.VoyageId).Any())
                {
                    return new(status: OperationResult.Error, messages: "You cannot delete a voyage with status 'Done'. Please contact IT support for assistance.", null);
                }
                var voyage = _voyageRepository.GetWhere(x => x.StatusTypeId == 3 && x.VoyageId == request.VoyageId).FirstOrDefault();
                var user = _userManager.UserInfo().UserId;

                if (voyage != null)
                {
                    var relatedStages = _stageRepository.GetWhere(s => s.VoyageId == voyage.VoyageId).ToList();
                    foreach (var stage in relatedStages)
                    {
                        stage.VoyageId = null;
                        stage.StatusTypeId = 1;
                        _stageRepository.Update(stage);
                    }
                    voyage.IsPassive = true;
                    voyage.UpdTime = DateTime.Now;
                    voyage.UpdUser = user;
                    _voyageRepository.Update(voyage);
                    await _unitOfWork.SaveChangesAsync(cancellationToken);
                    return new(status: OperationResult.Success, messages: "", voyage);

                }
                var data = _voyageRepository.GetWhere( x=> x.VoyageId == request.VoyageId).FirstOrDefault();
                data.IsPassive = true;
                data.UpdTime = DateTime.Now;
                data.UpdUser = user;
                _voyageRepository.Update(data);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                return new(status: OperationResult.Success, messages: "", data);
            }
            catch (Exception ex)
            {
                return new(status: OperationResult.Error, messages: ex.Message, null);
            }

        }

    }



}
