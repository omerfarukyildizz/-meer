using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Parameters.Update
{
 
    public sealed class ParameterUpdateCommandValidator : AbstractValidator<ParameterUpdateCommand>
    {
        public ParameterUpdateCommandValidator()
        {
            RuleFor(a => a.ParameterId)
              .NotEmpty().WithMessage("ParameterId is required.")
              .GreaterThan(0).WithMessage("ParameterId must be greater than 0.");

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
