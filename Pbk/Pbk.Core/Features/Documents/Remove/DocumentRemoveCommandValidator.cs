using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Documents.Remove
{
 
    public sealed class DocumentRemoveCommandValidator : AbstractValidator<DocumentRemoveCommand>
    {
        public DocumentRemoveCommandValidator()
        {

            RuleFor(a => a.DocumentId)
                .NotEmpty().WithMessage("DocumentId is required.")
                .GreaterThan(0).WithMessage("DocumentId must be greater than 0.");
  
        }
    }
}
