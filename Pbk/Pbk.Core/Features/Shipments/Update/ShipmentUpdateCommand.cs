using Pbk.Core.Features.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Shipments.Update
{ 
    public sealed record ShipmentUpdateCommand
(
        int ShipmentId,
int? IntegrationId,
int DepartmentId,
int StatusTypeId,
int ShipmentTypeId,
string? LoadingDescription,
int? CustomerId,
int SectorId,
int Year,
int SenderId,
int ReceiverId,
DateTime LoadingTime,
DateTime UnloadingTime,
int? BarsisAnaYukNo,
int? BarsisYukNo,
decimal? Freight,
decimal? AdditionalFreight,
int CurrencyId,
decimal VATRate,
string? FreightPaymentType,
string? ReferenceNo,
int? UnitId,
int? LoadingPalletExchange,
int? UnloadingPalletExchange,
int? PalletsAtLoad,
int? PalletsAtUnload,
int? PalletCompanyId,
int? Pieces,
decimal? Width,
decimal? Weight,
decimal? Length,
decimal? Height,
decimal? LDM,
string? WarehouseCode,
string? SenderWarehouseCode,
string? ReceiverWarehouseCode,
string? WarehouseHub,
string? ReferenceShip,
string? Art,
string? OrderType,
string? DeliveryType,
DateTime? DeliveryDate,
DateTime? DeliveryTimeBegin,
DateTime? DeliveryTimeEnd,
string? ReferenceNoc,
string? UnloadingType,
DateTime? UnloadingDate,
DateTime? UnloadingTimeBegin,
DateTime? UnloadingTimeEnd,
string? ValueOfGoods,
string? CustomerReference,
string? PublicText,
string? InternalText,
bool? VTLBildirildi,
DateTime? VTLBildirilmeZamani,
string? ConsignmentNumber,
DateTime? ConfirmationTime,
string? Type,
bool? VTLBildirilecek,
string? LoadWithT1Text,
string? CustomerInfoText,
string? WaybillNumText,
string? LoadNotificationText,
string? CustomsInfoText,
string? IncotermNew, 
int? IncoTermId,
string? IntegrationFileName,
int? PlanningDepartmentId,
string? UnloadingDescription
  ) : IRequest<APIResponse>;


}
