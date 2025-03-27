using MediatR;
using Pbk.Entities.Abstractions;
using Pbk.Entities.Models;
using Pbk.Entities.Repositories;
using Pbk.Core.Features.User;
using Pbk.Core.Behaviors;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
namespace Pbk.Core.Features.Auth.Login;

internal sealed class LoginAzureCommandHandler : IRequestHandler<LoginAzureCommand, LoginCommandResponse>
{
    private readonly IJwtProvider _jwtProvider;
    private readonly IUserDBRepository  _userRepository;
    private readonly ITranslate _tanslate;
    private readonly IDepartmentRepository _departmentRepository;

    public LoginAzureCommandHandler(
        IJwtProvider jwtProvider,
        IUserDBRepository userRepository,
        ITranslate tanslate,
        IDepartmentRepository departmentRepository

        )
    {
        _jwtProvider = jwtProvider;
        _userRepository = userRepository;
        _tanslate = tanslate;
        _departmentRepository = departmentRepository;
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
    static string TurkceKarakterleriDuzelt(string metin)
    {
        // Türkçe karakterleri İngilizce karakterlere dönüştür
        metin = metin.Replace("ğ", "g");
        metin = metin.Replace("Ğ", "G");
        metin = metin.Replace("ü", "u");
        metin = metin.Replace("Ü", "U");
        metin = metin.Replace("ş", "s");
        metin = metin.Replace("Ş", "S");
        metin = metin.Replace("ı", "I");
        metin = metin.Replace("İ", "I");
        metin = metin.Replace("i", "I");
        metin = metin.Replace("ö", "o");
        metin = metin.Replace("Ö", "O");
        metin = metin.Replace("ç", "c");
        metin = metin.Replace("Ç", "C");

        return metin;
    }
    public async Task<LoginCommandResponse> Handle(LoginAzureCommand request, CancellationToken cancellationToken)
    {

        var email = AppHelper.getUserEmail(request.Token);
        var nameUser = TurkceKarakterleriDuzelt(email.Split('@')[0].ToUpper());

        if (  string.IsNullOrEmpty( email ))
        {
            throw new ArgumentException(await _tanslate.GetTranslation("Geçersiz E-posta Adresi"));
        }


        Entities.Models.User appUser = _userRepository.GetWhere(w => w.Email == email).FirstOrDefault(); 
        if (appUser is null)
        {
         //GnlKullanici   kulalnici = _gnnlKullaniciRepository.GetWhere(w => w.adusername == nameUser).FirstOrDefault();
         //   if(kulalnici  is not null)
         //   {
         //       appUser = _userRepository.GetWhere(w => w.Kodu == kulalnici.kodu).FirstOrDefault();
         //   }
        }


        if (appUser is null)
        {
            appUser = _userRepository.GetWhere(w => w.Email == email).FirstOrDefault();
            throw new ArgumentException(await _tanslate.GetTranslation("Kullanıcı bulunamadı!"));
        }

        string token = await _jwtProvider.CreateTokenAsync(appUser);
        LoginCommandResponseData loginCommandResponseData = response(appUser,request);
        var _status = appUser?.IsPassive == false ? "success" : "fail";
        return new(token: token, data: loginCommandResponseData, status: _status,"ok");
    }


    public LoginCommandResponseData response(Entities.Models.User appUser, LoginAzureCommand request)
    {

       //var gnlKullanici = _gnnlKullaniciRepository.GetWhere(p => p.kodu == appUser.Kodu)
       //                                                     .Select(p => new { p.departman })
       //                                                     .FirstOrDefault();
       var dep =  _departmentRepository.GetWhere(p => p.DepartmentId == appUser.DepartmentId).Select(w=> w.Code).FirstOrDefault();
        LoginCommandResponseData loginCommandResponseData = new LoginCommandResponseData();
        loginCommandResponseData.__v = AppHelper.version;
        loginCommandResponseData.phone = appUser.Phone ?? "";
        loginCommandResponseData.designation = $@"EDP {DateTime.Now.Year}";
        loginCommandResponseData.city = "";
        loginCommandResponseData.website =  "";
        loginCommandResponseData.passwordtoken = "";
        loginCommandResponseData.confirm_password = CreateKey($"{appUser.Password}-{DateTime.Now}");
        loginCommandResponseData.changePasswordAt = DateTime.Now;
        loginCommandResponseData.role = "user";
        loginCommandResponseData.first_name = appUser.UserName;
        loginCommandResponseData.last_name = appUser.UserName;
        loginCommandResponseData.email = appUser.Email;
        loginCommandResponseData.RoleId = appUser.RoleId;
        loginCommandResponseData.departmentId = appUser.DepartmentId;

        loginCommandResponseData.skills = new List<string>() { "Dashboard" };
        loginCommandResponseData.Description = "Succes Login app";
        loginCommandResponseData.joining_date = DateTime.Now;
        loginCommandResponseData._id = CreateKey(appUser.UserId.ToString());
        loginCommandResponseData.isForeign = true;
        loginCommandResponseData.departman = dep;
        loginCommandResponseData.userBarsisCode = appUser.UserId.ToString();
        return loginCommandResponseData;
    }

}



 