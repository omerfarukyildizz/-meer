using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Customers.Create
{
 
    public sealed class CustomerCreateCommandValidator : AbstractValidator<CustomerCreateCommand>
    {
        public CustomerCreateCommandValidator()
        {

            RuleFor(x => x.DepartmentId)
                .NotEmpty().NotNull().WithMessage("Departman boş olamaz.");
               

            RuleFor(x => x.CustomerName)
                .NotEmpty().WithMessage("İsim boş olamaz.")
                .MaximumLength(255).WithMessage("İsim en fazla 255 karakter olmalıdır.");


            RuleFor(x => x.PostalCode)
                .MaximumLength(10).WithMessage("Posta kodu en fazla 10 karakter olmalıdır.")
                .When(x => !string.IsNullOrEmpty(x.PostalCode));

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi girin.")
                .When(x => !string.IsNullOrEmpty(x.Email));

            RuleFor(x => x.Phone)
                .MaximumLength(15).WithMessage("Telefon numarası en fazla 15 karakter olmalıdır.")
                .When(x => !string.IsNullOrEmpty(x.Phone));

            RuleFor(x => x.Fax)
                .MaximumLength(15).WithMessage("Faks numarası en fazla 15 karakter olmalıdır.")
                .When(x => !string.IsNullOrEmpty(x.Fax));
             

            RuleFor(x => x.SAPCompanyCode)
                .MaximumLength(10).WithMessage("SAP Şirket Kodu en fazla 10 karakter olmalıdır.")
                .When(x => !string.IsNullOrEmpty(x.SAPCompanyCode));


            RuleFor(x => x.VATRate)
                .InclusiveBetween(0, 100).WithMessage("KDV oranı 0 ile 100 arasında olmalıdır.")
                .When(x => x.VATRate.HasValue);

            RuleFor(x => x.Freight)
                .GreaterThan(0).WithMessage("Nakliye tutarı 0'dan büyük olmalıdır.")
                .When(x => x.Freight.HasValue);
             

            RuleFor(x => x.InvoiceEmail)
                .EmailAddress().WithMessage("Geçerli bir fatura e-postası girin.")
                .When(x => !string.IsNullOrEmpty(x.InvoiceEmail));

            RuleFor(x => x.Description)
                .MaximumLength(255).WithMessage("Açıklama en fazla 255 karakter olmalıdır.")
                .When(x => !string.IsNullOrEmpty(x.Description));

        }
    }
}
