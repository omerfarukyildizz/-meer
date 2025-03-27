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
using Pbk.Core.Features.EndPoints.Remove;
using Pbk.Core.Features.Users;
namespace Pbk.Core.Features.EndPoints.Remove
{
 

    internal sealed class EndPointRemoveCommandHandler : IRequestHandler<EndPointRemoveCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly IEndPointRepository _endPointRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;

        public EndPointRemoveCommandHandler(ITranslate tanslate, IMapper mapper, IEndPointRepository endPointRepository, IUnitOfWork unitOfWork, IUserManager userManager)
        {
            _tanslate = tanslate;
            _endPointRepository = endPointRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<APIResponse> Handle(EndPointRemoveCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var data =  _endPointRepository.GetWhere(w => w.PointId == request.PointId).FirstOrDefault();
                if (!_userManager.isPermesion("EndPoints", "Remove", data.DepartmentId))
                {
                    return new(status: OperationResult.Error, messages: "Yetkiniz Yok.", null);
                }

                if (data == null)
                {
                    return new(status: OperationResult.Error, messages: "Kayıt bulunamadı", null);
                }
                var user = _userManager.UserInfo().UserId;
                data.IsPassive = true;
                data.UpdTime = DateTime.Now;
                data.UpdUser = user;
                _endPointRepository.Update(data);
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
