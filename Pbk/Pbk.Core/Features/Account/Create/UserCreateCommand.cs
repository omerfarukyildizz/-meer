using Pbk.Core.Features.Response;
using MediatR;

namespace Pbk.Core.Features.Account.Create
{
      public sealed record UserCreateCommand
( 
     int DepartmentId,   
     string UserName , 
     string Password , 
     string? Position ,
     string? Email ,
     string? Phone , 
     int BarsisUserId,
     int RoleId

  ) : IRequest<APIResponse>;


}
