using Pbk.Core.Features.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Account.Update
{ 
     public sealed record UserUpdateCommand
(
     int UserId ,
     int DepartmentId , 
     string UserName , 
     string Password , 
     string? Position ,
     string? Email ,
     string? Phone , 
     int RoleId 
  ) : IRequest<APIResponse>;


}
