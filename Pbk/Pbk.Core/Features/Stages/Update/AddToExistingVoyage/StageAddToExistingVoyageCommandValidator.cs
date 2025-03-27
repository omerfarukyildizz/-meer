using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Stages.Update.AddToExistingVoyage
{
public class StageAddToExistingVoyageCommandValidator : AbstractValidator<StageAddToExistingVoyageCommand>
    {
        public StageAddToExistingVoyageCommandValidator()
        {
            RuleFor(x => x.StageIds)
                .NotEmpty().WithMessage("Stage must not be empty.")
                .Must(ids => ids.All(id => id > 0))
                .WithMessage("All StageId values must be positive integers.");

            RuleFor(x => x.VoyageId)
                .GreaterThan(0).WithMessage("Voyage must be a positive integer.");
            RuleFor(x => x.departmentId)
            .GreaterThan(0).WithMessage("Department must be a positive integer.");
            
        }
    }

}
