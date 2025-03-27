using AutoMapper;
using Pbk.Core.Features.InvoiceItems.Create;
using Pbk.Core.Features.User;
using Pbk.Core.Features.Response;
using Pbk.Core.Utilities.IResults;
using Pbk.Entities.Repositories;
using MediatR;
using Pbk.Core.Features.Users;
namespace Pbk.Core.Features.InvoiceItems.Create
{
    internal sealed class InvoiceItemCreateCommandHandler : IRequestHandler<InvoiceItemCreateCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly IInvoiceItemRepository _invoiceItemRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;

        public InvoiceItemCreateCommandHandler(IUserManager userManager, ITranslate tanslate, IMapper mapper, IInvoiceItemRepository invoiceItemRepository, IUnitOfWork unitOfWork)
        {
            _tanslate = tanslate;
            _invoiceItemRepository = invoiceItemRepository;
            _mapper = mapper;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<APIResponse> Handle(InvoiceItemCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var UserId = _userManager.UserInfo().UserId;

                Entities.Models.InvoiceItem data = _mapper.Map<Entities.Models.InvoiceItem>(request);
                data.InsUser = UserId;
                data.InsTime = DateTime.Now;
                data.IsPassive = false;

                await _invoiceItemRepository.AddAsync(data, cancellationToken);
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
