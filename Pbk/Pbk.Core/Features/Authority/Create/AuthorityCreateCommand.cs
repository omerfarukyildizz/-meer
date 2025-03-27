using Pbk.Core.Features.Response;
using MediatR;
 
namespace Pbk.Core.Features.Authority.Create
{
    public sealed record AuthorityCreateCommand
(

     int UserID,
     int DepartmentId,
     int PageId,
     int  PagePermissionId,
     bool HasPermission
  ) : IRequest<APIResponse>;


}
