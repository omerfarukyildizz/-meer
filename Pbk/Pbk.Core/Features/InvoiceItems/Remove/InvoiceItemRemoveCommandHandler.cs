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
using Pbk.Core.Features.InvoiceItems.Remove;
using Pbk.Core.Features.Users;
namespace Pbk.Core.Features.InvoiceItems.Remove
{
 

    internal sealed class InvoiceItemRemoveCommandHandler : IRequestHandler<InvoiceItemRemoveCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly IInvoiceItemRepository _invoiceItemRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;


        public InvoiceItemRemoveCommandHandler(ITranslate tanslate, IMapper mapper, IInvoiceItemRepository invoiceItemRepository, IUnitOfWork unitOfWork, IUserManager userManager)
        {
            _tanslate = tanslate;
            _invoiceItemRepository = invoiceItemRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<APIResponse> Handle(InvoiceItemRemoveCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var data =  _invoiceItemRepository.GetWhere(w => w.InvoiceItemId == request.InvoiceItemId).FirstOrDefault();
                if (data == null)
                {
                    return new(status: OperationResult.Error, messages: "Kayıt bulunamadı", null);
                }
                var user = _userManager.UserInfo().UserId;
                data.IsPassive = true;
                data.UpdTime = DateTime.Now;
                data.UpdUser = user;
                _invoiceItemRepository.Update(data);
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
