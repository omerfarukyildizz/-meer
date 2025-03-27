using Pbk.Core.Features.Invoices.Remove;
using Pbk.Core.Features.Invoices.Update;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Parameters.Create
{

    public sealed class ParameterCreateCommandValidator : AbstractValidator<ParameterCreateCommand>
    {
        public ParameterCreateCommandValidator()
        {

            RuleFor(x => x.CategoryName)
             .NotEmpty().WithMessage("Kategori boş olamaz.")
             .MaximumLength(50).WithMessage("Kategori en fazla 50 karakter olmalıdır.");

            RuleFor(x => x.ParameterName)
                .NotEmpty().WithMessage("İsim boş olamaz.")
                .MaximumLength(50).WithMessage("İsim en fazla 50 karakter olmalıdır.");

            RuleFor(x => x.Description)
                .MaximumLength(255).WithMessage("Açıklama en fazla 255 karakter olmalıdır.")
                .When(x => !string.IsNullOrEmpty(x.Description));

            
        }
    }
}
