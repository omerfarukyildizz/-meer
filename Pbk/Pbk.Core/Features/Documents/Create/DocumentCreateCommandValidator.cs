using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Documents.Create
{
 
    public sealed class DocumentCreateCommandValidator : AbstractValidator<DocumentCreateCommand>
    {
        public DocumentCreateCommandValidator()
        {
            RuleFor(x => x.DocumentType)
           .NotEmpty().WithMessage("Belge türü boş olamaz.")
           .MaximumLength(50).WithMessage("Belge türü en fazla 50 karakter olmalıdır.");

            RuleFor(x => x.FilePath)
                .MaximumLength(1000).WithMessage("Dosya yolu en fazla 1000 karakter olmalıdır.")
                .When(x => !string.IsNullOrEmpty(x.FilePath));

            RuleFor(x => x.FileName)
                .NotEmpty().WithMessage("Dosya adı boş olamaz.")
                .MaximumLength(50).WithMessage("Dosya adı en fazla 50 karakter olmalıdır.");

            RuleFor(x => x.ArchiveType)
                .MaximumLength(50).WithMessage("Arşiv türü en fazla 50 karakter olmalıdır.")
                .When(x => !string.IsNullOrEmpty(x.ArchiveType));


        }
    }
}
