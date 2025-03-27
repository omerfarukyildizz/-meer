using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Shipments.Update
{
 
    public sealed class ShipmentUpdateCommandValidator : AbstractValidator<ShipmentUpdateCommand>
    {
        public ShipmentUpdateCommandValidator()
        {
            RuleFor(a => a.ShipmentId).NotEmpty().WithMessage("ShipmentId is required.");

            RuleFor(x => x.DepartmentId).NotNull().WithMessage("DepartmentId cannot be null.");
            RuleFor(x => x.StatusTypeId).NotNull().WithMessage("StatusTypeId cannot be null.");
            RuleFor(x => x.ShipmentTypeId).NotNull().WithMessage("ShipmentTypeId cannot be null.");
            RuleFor(x => x.SectorId).NotNull().WithMessage("SectorId cannot be null.");
            RuleFor(x => x.Year).NotNull().WithMessage("Year cannot be null.");
            RuleFor(x => x.SenderId).NotNull().WithMessage("SenderId cannot be null.");
            RuleFor(x => x.ReceiverId).NotNull().WithMessage("ReceiverId cannot be null.");
            RuleFor(x => x.LoadingTime).NotNull().WithMessage("LoadingTime cannot be null.");
            RuleFor(x => x.UnloadingTime).NotNull().WithMessage("UnloadingTime cannot be null.");
            RuleFor(x => x.CurrencyId).NotNull().WithMessage("CurrencyId cannot be null.");
            RuleFor(x => x.VATRate).NotNull().WithMessage("VATRate cannot be null.");

            // Optional string length checks
            RuleFor(x => x.LoadingDescription).MaximumLength(255).WithMessage("LoadingDescription cannot exceed 255 characters.");
            RuleFor(x => x.FreightPaymentType).MaximumLength(20).WithMessage("FreightPaymentType cannot exceed 20 characters.");
            RuleFor(x => x.ReferenceNo).MaximumLength(50).WithMessage("ReferenceNo cannot exceed 50 characters.");
            RuleFor(x => x.WarehouseCode).MaximumLength(20).WithMessage("WarehouseCode cannot exceed 20 characters.");
            RuleFor(x => x.SenderWarehouseCode).MaximumLength(50).WithMessage("SenderWarehouseCode cannot exceed 50 characters.");
            RuleFor(x => x.ReceiverWarehouseCode).MaximumLength(50).WithMessage("ReceiverWarehouseCode cannot exceed 50 characters.");
            RuleFor(x => x.WarehouseHub).MaximumLength(50).WithMessage("WarehouseHub cannot exceed 50 characters.");
            RuleFor(x => x.ReferenceShip).MaximumLength(50).WithMessage("ReferenceShip cannot exceed 50 characters.");
            RuleFor(x => x.Art).MaximumLength(50).WithMessage("Art cannot exceed 50 characters.");
            RuleFor(x => x.OrderType).MaximumLength(50).WithMessage("OrderType cannot exceed 50 characters.");
            RuleFor(x => x.DeliveryType).MaximumLength(50).WithMessage("DeliveryType cannot exceed 50 characters.");
            RuleFor(x => x.ReferenceNoc).MaximumLength(50).WithMessage("ReferenceNoc cannot exceed 50 characters.");
            RuleFor(x => x.UnloadingType).MaximumLength(50).WithMessage("UnloadingType cannot exceed 50 characters.");
            RuleFor(x => x.ValueOfGoods).MaximumLength(50).WithMessage("ValueOfGoods cannot exceed 50 characters.");
            RuleFor(x => x.CustomerReference).MaximumLength(50).WithMessage("CustomerReference cannot exceed 50 characters.");
            RuleFor(x => x.PublicText).MaximumLength(250).WithMessage("PublicText cannot exceed 250 characters.");
            RuleFor(x => x.InternalText).MaximumLength(250).WithMessage("InternalText cannot exceed 250 characters.");
            RuleFor(x => x.ConsignmentNumber).MaximumLength(50).WithMessage("ConsignmentNumber cannot exceed 50 characters.");
            RuleFor(x => x.Type).MaximumLength(50).WithMessage("Type cannot exceed 50 characters.");
            RuleFor(x => x.LoadWithT1Text).MaximumLength(100).WithMessage("LoadWithT1Text cannot exceed 100 characters.");
            RuleFor(x => x.CustomerInfoText).MaximumLength(100).WithMessage("CustomerInfoText cannot exceed 100 characters.");
            RuleFor(x => x.WaybillNumText).MaximumLength(100).WithMessage("WaybillNumText cannot exceed 100 characters.");
            RuleFor(x => x.LoadNotificationText).MaximumLength(100).WithMessage("LoadNotificationText cannot exceed 100 characters.");
            RuleFor(x => x.CustomsInfoText).MaximumLength(100).WithMessage("CustomsInfoText cannot exceed 100 characters.");
            RuleFor(x => x.IncotermNew).MaximumLength(50).WithMessage("IncotermNew cannot exceed 50 characters.");
            RuleFor(x => x.IntegrationFileName).MaximumLength(255).WithMessage("IntegrationFileName cannot exceed 255 characters.");
            RuleFor(x => x.UnloadingDescription).MaximumLength(255).WithMessage("UnloadingDescription cannot exceed 255 characters.");

        }
    }
}
