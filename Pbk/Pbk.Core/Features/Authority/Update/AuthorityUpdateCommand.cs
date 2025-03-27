using Pbk.Core.Features.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Authority.Update
{ 
    public sealed record AuthorityUpdateCommand
( 
       int AuthorityID,
     string Category ,
     string PageName ,
     string PermissionType ,
     bool HasPermission
  ) : IRequest<APIResponse>;


}
