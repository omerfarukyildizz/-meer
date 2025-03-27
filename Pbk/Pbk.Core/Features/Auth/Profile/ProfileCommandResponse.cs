namespace Pbk.Core.Features.Auth.Login;

public sealed record ProfileCommandResponse(
    string fullName,
    string lastName,
    string email,
    string phoneNumber,
    string avatar,
    string languageCode,
    bool isActive,
    bool isLoggedIn,
    bool isMobileAuthentication,
    string departman,
   
    int UserId);