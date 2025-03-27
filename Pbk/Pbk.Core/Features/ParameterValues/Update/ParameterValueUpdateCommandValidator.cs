using Pbk.Core.Features.ParameterValues.Update;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.ParameterValues.Update
{
 
    public sealed class ParameterValueUpdateCommandValidator : AbstractValidator<ParameterValueUpdateCommand>
    {
        public ParameterValueUpdateCommandValidator()
        {
            RuleFor(a => a.ParameterValueId)
              .NotEmpty().WithMessage("ParameterValueId is required.")
              .GreaterThan(0).WithMessage("ParameterValueId must be greater than 0.");

            RuleFor(x => x.ParameterId)
               .GreaterThan(0).WithMessage("Parametre ID'si 0'dan büyük olmalıdır.");

            RuleFor(x => x.Code)
                .MaximumLength(50).WithMessage("Kod en fazla 50 karakter olmalıdır.")
                .When(x => !string.IsNullOrEmpty(x.Code));

            RuleFor(x => x.CustomField1)
                .MaximumLength(255).WithMessage("Özel Alan 1 en fazla 255 karakter olmalıdır.")
                .When(x => !string.IsNullOrEmpty(x.CustomField1));

            RuleFor(x => x.CustomField2)
                .MaximumLength(255).WithMessage("Özel Alan 2 en fazla 255 karakter olmalıdır.")
                .When(x => !string.IsNullOrEmpty(x.CustomField2));

            RuleFor(x => x.CustomField3)
                .MaximumLength(255).WithMessage("Özel Alan 3 en fazla 255 karakter olmalıdır.")
                .When(x => !string.IsNullOrEmpty(x.CustomField3));

            RuleFor(x => x.CustomField4)
                .MaximumLength(255).WithMessage("Özel Alan 4 en fazla 255 karakter olmalıdır.")
                .When(x => !string.IsNullOrEmpty(x.CustomField4));

            RuleFor(x => x.CustomField5)
                .MaximumLength(255).WithMessage("Özel Alan 5 en fazla 255 karakter olmalıdır.")
                .When(x => !string.IsNullOrEmpty(x.CustomField5));

        }
    }
}
