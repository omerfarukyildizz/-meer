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
using Pbk.Core.Features.Invoices.Remove;
using Pbk.Core.Features.Users;
namespace Pbk.Core.Features.Invoices.Remove
{


    internal sealed class InvoiceRemoveCommandHandler : IRequestHandler<InvoiceRemoveCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;

        public InvoiceRemoveCommandHandler(ITranslate tanslate, IMapper mapper, IInvoiceRepository invoiceRepository, IUnitOfWork unitOfWork, IUserManager userManager)
        {
            _tanslate = tanslate;
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<APIResponse> Handle(InvoiceRemoveCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var data = _invoiceRepository.GetWhere(w => w.InvoiceId == request.InvoiceId).FirstOrDefault();
                if (data == null)
                {
                    return new(status: OperationResult.Error, messages: "Kayıt bulunamadı", null);
                }
                var user = _userManager.UserInfo().UserId;
                data.IsPassive = true;
                data.UpdTime = DateTime.Now;
                data.UpdUser = user;
                _invoiceRepository.Update(data);
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
