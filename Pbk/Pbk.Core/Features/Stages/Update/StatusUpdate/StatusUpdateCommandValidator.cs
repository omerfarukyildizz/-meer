using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Stages.Update.StatusUpdate
{
    public sealed class StatusUpdateCommandValidator : AbstractValidator<StatusUpdateCommand>
    {
        public StatusUpdateCommandValidator()
        {
            RuleFor(a => a.StageId)
              .NotEmpty().WithMessage("StageId boş olamaz.")
              .GreaterThan(0).WithMessage("StageId'si 0'dan büyük olmalıdır.");
            RuleFor(a => a.statusTypeId)
            .NotEmpty().WithMessage("statusTypeId boş olamaz.")
            .GreaterThan(0).WithMessage("status type seçiniz.");

        }
    }
}
