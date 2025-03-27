using Pbk.Core.Features.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Translations.Update
{ 
    public sealed record TranslationUpdateCommand
(
        int TranslateId,
    int LanguageId,

     int ServiceId,

     string TranslateKey,

     string TranslateValue,

     bool? IsActive

  ) : IRequest<APIResponse>;


}
