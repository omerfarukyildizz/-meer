using AutoMapper;
using Pbk.Core.Features.Departments.Create;
using Pbk.Core.Features.User;
using Pbk.Core.Features.Response;
using Pbk.Core.Utilities.IResults;
using Pbk.Entities.Repositories;
using Pbk.Core.Features.Users.Manager;
using Pbk.Core.Features.Users;
using MediatR;
namespace Pbk.Core.Features.Departments.Create
{
    internal sealed class DepartmentCreateCommandHandler : IRequestHandler<DepartmentCreateCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;

        public DepartmentCreateCommandHandler(IUserManager userManager, ITranslate tanslate, IMapper mapper, IDepartmentRepository departmentRepository, IUnitOfWork unitOfWork)
        {
            _tanslate = tanslate;
            _departmentRepository = departmentRepository;
            _mapper = mapper;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<APIResponse> Handle(DepartmentCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var UserId = _userManager.UserInfo().UserId;


                Entities.Models.Department data = _mapper.Map<Entities.Models.Department>(request);
                data.InsUser = UserId;
                data.InsTime = DateTime.Now;
                data.IsPassive = false;

                await _departmentRepository.AddAsync(data, cancellationToken);
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
