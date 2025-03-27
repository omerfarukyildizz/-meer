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
namespace Pbk.Core.Features.Stages.Update
{
 
    internal sealed class StageUpdateCommandHandler : IRequestHandler<StageUpdateCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly IStageRepository _stageRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;


        public StageUpdateCommandHandler(IUserManager userManager, ITranslate tanslate, IMapper mapper, IStageRepository stageRepository, IUnitOfWork unitOfWork)
        {
            _tanslate = tanslate;
            _stageRepository = stageRepository;
            _mapper = mapper;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<APIResponse> Handle(StageUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var UserId = _userManager.UserInfo().UserId;

               Entities.Models.Stage data = await _stageRepository.GetByIdAsync(w=> w.StageId == request.StageId, cancellationToken);
                   
                if(data == null)
                {
                    return new(status: OperationResult.Error, messages: "Kayıt Bulunamadı.", null);
                }

                bool refreshKM = data.SourceLocationId != request.SourceLocationId || data.TargetLocationId != request.TargetLocationId;
                
              
                _mapper.Map(request, data);


             
               
                data.UpdUser = UserId;
                data.UpdTime = DateTime.Now;

                _stageRepository.Update(data);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                if (refreshKM) { 
                    data.StageKM = await _stageRepository.getKm(data.StageId); 
                    _stageRepository.Update(data);
                    await _unitOfWork.SaveChangesAsync(cancellationToken);
                }

    

                return new(status: OperationResult.Success, messages: "", data);
            }
            catch (Exception ex)
            {
                return new(status: OperationResult.Error, messages: ex.Message, null);
            }

        }

    }



}
