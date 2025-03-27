using AutoMapper;
using Pbk.Core.Features.Account.Create;
using Pbk.Core.Features.Account.Update;
using Pbk.Core.Features.Authority.Create;
using Pbk.Core.Features.Carriers.Create;
using Pbk.Core.Features.Carriers.Get;
using Pbk.Core.Features.Carriers.Remove;
using Pbk.Core.Features.Carriers.Update;
using Pbk.Core.Features.CostItems.Create;
using Pbk.Core.Features.CostItems.Remove;
using Pbk.Core.Features.CostItems.Update;
using Pbk.Core.Features.Customers.Create;
using Pbk.Core.Features.Customers.Get;
using Pbk.Core.Features.Customers.Remove;
using Pbk.Core.Features.Customers.Update;
using Pbk.Core.Features.Departments.Create;
using Pbk.Core.Features.Departments.Update;
using Pbk.Core.Features.Documents.Create;
using Pbk.Core.Features.Documents.Remove;
using Pbk.Core.Features.Documents.Update;
using Pbk.Core.Features.Drivers.Create;
using Pbk.Core.Features.Drivers.Get;
using Pbk.Core.Features.Drivers.Remove;
using Pbk.Core.Features.Drivers.Update;
using Pbk.Core.Features.EndPoints.Create;
using Pbk.Core.Features.EndPoints.Remove;
using Pbk.Core.Features.EndPoints.Update;
using Pbk.Core.Features.ExpenseCodes.Create;
using Pbk.Core.Features.ExpenseCodes.Remove;
using Pbk.Core.Features.ExpenseCodes.Update;
using Pbk.Core.Features.InvoiceItems.Create;
using Pbk.Core.Features.InvoiceItems.Remove;
using Pbk.Core.Features.InvoiceItems.Update;
using Pbk.Core.Features.InvoiceItems.Update.UpdateInvoiceId;
 
using Pbk.Core.Features.Invoices.Create;
using Pbk.Core.Features.Invoices.Remove;
using Pbk.Core.Features.Invoices.Update;
using Pbk.Core.Features.Locations.Create;
using Pbk.Core.Features.Locations.Update;
using Pbk.Core.Features.Pages.Get;
using Pbk.Core.Features.Parameters.Create;
using Pbk.Core.Features.Parameters.Remove;
using Pbk.Core.Features.Parameters.Update;
using Pbk.Core.Features.ParameterValues.Create;
using Pbk.Core.Features.ParameterValues.Remove;
using Pbk.Core.Features.ParameterValues.Update;
using Pbk.Core.Features.RevenueCodes.Create;
using Pbk.Core.Features.RevenueCodes.Remove;
using Pbk.Core.Features.RevenueCodes.Update;
using Pbk.Core.Features.Roles.Get;
using Pbk.Core.Features.Shipments.Create;
using Pbk.Core.Features.Shipments.Remove;
using Pbk.Core.Features.Shipments.Update;
using Pbk.Core.Features.Stages.Create;
using Pbk.Core.Features.Stages.Remove;
using Pbk.Core.Features.Stages.Update;
using Pbk.Core.Features.Vehicles.Create;
using Pbk.Core.Features.Vehicles.Remove;
using Pbk.Core.Features.Vehicles.Update;
using Pbk.Core.Features.Voyages.Create;
using Pbk.Core.Features.Voyages.Remove;
using Pbk.Core.Features.Voyages.Update;
using Pbk.Entities.Dto;
using Pbk.Entities.Dto.Country;
using Pbk.Entities.Dto.Customer;
using Pbk.Entities.Dto.PagePermission;
using Pbk.Entities.Dto.Place;
using Pbk.Entities.Dto.Projects;
using Pbk.Entities.Dto.Stage;
using Pbk.Entities.Dto.Voyage;
using Pbk.Entities.Models;
namespace Pbk.Core.Mapping;
internal sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        
        CreateMap<Authority, AuthorityCreateCommand > ().ReverseMap();

        CreateMap<Voyage, VoyageCreateCommand>().ReverseMap();
        CreateMap<Voyage, VoyageUpdateCommand>().ReverseMap();
        CreateMap<Voyage, VoyageRemoveCommand>().ReverseMap();

        CreateMap<User, UserCreateCommand>().ReverseMap();
        CreateMap<User, UserUpdateCommand>().ReverseMap();

        CreateMap<Department, GetDepartmentsDto>().ReverseMap();
        CreateMap<Department, DepartmentUpdateCommand>().ReverseMap();
        CreateMap<Department, DepartmentCreateCommand>().ReverseMap();


        CreateMap<Location, GetLocationCountryDto>().ReverseMap();
        CreateMap<Location, GetLocationCityDto>().ReverseMap();
        CreateMap<Location, LocationCreateCommand>().ReverseMap();
        CreateMap<Location, LocationUpdateCommand>().ReverseMap();

        CreateMap<EndPoint, GetEndPointDto>().ReverseMap();
        CreateMap<EndPoint, EndPointUpdateCommand>().ReverseMap();
        CreateMap<EndPoint, EndPointCreateCommand>().ReverseMap();
        CreateMap<EndPoint, EndPointRemoveCommand>().ReverseMap();

        CreateMap<Carrier, CarrierGetQuery>().ReverseMap();
        CreateMap<Carrier, CarrierCreateCommand>().ReverseMap();
        CreateMap<Carrier, CarrierUpdateCommand>().ReverseMap();
        CreateMap<Carrier, CarrierRemoveCommand>().ReverseMap();

        CreateMap<Document, GetDocumentDto>().ReverseMap();
        CreateMap<Document, DocumentCreateCommand>().ReverseMap();
        CreateMap<Document, DocumentUpdateCommand>().ReverseMap();
        CreateMap<Document, DocumentRemoveCommand>().ReverseMap();

        CreateMap<Parameter, GetDocumentArchiveTypesDto>().ReverseMap();
        CreateMap<Parameter, GetParametersDto>().ReverseMap();
        CreateMap<Parameter, GetCategoryDto>().ReverseMap();
        CreateMap<Parameter, GetParameterListDto>().ReverseMap();

        CreateMap<Parameter, ParameterCreateCommand>().ReverseMap();
        CreateMap<Parameter, ParameterUpdateCommand>().ReverseMap();
        CreateMap<Parameter, ParameterRemoveCommand>().ReverseMap();

        CreateMap<ParameterValue, ParameterValueCreateCommand>().ReverseMap();
        CreateMap<ParameterValue, ParameterValueUpdateCommand>().ReverseMap();
        CreateMap<ParameterValue, ParameterValueRemoveCommand>().ReverseMap();

        CreateMap<Driver, DriverGetQuery>().ReverseMap();
        CreateMap<Driver, DriverCreateCommand>().ReverseMap();
        CreateMap<Driver, DriverUpdateCommand>().ReverseMap();
        CreateMap<Driver, DriverRemoveCommand>().ReverseMap();

        CreateMap<Customer, CustomerGetQuery>().ReverseMap();
        CreateMap<Customer, GetCustomerNameDto>().ReverseMap();
        CreateMap<Customer, CustomerCreateCommand>().ReverseMap();
        CreateMap<Customer, CustomerUpdateCommand>().ReverseMap();
        CreateMap<Customer, CustomerRemoveCommand>().ReverseMap();

        CreateMap<Vehicle, GetVehicleDto>().ReverseMap();

        CreateMap<Country, GetCountriesDto>().ReverseMap();
        CreateMap<Place, GetPlaceDto>().ReverseMap();
        CreateMap<Role, RoleGetQuery>().ReverseMap();
        CreateMap<Page, PageGetQuery>().ReverseMap();
        CreateMap<Project, GetProjectDto>().ReverseMap();
        CreateMap<PagePermission, GetPagePermissionWithPageDto>().ReverseMap();

        CreateMap<Vehicle, VehicleCreateCommand>().ReverseMap();
        CreateMap<Vehicle, VehicleUpdateCommand>().ReverseMap();
        CreateMap<Vehicle, VehicleRemoveCommand>().ReverseMap();

        CreateMap<Shipment, ShipmentCreateCommand>().ReverseMap();
        CreateMap<Shipment, ShipmentUpdateCommand>().ReverseMap();
        CreateMap<Shipment, ShipmentRemoveCommand>().ReverseMap();

        CreateMap<Stage, StageCreateCommand>().ReverseMap();
        CreateMap<Stage, StageUpdateCommand>().ReverseMap();
        CreateMap<Stage, StageRemoveCommand>().ReverseMap();

        CreateMap<ExpenseCode, ExpenseCodeCreateCommand>().ReverseMap();
        CreateMap<ExpenseCode, ExpenseCodeUpdateCommand>().ReverseMap();
        CreateMap<ExpenseCode, ExpenseCodeRemoveCommand>().ReverseMap();

        CreateMap<RevenueCode, RevenueCodeCreateCommand>().ReverseMap();
        CreateMap<RevenueCode, RevenueCodeUpdateCommand>().ReverseMap();
        CreateMap<RevenueCode, RevenueCodeRemoveCommand>().ReverseMap();

        CreateMap<CostItem, CostItemCreateCommand>().ReverseMap();
        CreateMap<CostItem, CostItemUpdateCommand>().ReverseMap();
        CreateMap<CostItem, CostItemRemoveCommand>().ReverseMap();


        CreateMap<InvoiceItem, InvoiceItemCreateCommand>().ReverseMap();
        CreateMap<InvoiceItem, InvoiceItemUpdateCommand>().ReverseMap();
        CreateMap<InvoiceItem, InvoiceItemByInvoiceIdUpdateCommand>().ReverseMap();
        CreateMap<InvoiceItem, InvoiceItemRemoveCommand>().ReverseMap();


        CreateMap<Invoice, InvoiceCreateCommand>().ReverseMap();
        CreateMap<Invoice, InvoiceUpdateCommand>().ReverseMap();
        CreateMap<Invoice, InvoiceRemoveCommand>().ReverseMap();


        //CreateMap<CreateDnkonsimentoCommand, Dnkonsimento>().ReverseMap();
        //CreateMap<CreateDnkonsimentoByYukNoCommand, Dnkonsimento>().ReverseMap();
        //CreateMap<UpdateDnkonsimentoCommand, Dnkonsimento>().ReverseMap();
        //CreateMap<RemoveDnkonsimentoByIdCommand, Dnkonsimento>().ReverseMap();

    }
}
