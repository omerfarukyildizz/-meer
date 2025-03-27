using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Drivers.Update
{
 
    public sealed class DriverUpdateCommandValidator : AbstractValidator<DriverUpdateCommand>
    {
        public DriverUpdateCommandValidator()
        {
            RuleFor(a => a.DriverId)
              .NotEmpty().WithMessage("DepartmentId is required.")
              .GreaterThan(0).WithMessage("DepartmentId must be greater than 0.");

            RuleFor(x => x.DriverName)
            .NotEmpty().WithMessage("Sürücü adı boş olamaz.")
            .MaximumLength(50).WithMessage("Sürücü adı en fazla 50 karakter olmalıdır.");

            RuleFor(x => x.DepartmentId)
                .GreaterThan(0).WithMessage("Departman ID'si 0'dan büyük olmalıdır.");

            RuleFor(x => x.EdiCode)
                .MaximumLength(1).WithMessage("Edi Kodu en fazla 1 karakter olmalıdır.")
                .When(x => !string.IsNullOrEmpty(x.EdiCode));

            RuleFor(x => x.IntegratedAccountCode)
                .NotEmpty().WithMessage("Entegre hesap kodu boş olamaz.")
                .MaximumLength(10).WithMessage("Entegre hesap kodu en fazla 10 karakter olmalıdır.");
             
        }
    }
}
