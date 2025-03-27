using Pbk.Core.Features.Response;
using MediatR;

namespace Pbk.Core.Features.VtlAdditionals.Create
{
        public sealed record VtlAdditionalCreateCommand
(

     int? CreatingNo ,

     int? CreatingDetailNo ,

     string? PaletType ,

     string? PlantCode ,

     string? Lkw ,

     bool? Adr ,

     bool? FreePalet ,

     string? CallBeforeLoading ,

     string? CallBeforeLoadingDay ,

     string? CallBeforeUnloading ,

     string? CallDriver ,

     string? DeliveryDelayReport ,

     string? PaymentType ,

     string? Week ,

     string? IncoTerms ,

     string? PaletReference ,

     string? CustomInfo ,

     string? CustomDocNo ,

     string? WaybillNumber ,

     string? CustomerOrderNumber ,

     string? EkaerNo ,

     string? ShipmentWarehouseCode ,

     DateOnly? OrderDate ,

     double? NetWeight ,

     double? EPTotal ,

     double? GPTotal ,

     string? OldStatus ,

     string? NewStatus ,

     string? StatusInfo ,

     bool? CadisBildirildi ,

     DateTime? CadisBildirilmeZamani ,

     bool Flammable ,

     bool Frangible ,

     bool CustomerSign ,

     bool Unstackable ,

     bool OnlyHorizontal ,

     bool OnlyVertical ,

     bool WaybillInLoad ,

     bool Routed ,

     bool Customs ,

     bool LoadWithT1 ,

     bool ConfirmationRequired ,

     int? ConfirmationUserId ,

     bool CustomerInfo ,

     bool Waybill ,

     bool LoadNotification ,

     bool CustomsInfo ,

     string? LicencePlate ,

     int? CargoGroup ,

     int? UnloadingArray ,

     bool? SendToBGL ,

     string? PlateNumber ,

     int? CreatingLoadNo ,

     string? OrderingDepot ,

     string? OrderService ,

     double? CashOnDelivery ,

     int? CashOnDeliveryCurrencyId ,

     string? CashOnDeliveryPayment ,

     double? OtherDelivery ,

     int? OtherDeliveryCurrencyId ,

     string? OtherDeliveryPayment 

) : IRequest<APIResponse>;


}
