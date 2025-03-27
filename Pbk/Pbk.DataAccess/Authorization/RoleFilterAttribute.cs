using Microsoft.AspNetCore.Mvc;

namespace Pbk.DataAccess.Authorization;
public sealed class RoleFilterAttribute : TypeFilterAttribute
{
    public RoleFilterAttribute(int[] role) : base(typeof(RoleAttribute))
    {
        Arguments = new object[] { role };
    }
}
