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
namespace Pbk.Core.Features.CostItems.Update
{
 
    internal sealed class CostItemUpdateCommandHandler : IRequestHandler<CostItemUpdateCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly ICostItemRepository _costItemRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;


        public CostItemUpdateCommandHandler(IUserManager userManager, ITranslate tanslate, IMapper mapper, ICostItemRepository costItemRepository, IUnitOfWork unitOfWork)
        {
            _tanslate = tanslate;
            _costItemRepository = costItemRepository;
            _mapper = mapper;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<APIResponse> Handle(CostItemUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var UserId = _userManager.UserInfo().UserId;

               Entities.Models.CostItem data = await _costItemRepository.GetByIdAsync(w=> w.CostItemId == request.CostItemId, cancellationToken);
                   
                if(data == null)
                {
                    return new(status: OperationResult.Error, messages: "Kayıt Bulunamadı.", null);
                }
                if (!_userManager.isPermesion("CostItems", "Edit", request.DepartmentId))
                {
                    return new(status: OperationResult.Error, messages: "Yetkiniz Yok.", null);
                }
                data.UpdUser = UserId;
                  data.UpdTime = DateTime.Now;
                _mapper.Map(request, data);
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
