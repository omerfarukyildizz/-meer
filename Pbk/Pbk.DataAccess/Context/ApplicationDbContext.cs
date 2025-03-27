using Microsoft.EntityFrameworkCore;
using Pbk.Entities.Models;
using Pbk.Entities.Repositories;
using Pbk.Entities.Views;
using System.Collections.Generic;
using System.Reflection.Emit;
using Pbk.Entities.Dto.Voyage;
using Pbk.Entities.Abstractions;
using Pbk.Entities.Dto.Stage;
using Pbk.Entities.Dto.InvoiceItem;
using Pbk.Entities.Dto.Shipment;
using Pbk.Entities.Dto.CostItem;
using Pbk.Entities.ModelDtos;
using Pbk.Entities.Dto.Invoice;

namespace Pbk.DataAccess.Context;
internal sealed class ApplicationDbContext : DbContext, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<YdNakMasrafHesapPlani> YdNakMasrafHesapPlani { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);


        builder.Entity<User>().ToTable(tb => tb.HasTrigger("Users_Log_D"));
        builder.Entity<User>().ToTable(tb => tb.HasTrigger("Users_Log_I"));
        builder.Entity<User>().ToTable(tb => tb.HasTrigger("Users_Log_U"));

        builder.Entity<Authority>().ToTable(tb => tb.HasTrigger("Authority_Log_D"));
        builder.Entity<Authority>().ToTable(tb => tb.HasTrigger("Authority_Log_I"));
        builder.Entity<Authority>().ToTable(tb => tb.HasTrigger("Authority_Log_U"));

        builder.Entity<Department>().ToTable(tb => tb.HasTrigger("Departments_Log_D"));
        builder.Entity<Department>().ToTable(tb => tb.HasTrigger("Departments_Log_I"));
        builder.Entity<Department>().ToTable(tb => tb.HasTrigger("Departments_Log_U"));
        
        builder.Entity<EndPoint>().ToTable(tb => tb.HasTrigger("EndPoints_Log_D"));
        builder.Entity<EndPoint>().ToTable(tb => tb.HasTrigger("EndPoints_Log_I"));
        builder.Entity<EndPoint>().ToTable(tb => tb.HasTrigger("EndPoints_Log_U"));
        
        builder.Entity<Location>().ToTable(tb => tb.HasTrigger("Locations_Log_D"));
        builder.Entity<Location>().ToTable(tb => tb.HasTrigger("Locations_Log_I"));
        builder.Entity<Location>().ToTable(tb => tb.HasTrigger("Locations_Log_U"));
       
        builder.Entity<Carrier>().ToTable(tb => tb.HasTrigger("Carriers_Log_D"));
        builder.Entity<Carrier>().ToTable(tb => tb.HasTrigger("Carriers_Log_I"));
        builder.Entity<Carrier>().ToTable(tb => tb.HasTrigger("Carriers_Log_U"));

        builder.Entity<Document>().ToTable(tb => tb.HasTrigger("Documents_Log_D"));
        builder.Entity<Document>().ToTable(tb => tb.HasTrigger("Documents_Log_I"));
        builder.Entity<Document>().ToTable(tb => tb.HasTrigger("Documents_Log_U"));

        builder.Entity<Driver>().ToTable(tb => tb.HasTrigger("Drivers_Log_D"));
        builder.Entity<Driver>().ToTable(tb => tb.HasTrigger("Drivers_Log_I"));
        builder.Entity<Driver>().ToTable(tb => tb.HasTrigger("Drivers_Log_U"));
        
        builder.Entity<Customer>().ToTable(tb => tb.HasTrigger("Customers_Log_D"));
        builder.Entity<Customer>().ToTable(tb => tb.HasTrigger("Customers_Log_I"));
        builder.Entity<Customer>().ToTable(tb => tb.HasTrigger("Customers_Log_U"));
        
        builder.Entity<Parameter>().ToTable(tb => tb.HasTrigger("Parameters_Log_D"));
        builder.Entity<Parameter>().ToTable(tb => tb.HasTrigger("Parameters_Log_I"));
        builder.Entity<Parameter>().ToTable(tb => tb.HasTrigger("Parameters_Log_U"));

        builder.Entity<Vehicle>().ToTable(tb => tb.HasTrigger("Vehicles_Log_D"));
        builder.Entity<Vehicle>().ToTable(tb => tb.HasTrigger("Vehicles_Log_I"));
        builder.Entity<Vehicle>().ToTable(tb => tb.HasTrigger("Vehicles_Log_U"));

        builder.Entity<Shipment>().ToTable(tb => tb.HasTrigger("Shipments_Log_D"));
        builder.Entity<Shipment>().ToTable(tb => tb.HasTrigger("Shipments_Log_I"));
        builder.Entity<Shipment>().ToTable(tb => tb.HasTrigger("Shipments_Log_U"));

        builder.Entity<Stage>().ToTable(tb => tb.HasTrigger("Stages_Log_D"));
        builder.Entity<Stage>().ToTable(tb => tb.HasTrigger("Stages_Log_I"));
        builder.Entity<Stage>().ToTable(tb => tb.HasTrigger("Stages_Log_U"));

        builder.Entity<Voyage>().ToTable(tb => tb.HasTrigger("Voyages_Log_D"));
        builder.Entity<Voyage>().ToTable(tb => tb.HasTrigger("Voyages_Log_I"));
        builder.Entity<Voyage>().ToTable(tb => tb.HasTrigger("Voyages_Log_U"));


        builder.Entity<CostItem>().ToTable(tb => tb.HasTrigger("CostItems_Log_D"));
        builder.Entity<CostItem>().ToTable(tb => tb.HasTrigger("CostItems_Log_I"));
        builder.Entity<CostItem>().ToTable(tb => tb.HasTrigger("CostItems_Log_U"));

        builder.Entity<InvoiceItem>().ToTable(tb => tb.HasTrigger("InvoiceItems_Log_D"));
        builder.Entity<InvoiceItem>().ToTable(tb => tb.HasTrigger("InvoiceItems_Log_I"));
        builder.Entity<InvoiceItem>().ToTable(tb => tb.HasTrigger("InvoiceItems_Log_U"));   
        
        
        builder.Entity<PlannedStage>().ToTable(tb => tb.HasTrigger("PlannedStages_Log_D"));
        builder.Entity<PlannedStage>().ToTable(tb => tb.HasTrigger("PlannedStages_Log_I"));
        builder.Entity<PlannedStage>().ToTable(tb => tb.HasTrigger("PlannedStages_Log_U"));


        builder.Entity<DynamicEmptyKm>().ToTable(tb => tb.HasTrigger("DynamicEmptyKm_Log_D"));
        builder.Entity<DynamicEmptyKm>().ToTable(tb => tb.HasTrigger("DynamicEmptyKm_Log_I"));
        builder.Entity<DynamicEmptyKm>().ToTable(tb => tb.HasTrigger("DynamicEmptyKm_Log_U"));


        builder.Entity<Invoice>().ToTable(tb => tb.HasTrigger("Invoice_Log_D"));
        builder.Entity<Invoice>().ToTable(tb => tb.HasTrigger("Invoice_Log_I"));
        builder.Entity<Invoice>().ToTable(tb => tb.HasTrigger("Invoice_Log_U"));


        //builder.Entity<Location>(entity =>
        //{
        //    entity.HasKey(e => e.LocationId).HasName("PK__Location__E7FEA4971DC67A39");

        //    entity.ToTable(tb =>
        //    {
        //        tb.HasTrigger("Locations_Log_D");
        //        tb.HasTrigger("Locations_Log_I");
        //        tb.HasTrigger("Locations_Log_U");
        //    });

        //    entity.Property(e => e.Address)
        //        .HasMaxLength(255)
        //        .IsUnicode(false);
        //    entity.Property(e => e.InsTime)
        //        .HasDefaultValueSql("(getdate())")
        //        .HasColumnType("datetime");
        //    entity.Property(e => e.Latitude)
        //        .HasMaxLength(15)
        //        .IsUnicode(false);
        //    entity.Property(e => e.LocationName)
        //        .HasMaxLength(255)
        //        .IsUnicode(false);
        //    entity.Property(e => e.Longitude)
        //        .HasMaxLength(15)
        //        .IsUnicode(false);
        //    entity.Property(e => e.Phone)
        //        .HasMaxLength(20)
        //        .IsUnicode(false);
        //    entity.Property(e => e.PostalCode)
        //        .HasMaxLength(10)
        //        .IsUnicode(false);
        //    entity.Property(e => e.UpdTime).HasColumnType("datetime");

        //    entity.HasOne(d => d.Country).WithMany()
        //        .HasForeignKey(d => d.CountryId)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK_Locations_Countries");
 
        //    entity.HasOne(d => d.Department).WithMany()
        //        .HasForeignKey(d => d.DepartmentId)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK_Locations_Departments");

        //    entity.HasOne(d => d.Place).WithMany()
        //        .HasForeignKey(d => d.PlaceId)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK_Locations_Place");
        //});


        //builder.Entity<Customer>(entity =>
        //{
        //    entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D88BA31B3B");

        //    entity.ToTable(tb =>
        //    {
        //        tb.HasTrigger("Customers_Log_D");
        //        tb.HasTrigger("Customers_Log_I");
        //        tb.HasTrigger("Customers_Log_U");
        //    });

        //    entity.Property(e => e.Adress)
        //        .HasMaxLength(255)
        //        .IsUnicode(false);
        //    entity.Property(e => e.AdressDetail)
        //        .HasMaxLength(255)
        //        .IsUnicode(false);
        //    entity.Property(e => e.ContactEmail)
        //        .HasMaxLength(50)
        //        .IsUnicode(false);
        //    entity.Property(e => e.ContactName)
        //        .HasMaxLength(50)
        //        .IsUnicode(false);
        //    entity.Property(e => e.ContactPhone)
        //        .HasMaxLength(15)
        //        .IsUnicode(false);
        //    entity.Property(e => e.ContactPosition)
        //        .HasMaxLength(50)
        //        .IsUnicode(false);
        //    entity.Property(e => e.CustomerName)
        //        .HasMaxLength(255)
        //        .IsUnicode(false);
        //    entity.Property(e => e.Description)
        //        .HasMaxLength(255)
        //        .IsUnicode(false);
        //    entity.Property(e => e.Email)
        //        .HasMaxLength(50)
        //        .IsUnicode(false);
        //    entity.Property(e => e.Fax)
        //        .HasMaxLength(15)
        //        .IsUnicode(false);
        //    entity.Property(e => e.Freight).HasColumnType("decimal(10, 2)");
        //    entity.Property(e => e.InsTime)
        //        .HasDefaultValueSql("(getdate())")
        //        .HasColumnType("datetime");
        //    entity.Property(e => e.InvoiceEmail)
        //        .HasMaxLength(50)
        //        .IsUnicode(false);
        //    entity.Property(e => e.Phone)
        //        .HasMaxLength(15)
        //        .IsUnicode(false);
        //    entity.Property(e => e.PostalCode)
        //        .HasMaxLength(15)
        //        .IsUnicode(false);
        //    entity.Property(e => e.SAPCompanyCode)
        //        .HasMaxLength(10)
        //        .IsUnicode(false);
        //    entity.Property(e => e.UpdTime).HasColumnType("datetime");
        //    entity.Property(e => e.VATRate).HasColumnType("decimal(4, 2)");

        //    entity.HasOne(d => d.Country).WithMany()
        //        .HasForeignKey(d => d.CountryId)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK_Customers_Countries");

        //    entity.HasOne(d => d.Department).WithMany()
        //        .HasForeignKey(d => d.DepartmentId)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK_Customers_Departments");

        //    entity.HasOne(d => d.Sector).WithMany()
        //        .HasForeignKey(d => d.SectorId)
        //        .HasConstraintName("FK_Customers_Sectors");

        //    entity.HasOne(d => d.Place).WithMany()
        //       .HasForeignKey(d => d.PlaceId)
        //       .HasConstraintName("FK_Customers_PlaceId");
        //});


        builder.Entity<ParameterValue>(entity =>
        {
            entity.HasKey(e => e.ParameterValueId).HasName("PK__Paramete__A2F9292A4A56237F");

            entity.ToTable(tb =>
            {
                tb.HasTrigger("ParameterValues_Log_D");
                tb.HasTrigger("ParameterValues_Log_I");
                tb.HasTrigger("ParameterValues_Log_U");
            });

            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CustomField1)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CustomField2)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CustomField3)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CustomField4)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CustomField5)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.InsTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UpdTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Parameter).WithMany()
                .HasForeignKey(d => d.ParameterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Parameter__Param__79FD19BE");
        });


        builder.Entity<EndPoint>(entity =>
        {
            entity.HasKey(e => e.PointId).HasName("PK__EndPoint__40A977E1582D5B9B");

            entity.ToTable(tb =>
            {
                tb.HasTrigger("EndPoints_Log_D");
                tb.HasTrigger("EndPoints_Log_I");
                tb.HasTrigger("EndPoints_Log_U");
            });
            entity.ToTable("EndPoints").HasKey(e => e.PointId);
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.BarsisAdrBankCode)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.InsTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Latitude)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Longitude)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PointName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PostalCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Reference)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RelatedPerson)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdTime).HasColumnType("datetime");

            
        });

        builder.Entity<VoyageSpDto>().HasNoKey();
        builder.Entity<StageSpDto>().HasNoKey();
        builder.Entity<InvoiceItemSpDto>().HasNoKey();
        builder.Entity<ShipmentSpDto>().HasNoKey();
        builder.Entity<VoyagePlanningOverviewSpDto>().HasNoKey();
        builder.Entity<InvoiceItemByParamSpDto>().HasNoKey();
        builder.Entity<CostItemByParamSpDto>().HasNoKey();
        builder.Entity<CostItemListSpDto>().HasNoKey();
        builder.Entity<InvoiceItemDetailsSpDto>().HasNoKey();
        builder.Entity<GetStageKmDto>().HasNoKey();
        builder.Entity<InvoiceSpDto>().HasNoKey();
        //builder.Entity<DynamicEmptyKm>().HasNoKey();
        


        builder.Entity<Voyage>()
       .HasOne(v => v.Trailer)
       .WithMany(v => v.VoyageTrailers)
       .HasForeignKey(v => v.TrailerId)
       .OnDelete(DeleteBehavior.Restrict); 

        builder.Entity<Voyage>()
            .HasOne(v => v.Truck)
            .WithMany(v => v.VoyageTrucks)
            .HasForeignKey(v => v.TruckId)
            .OnDelete(DeleteBehavior.Restrict);

   








        //builder.HasDbFunction(typeof(KullaniciYetkiliDepartman).GetMethod(nameof(YetkiliDepartman), new[] { typeof(int) })).HasName("KullaniciYetkiliDepartman");
        //  builder.Entity<GnlKullFirmaVW>().HasNoKey().ToView(nameof(gnlkullfirma_vw));
        //builder.Entity<KullaniciYetkiliDepartman>().HasNoKey().ToFunction(nameof(KullaniciYetkiliDepartman));
        //builder.Entity<KullaniciYetkiliDepartman>().HasNoKey().ToFunction(nameof(KullaniciYetkiliDepartman)).Property(x => x.kullanici).HasColumnName("kullanici");
        //  builder.Entity<GnlDepartman>().ToTable(tb => tb.HasTrigger("gnldepartman_update"));
        //  builder.Entity<Gnladresbankasi>().ToTable(tb => tb.HasTrigger("gnladresbankasi_Log_I"));
        //builder.Entity<GnlFirmaEditor>().OwnsOne(x => x.GnlFirma);
    }
}