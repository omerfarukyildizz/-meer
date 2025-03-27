using MediatR;
using Pbk.Entities.Abstractions;
using Pbk.Entities.Repositories;
using System.Security.Cryptography;
using Pbk.Core.Features.User;
using Pbk.Core.Behaviors;

namespace Pbk.Core.Features.Auth.Login;

internal sealed class LoginCommandHandler : IRequestHandler<LoginCommand, LoginCommandResponse>
{
    private readonly IJwtProvider _jwtProvider;
    private readonly IUserDBRepository  _userDBRepository;
    private readonly ITranslate _tanslate;

    public LoginCommandHandler(IJwtProvider jwtProvider, IUserDBRepository userDBRepository, ITranslate tanslate )
    {
        _jwtProvider = jwtProvider;
        _userDBRepository = userDBRepository;
        _tanslate = tanslate;
   
    }

    public string CreateKey(string key)
    {
        try
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var pbkdf2 = new Rfc2898DeriveBytes(key, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] storedPassword = new byte[36];
            Array.Copy(salt, 0, storedPassword, 0, 16);
            Array.Copy(hash, 0, storedPassword, 16, 20);

            return Convert.ToBase64String(storedPassword);
        }
        catch  (Exception ex)
        {
            return null;
        }
    }

    public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        Entities.Models.User appUser = _userDBRepository.GetWhere(u => u.Email == request.Email).FirstOrDefault();

        if (appUser is null)
        {
            throw new ArgumentException( await _tanslate.GetTranslation("Kullanıcı bulunamadı!"));
        }

        Entities.Models.User? domainUser = _userDBRepository.GetWhere(u => u.Email == request.Email && u.Password == request.Password).FirstOrDefault();

        if (domainUser == null)
        {
            if (appUser.Password == request.Password )
            {
                throw new ArgumentException(await _tanslate.GetTranslation("Lütfen Kullanıcı Bilgilerinizi Kontrol Ediniz."));
            }

            if (appUser.IsPassive == false)
            {
                throw new ArgumentException(await _tanslate.GetTranslation("Hesabınız aktif değil. Lütfen BT Yöneticisiyle iletişime geçin. (itdestek@barsan.com)"));
            }
        }

        string token = await _jwtProvider.CreateTokenAsync(appUser);

        LoginCommandResponseData loginCommandResponseData = response(appUser,request);
        var _status = appUser.IsPassive == true ? "success" : "fail";

        return new(token: token, data: loginCommandResponseData, status: _status,"ok");
    }

    public LoginCommandResponseData response(Entities.Models.User appUser, LoginCommand request)
    {
        LoginCommandResponseData loginCommandResponseData = new LoginCommandResponseData();
        loginCommandResponseData.__v = AppHelper.version;
        loginCommandResponseData.phone = appUser.Phone ?? "";
        loginCommandResponseData.designation = $@"EDP {DateTime.Now.Year}";
        loginCommandResponseData.city = "";
        loginCommandResponseData.website ="edp";
        loginCommandResponseData.passwordtoken = CreateKey(appUser.Password.ToString() ?? "");
        loginCommandResponseData.confirm_password = CreateKey(request.Password);
        loginCommandResponseData.changePasswordAt = DateTime.Now;
        loginCommandResponseData.role = "user";
        loginCommandResponseData.first_name = appUser.UserName;
        loginCommandResponseData.last_name = appUser.UserName;
        loginCommandResponseData.email = appUser.Email;
        loginCommandResponseData.skills = new List<string>() { "Dashboard" };
        loginCommandResponseData.Description = "Succes Login app";
        loginCommandResponseData.joining_date = DateTime.Now;
        loginCommandResponseData._id = CreateKey(appUser.UserId.ToString());
        loginCommandResponseData.isForeign = true;
        loginCommandResponseData.userBarsisCode = appUser.UserId.ToString();
        return loginCommandResponseData;
    }
}
