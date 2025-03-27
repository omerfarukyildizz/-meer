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
using Pbk.Core.Features.CostItems.Remove;
using Pbk.Core.Features.Users;
using Pbk.Entities.Models2;
namespace Pbk.Core.Features.CostItems.Remove
{
 

    internal sealed class CostItemRemoveCommandHandler : IRequestHandler<CostItemRemoveCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly ICostItemRepository _costItemRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;

        public CostItemRemoveCommandHandler(ITranslate tanslate, IMapper mapper, ICostItemRepository costItemRepository, IUnitOfWork unitOfWork, IUserManager userManager)
        {
            _tanslate = tanslate;
            _costItemRepository = costItemRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<APIResponse> Handle(CostItemRemoveCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var data =  _costItemRepository.GetWhere(w => w.CostItemId == request.CostItemId).FirstOrDefault();
                if (data == null)
                {
                    return new(status: OperationResult.Error, messages: "Kayıt bulunamadı", null);
                }
                if (!_userManager.isPermesion("CostItems", "Remove", null))
                {
                    return new(status: OperationResult.Error, messages: "Yetkiniz Yok.", null);
                }
                var user = _userManager.UserInfo().UserId;
                data.UpdTime = DateTime.Now;
                data.UpdUser = user;
                data.IsPassive = true;
                _costItemRepository.Update(data);
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
