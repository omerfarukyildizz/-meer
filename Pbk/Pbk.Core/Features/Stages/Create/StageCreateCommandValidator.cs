using Pbk.Core.Features.Invoices.Remove;
using Pbk.Core.Features.Invoices.Update;
using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Stages.Create
{

    public sealed class StageCreateCommandValidator : AbstractValidator<StageCreateCommand>
    {
        public StageCreateCommandValidator()
        {


            RuleFor(x => x.ShipmentId)
                .GreaterThan(0).WithMessage("ShipmentId'si 0'dan büyük olmalıdır.");

            RuleFor(x => x.SourceLocationId)
                .GreaterThan(0).WithMessage("SourceLocationId 0'dan büyük olmalıdır.");

            RuleFor(x => x.TargetLocationId)
                .GreaterThan(0).WithMessage("TargetLocationId 0'dan büyük olmalıdır.");

            RuleFor(x => x.LoadingTime)
                .NotEmpty().WithMessage("LoadingTime boş olamaz.");

            RuleFor(x => x.UnloadingTime)
                .NotEmpty().WithMessage("UnloadingTime boş olamaz.")
                .GreaterThanOrEqualTo(x => x.LoadingTime).WithMessage("Boşaltma zamanı yükleme zamanından önce olamaz.");
             
        }
    }
}
