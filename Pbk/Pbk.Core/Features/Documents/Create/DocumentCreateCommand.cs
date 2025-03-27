using Pbk.Core.Features.Response;
using MediatR;

namespace Pbk.Core.Features.Documents.Create
{
      public sealed record DocumentCreateCommand
(
        string DocumentType , 

     string? FilePath ,

     string FileName , 

     string? ArchiveType 
  ) : IRequest<APIResponse>;


}
