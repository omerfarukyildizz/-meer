using Pbk.Core.Utilities.Hashing;
using Pbk.Entities.Abstractions;
using Pbk.Entities.Models;
using Pbk.Entities.Repositories;
using MediatR;

namespace Pbk.Core.Features.Auth.Login;
internal sealed class ProfileCommandHandler : IRequestHandler<LoginCommand, LoginCommandResponse>
{

    private readonly IJwtProvider _jwtProvider;
    private readonly IUserDBRepository _userDBRepository;

    public ProfileCommandHandler(IJwtProvider jwtProvider, IUserDBRepository userDBRepository)
    {
        _jwtProvider = jwtProvider;
        _userDBRepository = userDBRepository;
    }

    public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {

        Entities.Models.User appUser = _userDBRepository.GetWhere(u => u.Email == request.Email).SingleOrDefault();

        if (appUser is null)
        {
            throw new ArgumentException("Kullanıcı bulunamadı!");
        }

        if (appUser.Password != request.Password)
        {
            throw new ArgumentException("Geçersiz kullanıcı bilgileri!");
        }
        if (appUser.IsPassive == false)
        {
            throw new ArgumentException(("Hesabınız aktif değil. Lütfen BT Yöneticisiyle iletişime geçin. (itdestek@barsan.com)"));
        }

        string token = await _jwtProvider.CreateTokenAsync(appUser);
        return new(token: token, null, "", "");
    }
}
