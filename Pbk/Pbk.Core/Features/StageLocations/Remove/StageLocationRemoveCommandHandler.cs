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
using Pbk.Core.Features.StageLocations.Remove;
namespace Pbk.Core.Features.StageLocations.Remove
{
 

    internal sealed class StageLocationRemoveCommandHandler : IRequestHandler<StageLocationRemoveCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly IStageLocationRepository _stageLocationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public StageLocationRemoveCommandHandler(ITranslate tanslate, IMapper mapper, IStageLocationRepository stageLocationRepository, IUnitOfWork unitOfWork)
        {
            _tanslate = tanslate;
            _stageLocationRepository = stageLocationRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<APIResponse> Handle(StageLocationRemoveCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var data =  _stageLocationRepository.GetWhere(w => w.StageLocationId == request.StageLocationId).FirstOrDefault();
                if (data == null)
                {
                    return new(status: OperationResult.Error, messages: "Kayıt bulunamadı", null);
                }

                _stageLocationRepository.Remove(data);
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
