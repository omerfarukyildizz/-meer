using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Translations.Remove
{
 
    public sealed class TranslationRemoveCommandValidator : AbstractValidator<TranslationRemoveCommand>
    {
        public TranslationRemoveCommandValidator()
        {

            RuleFor(a => a.TranslateId)
                .NotEmpty().WithMessage("TranslateId ocationId is required.")
                .GreaterThan(0).WithMessage("TranslateId cationId must be greater than 0.");
  
        }
    }
}
