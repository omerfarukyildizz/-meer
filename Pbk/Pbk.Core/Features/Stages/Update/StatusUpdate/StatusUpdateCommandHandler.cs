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
using Microsoft.AspNetCore.Identity;
using Pbk.Core.Features.Users.Manager;
using Pbk.Core.Features.Users;
namespace Pbk.Core.Features.Stages.Update.StatusUpdate
{
   
    internal sealed class StatusUpdateCommandHandler : IRequestHandler<StatusUpdateCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly IStageRepository _stageRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;
        private readonly IVoyageRepository _voyageRepository;
        private readonly ICostItemRepository _costItemRepository;
        private readonly IInvoiceItemRepository _invoiceItemRepository;



        public StatusUpdateCommandHandler(IUserManager userManager, ITranslate tanslate, IMapper mapper, IStageRepository stageRepository, IUnitOfWork unitOfWork, IVoyageRepository voyageRepository, ICostItemRepository costItemRepository, IInvoiceItemRepository invoiceItemRepository)
        {
            _tanslate = tanslate;
            _stageRepository = stageRepository;
            _mapper = mapper;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _voyageRepository = voyageRepository;
            _costItemRepository = costItemRepository;
            _invoiceItemRepository = invoiceItemRepository;
        }

        public async Task<APIResponse> Handle(StatusUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var UserId = _userManager.UserInfo().UserId;

                Entities.Models.Stage data = await _stageRepository.GetByIdAsync(w => w.StageId == request.StageId, cancellationToken);

                if (data == null)
                {
                    return new(status: OperationResult.Error, messages: "Kayıt Bulunamadı.", null);
                }

                if(data.StatusTypeId == request.statusTypeId)
                {
                    return new(status: OperationResult.Success, messages: "You cannot update the same StatusTypeId value.", null);
                }

               
                 if(data.VoyageSequence != 1)
                {
                        var oncekiStageStatusId =  _stageRepository.GetWhere(w => w.VoyageId == data.VoyageId && w.VoyageSequence<data.VoyageSequence && w.IsPassive == false).OrderBy(w=>w.VoyageSequence).Select(w=>w.StatusTypeId).FirstOrDefault();
                            if(oncekiStageStatusId != 5)
                        {
                            return new(status: OperationResult.Error, messages: "Previous stage status must be 'Done' to mark this stage as 'On the Way'.", null);
                        }
                }


                var isUpdate = true;
                var errorMessage = "";

                switch (data.StatusTypeId)
                {
                    case 3:
                        if(request.statusTypeId != 4)
                        {
                            isUpdate = false;
                            errorMessage = "You can only update status to 'On the Way' ";
                        }
                        break;

                    case 4:
                        if(!(request.statusTypeId ==3 || request.statusTypeId == 5))
                        {
                            isUpdate = false;
                            errorMessage = "You can only update status to 'In Progress' or 'Done' ";
                        }
                    break;

                    case 5:
                        var departman = _voyageRepository.GetWhere(w => w.VoyageId == data.VoyageId).Select(w => w.DepartmentId).FirstOrDefault();
                        var yetki  = _userManager.isPermesion("Voyages", "Done", departman);
                        if (!yetki)
                        {
                            isUpdate = false;
                            errorMessage = "You cannot edit a stage with status 'Done'. Please contact IT support for assistance.\r\n  ";
                        }

                        if (isUpdate)
                        {
                            if (!(request.statusTypeId == 3 || request.statusTypeId == 4))
                            {
                                isUpdate = false;
                                errorMessage = "You can only update status to 'In Progress' or 'On the Way' ";
                            }
                        }

                        var invoiceItems = _invoiceItemRepository.GetWhere(w => w.VoyageId == data.VoyageId).Count();
                        var costItems    = _costItemRepository.GetWhere(w => w.VoyageId == data.VoyageId).Count();
                        if(invoiceItems > 0 || costItems > 0)
                        {
                            isUpdate = false;
                            errorMessage = "There are some financial records with this voyage. Please delete them first. ";
                        }

                        break;
                }

                if(isUpdate == false)
                {
                    return new(status: OperationResult.Error, messages: errorMessage, null);
                }


                data.StatusTypeId = request.statusTypeId;
                data.UpdUser = UserId;
                data.UpdTime = DateTime.Now;

                _stageRepository.Update(data);
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
