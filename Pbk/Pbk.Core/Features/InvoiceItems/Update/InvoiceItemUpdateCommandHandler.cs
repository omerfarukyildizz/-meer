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
using Pbk.Core.Features.Users;
namespace Pbk.Core.Features.InvoiceItems.Update
{

    internal sealed class InvoiceItemUpdateCommandHandler : IRequestHandler<InvoiceItemUpdateCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly IInvoiceItemRepository _invoiceItemRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;


        public InvoiceItemUpdateCommandHandler(IUserManager userManager, ITranslate tanslate, IMapper mapper, IInvoiceItemRepository invoiceItemRepository, IUnitOfWork unitOfWork)
        {
            _tanslate = tanslate;
            _invoiceItemRepository = invoiceItemRepository;
            _mapper = mapper;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<APIResponse> Handle(InvoiceItemUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                

                Entities.Models.InvoiceItem data = await _invoiceItemRepository.GetByIdAsync(w => w.InvoiceItemId == request.InvoiceItemId, cancellationToken);

                if (data == null)
                {
                    return new(status: OperationResult.Error, messages: "Kayıt Bulunamadı.", null);
                }
                var UserId = _userManager.UserInfo().UserId;
                data.UpdUser = UserId;
                data.UpdTime = DateTime.Now;
                _mapper.Map(request, data);
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
