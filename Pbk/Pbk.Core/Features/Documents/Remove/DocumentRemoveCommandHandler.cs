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
using Pbk.Core.Features.Documents.Remove;
using Pbk.Core.Features.Users;
namespace Pbk.Core.Features.Documents.Remove
{
 

    internal sealed class DocumentRemoveCommandHandler : IRequestHandler<DocumentRemoveCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly IDocumentRepository _documentRepository;
        private readonly IUnitOfWork _unitOfWork; 
        public DocumentRemoveCommandHandler(ITranslate tanslate, IMapper mapper, IDocumentRepository documentRepository, IUnitOfWork unitOfWork)
        {
            _tanslate = tanslate;
            _documentRepository = documentRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork; 
        }

        public async Task<APIResponse> Handle(DocumentRemoveCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var data =  _documentRepository.GetWhere(w => w.DocumentId == request.DocumentId).FirstOrDefault();
                if (data == null)
                {
                    return new(status: OperationResult.Error, messages: "Kayıt bulunamadı", null);
                }
                 
                _documentRepository.Remove(data);
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
