using MediatR;
using Pbk.Entities.Models;

namespace Pbk.Entities.Events.Users;
public sealed class UserDomainEvent : INotification
{
    public AppUser AppUser { get; }

    public UserDomainEvent(AppUser appUser)
    {
        AppUser = appUser;
    }
}
