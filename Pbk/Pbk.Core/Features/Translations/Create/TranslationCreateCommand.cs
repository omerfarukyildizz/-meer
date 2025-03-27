using Pbk.Core.Features.Response;
using MediatR;

namespace Pbk.Core.Features.Translations.Create
{
       public sealed record TranslationCreateCommand
(
        int LanguageId,

     int ServiceId,

     string TranslateKey,

     string TranslateValue,

     bool? IsActive

) : IRequest<APIResponse>;


}
