using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.VtlAdditionals.Update
{
 
    public sealed class VtlAdditionalUpdateCommandValidator : AbstractValidator<VtlAdditionalUpdateCommand>
    {
        public VtlAdditionalUpdateCommandValidator()
        {
            RuleFor(a => a.ShipmentId)
              .NotEmpty().WithMessage("ShipmentId is required.")
              .GreaterThan(0).WithMessage("ShipmentId must be greater than 0.");

            RuleFor(x => x.Flammable)
              .NotNull().WithMessage("Yanıcı durumu boş olamaz.");

            RuleFor(x => x.Frangible)
                .NotNull().WithMessage("Kırılgan durumu boş olamaz.");

            RuleFor(x => x.CustomerSign)
                .NotNull().WithMessage("Müşteri imzası boş olamaz.");

            RuleFor(x => x.Unstackable)
                .NotNull().WithMessage("İstiflenemez durumu boş olamaz.");

            RuleFor(x => x.OnlyHorizontal)
                .NotNull().WithMessage("Sadece yatay durumu boş olamaz.");

            RuleFor(x => x.OnlyVertical)
                .NotNull().WithMessage("Sadece dikey durumu boş olamaz.");

            RuleFor(x => x.WaybillInLoad)
                .NotNull().WithMessage("Yükte irsaliye durumu boş olamaz.");

            RuleFor(x => x.Routed)
                .NotNull().WithMessage("Rota bilgisi boş olamaz.");

            RuleFor(x => x.Customs)
                .NotNull().WithMessage("Gümrük durumu boş olamaz.");

            RuleFor(x => x.LoadWithT1)
                .NotNull().WithMessage("T1 ile yük durumu boş olamaz.");

            RuleFor(x => x.ConfirmationRequired)
                .NotNull().WithMessage("Onay gereksinimi boş olamaz.");

            RuleFor(x => x.CustomerInfo)
                .NotNull().WithMessage("Müşteri bilgisi boş olamaz.");

            RuleFor(x => x.Waybill)
                .NotNull().WithMessage("İrsaliye durumu boş olamaz.");

            RuleFor(x => x.LoadNotification)
                .NotNull().WithMessage("Yük bildirim durumu boş olamaz.");

            RuleFor(x => x.CustomsInfo)
                .NotNull().WithMessage("Gümrük bilgisi boş olamaz.");

        }
    }
}
