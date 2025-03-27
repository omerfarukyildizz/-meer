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
namespace Pbk.Core.Features.Departments.Update
{
 
    internal sealed class DepartmentUpdateCommandHandler : IRequestHandler<DepartmentUpdateCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;


        public DepartmentUpdateCommandHandler(IUserManager userManager, ITranslate tanslate, IMapper mapper, IDepartmentRepository departmentRepository, IUnitOfWork unitOfWork)
        {
            _tanslate = tanslate;
            _departmentRepository = departmentRepository;
            _mapper = mapper;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<APIResponse> Handle(DepartmentUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var UserId = _userManager.UserInfo().UserId;

               Entities.Models.Department data = await _departmentRepository.GetByIdAsync(w=> w.DepartmentId == request.DepartmentId && (w.IsPassive==false || w.IsPassive == null), cancellationToken);
                   
                if(data == null)
                {
                    return new(status: OperationResult.Error, messages: "Kayıt Bulunamadı.", null);
                }

                  data.UpdUser = UserId;
                  data.UpdTime = DateTime.Now;
                _mapper.Map(request, data);
                 _departmentRepository.Update(data);
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
