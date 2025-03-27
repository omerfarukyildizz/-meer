using Pbk.Entities.Models;

namespace Pbk.Entities.Abstractions;
public interface IJwtProvider
{
    Task<string> CreateTokenAsync(User user);
}
