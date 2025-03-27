using Pbk.Core.Features.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Documents.Update
{ 
    public sealed record DocumentUpdateCommand
(
        int DocumentId,
      string DocumentType,

     string? FilePath,

     string FileName,

     string? ArchiveType
  ) : IRequest<APIResponse>;


}
