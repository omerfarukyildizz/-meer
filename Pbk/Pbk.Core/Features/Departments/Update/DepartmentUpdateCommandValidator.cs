using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Departments.Update
{
 
    public sealed class DepartmentUpdateCommandValidator : AbstractValidator<DepartmentUpdateCommand>
    {
        public DepartmentUpdateCommandValidator()
        {
            RuleFor(a => a.DepartmentId)
              .NotEmpty().WithMessage("DepartmentId is required.")
              .GreaterThan(0).WithMessage("DepartmentId must be greater than 0.");

            RuleFor(x => x.Code)
          .NotEmpty().WithMessage("Kod boş olamaz.")
          .Length(1, 3).WithMessage("Kod en fazla 3 karakter olmalıdır.");

            RuleFor(x => x.DepartmentName)
                .NotEmpty().WithMessage("Departman adı boş olamaz.")
                .MaximumLength(50).WithMessage("Departman adı en fazla 50 karakter olmalıdır.");

            RuleFor(x => x.InvoiceCurrency)
                .MaximumLength(3).WithMessage("Fatura para birimi en fazla 3 karakter olmalıdır.")
                .When(x => !string.IsNullOrEmpty(x.InvoiceCurrency));

            RuleFor(x => x.CommercialAccount)
                .MaximumLength(14).WithMessage("Ticari hesap en fazla 14 karakter olmalıdır.")
                .When(x => !string.IsNullOrEmpty(x.CommercialAccount));

            RuleFor(x => x.BlockedAccount)
                .MaximumLength(14).WithMessage("Bloke hesap en fazla 14 karakter olmalıdır.")
                .When(x => !string.IsNullOrEmpty(x.BlockedAccount));

            RuleFor(x => x.OverdraftAccount)
                .MaximumLength(14).WithMessage("Açık hesap en fazla 14 karakter olmalıdır.")
                .When(x => !string.IsNullOrEmpty(x.OverdraftAccount));

            RuleFor(x => x.Director)
                .MaximumLength(50).WithMessage("Yönetici adı en fazla 50 karakter olmalıdır.")
                .When(x => !string.IsNullOrEmpty(x.Director));

            RuleFor(x => x.DirectorEmail)
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi girin.")
                .MaximumLength(50).WithMessage("Yönetici e-posta en fazla 50 karakter olmalıdır.")
                .When(x => !string.IsNullOrEmpty(x.DirectorEmail));

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi girin.")
                .MaximumLength(50).WithMessage("E-posta en fazla 50 karakter olmalıdır.")
                .When(x => !string.IsNullOrEmpty(x.Email));

            RuleFor(x => x.Address)
                .MaximumLength(255).WithMessage("Adres en fazla 255 karakter olmalıdır.")
                .When(x => !string.IsNullOrEmpty(x.Address));

            RuleFor(x => x.PostalCode)
                .MaximumLength(15).WithMessage("Posta kodu en fazla 15 karakter olmalıdır.")
                .When(x => !string.IsNullOrEmpty(x.PostalCode));

            RuleFor(x => x.SAPCompanyCode)
                .MaximumLength(10).WithMessage("SAP Şirket Kodu en fazla 10 karakter olmalıdır.")
                .When(x => !string.IsNullOrEmpty(x.SAPCompanyCode));

            RuleFor(x => x.YdInvoicePrefix)
                .MaximumLength(50).WithMessage("YD Fatura Ön Eki en fazla 50 karakter olmalıdır.")
                .When(x => !string.IsNullOrEmpty(x.YdInvoicePrefix));

            RuleFor(x => x.Phone)
                .MaximumLength(20).WithMessage("Telefon numarası en fazla 20 karakter olmalıdır.")
                .When(x => !string.IsNullOrEmpty(x.Phone));


        }
    }
}
