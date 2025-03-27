using Pbk.Entities.Models;


namespace Pbk.Core.Features.Users;

public interface IUserManager
{
    int UserId();
    string FirstName();
    string NameLastname();
    string Email();
    string UTCOffset();
    string DepartmentId();
    string Phone();
    string RoleId();
    string LanguageId();
    long Nbf();
    long Exp();
    string Issuer();
    string Audience();
    string AppVersion();

    /// <summary>
    /// kullanıcı bilgileri 
    /// </summary>
    Pbk.Entities.Models.User? UserInfo();

    /// <summary>
    /// Kullanıcının yetki kontrolü
    /// </summary>
    bool isPermesion( string pageName, string PermissionType,int? departmentId);


    /// <summary>
    /// Kullanıcının yetkili olduğu departmanların kimlik (ID) numaralarını döndüren metod.
    /// </summary>
    List<int> getDepartmans();
    List<int> getDepartmansPagePerms(string pageName, string PermissionType);
    List<int> getAllDepartmans();

}
