using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Pbk.DataAccess.Context;
using Pbk.Entities.Abstractions;
using Pbk.Entities.Models;
using Pbk.Entities.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Pbk.DataAccess.Services;
internal sealed class JwtProvider : IJwtProvider
{
    private readonly ApplicationDbContext _context;
    private readonly Jwt _jwt;
    public JwtProvider(ApplicationDbContext context, IOptions<Jwt> jwt)
    {
        _context = context;
        _jwt = jwt.Value;
    }

    public async Task<string> CreateTokenAsync(User user)
    {

        //new Claim("roleId",  user.RoleId.ToString()),
        //new Claim("languageId",  user.LanguageId.ToString()),
        //new Claim("UTCOffset",  user.UTCOffset.ToString()),


        Claim[] claims = new Claim[]
        {
             new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
             new Claim("firs_name", user.UserName ?? ""),
             new Claim("nameLastname", user.UserName ?? ""),
             new Claim("email",  user.Email ?? ""),
             new Claim("departmentId",  user.DepartmentId.ToString() ?? "NULL"),
             new Claim("phone",  user.Phone ?? ""),
         };

        JwtSecurityToken securityToken = new(
            issuer: _jwt.Issuer,
            audience: _jwt.Audience,
            claims: claims,
            notBefore: DateTime.Now,
            expires: DateTime.Now.AddDays(12220),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.SecretKey)), SecurityAlgorithms.HmacSha512Signature));


        JwtSecurityTokenHandler handler = new();
        string token = handler.WriteToken(securityToken);

        return token;
    }
}
