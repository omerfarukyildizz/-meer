using AutoMapper;
using Pbk.Core.Features.Locations.Create;
using Pbk.Core.Features.User;
using Pbk.Core.Features.Response;
using Pbk.Core.Utilities.IResults;
using Pbk.Entities.Repositories;
using MediatR;
using Pbk.Core.Features.Users;
using System.Drawing.Printing;
namespace Pbk.Core.Features.ExpenseCodes.Create
{
    internal sealed class ExpenseCodeCreateCommandHandler : IRequestHandler<ExpenseCodeCreateCommand, APIResponse>
    {
        private readonly ITranslate _tanslate;
        private readonly IExpenseCodeRepository _expenseCodeRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;

        public ExpenseCodeCreateCommandHandler(IUserManager userManager, ITranslate tanslate, IMapper mapper, ILocationRepository locationRepository, IUnitOfWork unitOfWork, IExpenseCodeRepository expenseCodeRepository)
        {
            _tanslate = tanslate;
            _mapper = mapper;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _expenseCodeRepository = expenseCodeRepository;
        }

        public async Task<APIResponse> Handle(ExpenseCodeCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var UserId = _userManager.UserInfo().UserId;

                Entities.Models.ExpenseCode data = _mapper.Map<Entities.Models.ExpenseCode>(request);
                data.InsUser = UserId;
                data.InsTime = DateTime.Now;

                await _expenseCodeRepository.AddAsync(data, cancellationToken);
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
