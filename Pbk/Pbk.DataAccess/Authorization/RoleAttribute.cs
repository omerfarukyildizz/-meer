using Pbk.Core.Utilities.Roles;
using Pbk.Entities.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Security.Claims;

public sealed class RoleAttribute : Attribute, IAuthorizationFilter
{
    private readonly int[] _perms;

    public RoleAttribute(int[] perms)
    {
        _perms = perms;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {

        var userIdClaim = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim is null)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        var authorityRepository = context.HttpContext.RequestServices.GetService(typeof(IAuthorityRepository)) as IAuthorityRepository;
        if (authorityRepository == null)
        {
            context.Result = new StatusCodeResult(500);
            return;
        }

        var userHasRole = authorityRepository
            .GetWhere(p =>
                p.UserID.ToString() == userIdClaim.Value &&
               _perms.Contains(p.PagePermissionId))
               .Any();

        if (!userHasRole)
        {
            context.Result = new ForbidResult();
        }
    }
}
