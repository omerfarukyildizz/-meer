using Microsoft.AspNetCore.Identity;

namespace Pbk.Entities.Models;
public sealed class AppUser : IdentityUser<Guid>
{
    public string Name { get; set; }
    public string Lastname { get; set; }
}
