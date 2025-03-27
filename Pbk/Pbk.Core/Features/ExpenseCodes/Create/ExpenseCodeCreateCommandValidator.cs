using Pbk.Core.Features.Invoices.Remove;
using Pbk.Core.Features.Invoices.Update;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.ExpenseCodes.Create
{

    public sealed class ExpenseCodeCreateCommandValidator : AbstractValidator<ExpenseCodeCreateCommand>
    {
        public ExpenseCodeCreateCommandValidator()
        {

           

            // DepartmentId alanı boş olamaz
            RuleFor(x => x.DepartmentId)
                .NotEmpty().WithMessage("DepartmentId alanı zorunludur");

            // ExpenseCodeValue alanı boş olamaz ve maksimum 10 karakter olabilir
            RuleFor(x => x.ExpenseCodeName)
                .NotEmpty().WithMessage("ExpenseCodeName alanı zorunludur")
                .MaximumLength(10).WithMessage("ExpenseCodeName en fazla 10 karakter olabilir");

            // IntegrationCode alanı maksimum 25 karakter olabilir
            RuleFor(x => x.IntegrationCode)
                .MaximumLength(25).WithMessage("IntegrationCode en fazla 25 karakter olabilir");

            // Description alanı maksimum 255 karakter olabilir
            RuleFor(x => x.Description)
                .MaximumLength(255).WithMessage("Description en fazla 255 karakter olabilir");

            // TycoCode alanı maksimum 20 karakter olabilir
            RuleFor(x => x.TycoCode)
                .MaximumLength(20).WithMessage("TycoCode en fazla 20 karakter olabilir");

            // ExpenseFlag alanı maksimum 1 karakter olabilir
            RuleFor(x => x.ExpenseFlag)
                .MaximumLength(1).WithMessage("ExpenseFlag en fazla 1 karakter olabilir");

        }
    }
}
