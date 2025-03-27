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
using Pbk.Core.Features.Customers.Remove;
using Pbk.Core.Features.Users;
namespace Pbk.Core.Features.Customers.Remove
{
 

    internal sealed class CustomerRemoveCommandHandler : IRequestHandler<CustomerRemoveCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;
        public CustomerRemoveCommandHandler(ITranslate tanslate, IMapper mapper, ICustomerRepository customerRepository, IUnitOfWork unitOfWork, IUserManager userManager)
        {
            _tanslate = tanslate;
            _customerRepository = customerRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<APIResponse> Handle(CustomerRemoveCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var data =  _customerRepository.GetWhere(w => w.CustomerId == request.CustomerId).FirstOrDefault();
                if (data == null)
                {
                    return new(status: OperationResult.Error, messages: "Kayıt bulunamadı", null);
                }

                var user = _userManager.UserInfo().UserId;
                data.UpdTime = DateTime.Now;
                data.UpdUser = user;
                _customerRepository.Update(data);
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
