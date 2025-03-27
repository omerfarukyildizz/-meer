/*using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Pbk.Entities.Models2;

public partial class EDPContext : DbContext
{
    public EDPContext()
    {
    }

    public EDPContext(DbContextOptions<EDPContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ArchiveType> ArchiveTypes { get; set; }

    public virtual DbSet<Authority> Authorities { get; set; }

    public virtual DbSet<Carrier> Carriers { get; set; }

    public virtual DbSet<CostItem> CostItems { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Currency> Currencies { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<EndPoint> EndPoints { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<InvoiceItem> InvoiceItems { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Page> Pages { get; set; }

    public virtual DbSet<PagePermission> PagePermissions { get; set; }

    public virtual DbSet<Parameter> Parameters { get; set; }

    public virtual DbSet<ParameterValue> ParameterValues { get; set; }

    public virtual DbSet<PaymentType> PaymentTypes { get; set; }

    public virtual DbSet<Place> Places { get; set; }

    public virtual DbSet<PostalCode> PostalCodes { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Sector> Sectors { get; set; }

    public virtual DbSet<Shipment> Shipments { get; set; }

    public virtual DbSet<Stage> Stages { get; set; }

    public virtual DbSet<StageLocation> StageLocations { get; set; }

    public virtual DbSet<Translation> Translations { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    public virtual DbSet<VehicleType> VehicleTypes { get; set; }

    public virtual DbSet<ViewSetting> ViewSettings { get; set; }

    public virtual DbSet<Voyage> Voyages { get; set; }

    public virtual DbSet<VtlAdditional> VtlAdditionals { get; set; }

    public virtual DbSet<VtlAdrType> VtlAdrTypes { get; set; }

    public virtual DbSet<VtlPackage> VtlPackages { get; set; }

    public virtual DbSet<VtlPackageADR> VtlPackageADRs { get; set; }

    public virtual DbSet<VtlPackageInfo> VtlPackageInfos { get; set; }

    public virtual DbSet<VtlStatu> VtlStatus { get; set; }

    public virtual DbSet<VtlStatuError> VtlStatuErrors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=bglsqlprod.barsan.com;Database=EDP;User=BGL;Password=56547845;Encrypt=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ArchiveType>(entity =>
        {
            entity.HasKey(e => e.ArchiveTypeId).HasName("PK__ArchiveT__B168E8EB35DF9859");

            entity.Property(e => e.ArchiveType1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ArchiveType");
            entity.Property(e => e.InsTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsPassive).HasDefaultValue(false);
        });

        modelBuilder.Entity<Authority>(entity =>
        {
            entity.HasKey(e => e.AuthorityID).HasName("PK__Authorit__433B1E6D421AAF7E");

            entity.ToTable("Authority", tb =>
                {
                    tb.HasTrigger("Authority_Log_D");
                    tb.HasTrigger("Authority_Log_I");
                    tb.HasTrigger("Authority_Log_U");
                });

            entity.Property(e => e.InsTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UpdTime).HasColumnType("datetime");

            entity.HasOne(d => d.Department).WithMany(p => p.Authorities)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Authority_DepartmentId");

            entity.HasOne(d => d.Page).WithMany(p => p.Authorities)
                .HasForeignKey(d => d.PageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Authority_PageId");

            entity.HasOne(d => d.PagePermission).WithMany(p => p.Authorities)
                .HasForeignKey(d => d.PagePermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Authority_PagePermissions");

            entity.HasOne(d => d.User).WithMany(p => p.Authorities)
                .HasForeignKey(d => d.UserID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Authority__UserI__0E391C95");
        });

        modelBuilder.Entity<Carrier>(entity =>
        {
            entity.HasKey(e => e.CarrierId).HasName("PK__Carriers__CB8205597783D81A");

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("Carriers_Log_D");
                    tb.HasTrigger("Carriers_Log_I");
                    tb.HasTrigger("Carriers_Log_U");
                });

            entity.Property(e => e.CarrierName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ContactPerson)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.InsTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SAPAccountCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdTime).HasColumnType("datetime");

            entity.HasOne(d => d.Department).WithMany(p => p.Carriers)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Carriers_Departments");

            entity.HasOne(d => d.Document).WithMany(p => p.Carriers)
                .HasForeignKey(d => d.DocumentId)
                .HasConstraintName("FK__Carriers__Docume__17C286CF");
        });

        modelBuilder.Entity<CostItem>(entity =>
        {
            entity.HasKey(e => e.CostItemId).HasName("PK__CostItem__076CDE1F34650679");

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("CostItems_Log_D");
                    tb.HasTrigger("CostItems_Log_I");
                    tb.HasTrigger("CostItems_Log_U");
                });

            entity.Property(e => e.CostCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Department)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.InsTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IntegrationNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.InvoiceDate).HasColumnType("datetime");
            entity.Property(e => e.InvoiceNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SAPDocumentNo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Sector)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.UpdTime).HasColumnType("datetime");
            entity.Property(e => e.VATRate).HasColumnType("decimal(4, 2)");

            entity.HasOne(d => d.Carrier).WithMany(p => p.CostItems)
                .HasForeignKey(d => d.CarrierId)
                .HasConstraintName("FK__CostItems__Carri__160F4887");

            entity.HasOne(d => d.Currency).WithMany(p => p.CostItems)
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CostItems_Currencies");

            entity.HasOne(d => d.DepartmentNavigation).WithMany(p => p.CostItems)
                .HasPrincipalKey(p => p.Code)
                .HasForeignKey(d => d.Department)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CostItems__Depar__17036CC0");

            entity.HasOne(d => d.Shipment).WithMany(p => p.CostItems)
                .HasForeignKey(d => d.ShipmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CostItems__Shipm__1332DBDC");

            entity.HasOne(d => d.Stage).WithMany(p => p.CostItems)
                .HasForeignKey(d => d.StageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CostItems__Stage__14270015");

            entity.HasOne(d => d.Voyage).WithMany(p => p.CostItems)
                .HasForeignKey(d => d.VoyageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CostItems__Voyag__151B244E");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("PK__Countrie__10D1609F56530882");

            entity.Property(e => e.Code2)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.Code3)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.Continent)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ContinentCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.CountryName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.InsTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UpdTime).HasColumnType("datetime");
            entity.Property(e => e.UpdUser)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Currency>(entity =>
        {
            entity.HasKey(e => e.CurrencyId).HasName("PK__Currenci__14470AF00B0263AE");

            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.InsTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D88BA31B3B");

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("Customers_Log_D");
                    tb.HasTrigger("Customers_Log_I");
                    tb.HasTrigger("Customers_Log_U");
                });

            entity.Property(e => e.Adress)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.AdressDetail)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ContactEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ContactName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ContactPhone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.ContactPosition)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CustomerName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Fax)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Freight).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.InsTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.InvoiceEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.PostalCode)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.SAPCompanyCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UpdTime).HasColumnType("datetime");
            entity.Property(e => e.VATRate).HasColumnType("decimal(4, 2)");

            entity.HasOne(d => d.Country).WithMany(p => p.Customers)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customers_Countries");

            entity.HasOne(d => d.Department).WithMany(p => p.Customers)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customers_Departments");

            entity.HasOne(d => d.Sector).WithMany(p => p.Customers)
                .HasForeignKey(d => d.SectorId)
                .HasConstraintName("FK_Customers_Sectors");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BEDAD798718");

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("Departments_Log_D");
                    tb.HasTrigger("Departments_Log_I");
                    tb.HasTrigger("Departments_Log_U");
                });

            entity.HasIndex(e => e.Code, "UQ__Departme__A25C5AA7A569DC14").IsUnique();

            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.BlockedAccount)
                .HasMaxLength(14)
                .IsUnicode(false);
            entity.Property(e => e.Code)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.CommercialAccount)
                .HasMaxLength(14)
                .IsUnicode(false);
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Director)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DirectorEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.InsTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.InvoiceCurrency)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.IsPassive).HasDefaultValue(false);
            entity.Property(e => e.OverdraftAccount)
                .HasMaxLength(14)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PostalCode)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.SAPCompanyCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UpdTime).HasColumnType("datetime");
            entity.Property(e => e.YdInvoicePrefix)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Country).WithMany(p => p.Departments)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_Departments_Countries");

            entity.HasOne(d => d.Currency).WithMany(p => p.Departments)
                .HasForeignKey(d => d.CurrencyId)
                .HasConstraintName("FK_Departments_Currencies");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.DocumentId).HasName("PK__Document__1ABEEF0F78A4BBA8");

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("Documents_Log_D");
                    tb.HasTrigger("Documents_Log_I");
                    tb.HasTrigger("Documents_Log_U");
                });

            entity.Property(e => e.FileName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FilePath)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.InsTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UpdTime).HasColumnType("datetime");

            entity.HasOne(d => d.Page).WithMany(p => p.Documents)
                .HasForeignKey(d => d.PageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Documents_Pages");
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.DriverId).HasName("PK__Drivers__F1B1CD045150D943");

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("Drivers_Log_D");
                    tb.HasTrigger("Drivers_Log_I");
                    tb.HasTrigger("Drivers_Log_U");
                });

            entity.Property(e => e.DriverName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EdiCode)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.InsTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IntegratedAccountCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UpdTime).HasColumnType("datetime");

            entity.HasOne(d => d.Department).WithMany(p => p.Drivers)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Drivers_Departments");
        });

        modelBuilder.Entity<EndPoint>(entity =>
        {
            entity.HasKey(e => e.PointId).HasName("PK__EndPoint__40A977E1582D5B9B");

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("EndPoints_Log_D");
                    tb.HasTrigger("EndPoints_Log_I");
                    tb.HasTrigger("EndPoints_Log_U");
                });

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

            entity.HasOne(d => d.Country).WithMany(p => p.EndPoints)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EndPoints_Countries");

            entity.HasOne(d => d.Department).WithMany(p => p.EndPoints)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EndPoints_Departments");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.InvoiceId).HasName("PK__Invoices__D796AAB5F3DC660E");

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("Invoices_Log_D");
                    tb.HasTrigger("Invoices_Log_I");
                    tb.HasTrigger("Invoices_Log_U");
                });

            entity.Property(e => e.Department)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.DueDate).HasColumnType("datetime");
            entity.Property(e => e.InsTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IntegrationNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.InvoiceDate).HasColumnType("datetime");
            entity.Property(e => e.InvoiceNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UpdTime).HasColumnType("datetime");
            entity.Property(e => e.VATRate).HasColumnType("decimal(4, 2)");

            entity.HasOne(d => d.Currency).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Invoices_Currencies");

            entity.HasOne(d => d.Customer).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Invoices__Custom__1AD3FDA4");

            entity.HasOne(d => d.DepartmentNavigation).WithMany(p => p.Invoices)
                .HasPrincipalKey(p => p.Code)
                .HasForeignKey(d => d.Department)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Invoices__Depart__1DB06A4F");

            entity.HasOne(d => d.Receiver).WithMany(p => p.InvoiceReceivers)
                .HasForeignKey(d => d.ReceiverId)
                .HasConstraintName("FK__Invoices__Receiv__1CBC4616");

            entity.HasOne(d => d.Sender).WithMany(p => p.InvoiceSenders)
                .HasForeignKey(d => d.SenderId)
                .HasConstraintName("FK__Invoices__Sender__1BC821DD");
        });

        modelBuilder.Entity<InvoiceItem>(entity =>
        {
            entity.HasKey(e => e.InvoiceItemId).HasName("PK__InvoiceI__478FE09C10BA5D5E");

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("InvoiceItems_Log_D");
                    tb.HasTrigger("InvoiceItems_Log_I");
                    tb.HasTrigger("InvoiceItems_Log_U");
                });

            entity.Property(e => e.Department)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.InsTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Revenue)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Sector)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.UpdTime).HasColumnType("datetime");
            entity.Property(e => e.VATRate).HasColumnType("decimal(4, 2)");

            entity.HasOne(d => d.Currency).WithMany(p => p.InvoiceItems)
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InvoiceItems_Currencies");

            entity.HasOne(d => d.Customer).WithMany(p => p.InvoiceItems)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__InvoiceIt__Custo__25518C17");

            entity.HasOne(d => d.DepartmentNavigation).WithMany(p => p.InvoiceItems)
                .HasPrincipalKey(p => p.Code)
                .HasForeignKey(d => d.Department)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__InvoiceIt__Depar__2645B050");

            entity.HasOne(d => d.Invoice).WithMany(p => p.InvoiceItems)
                .HasForeignKey(d => d.InvoiceId)
                .HasConstraintName("FK__InvoiceIt__Invoi__245D67DE");

            entity.HasOne(d => d.Shipment).WithMany(p => p.InvoiceItems)
                .HasForeignKey(d => d.ShipmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__InvoiceIt__Shipm__2180FB33");

            entity.HasOne(d => d.Stage).WithMany(p => p.InvoiceItems)
                .HasForeignKey(d => d.StageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__InvoiceIt__Stage__22751F6C");

            entity.HasOne(d => d.Voyage).WithMany(p => p.InvoiceItems)
                .HasForeignKey(d => d.VoyageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__InvoiceIt__Voyag__236943A5");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.LanguageId).HasName("PK__Language__B93855ABBB19A0C7");

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("Languages_Log_D");
                    tb.HasTrigger("Languages_Log_I");
                    tb.HasTrigger("Languages_Log_U");
                });

            entity.Property(e => e.InsDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LanguageIcon)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LanguageName)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.UpdDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__Location__E7FEA4971DC67A39");

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("Locations_Log_D");
                    tb.HasTrigger("Locations_Log_I");
                    tb.HasTrigger("Locations_Log_U");
                });

            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.InsTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Latitude)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.LocationName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Longitude)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PostalCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UpdTime).HasColumnType("datetime");

            entity.HasOne(d => d.Country).WithMany(p => p.Locations)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Locations_Countries");

            entity.HasOne(d => d.Department).WithMany(p => p.Locations)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Locations_Departments");
        });

        modelBuilder.Entity<Page>(entity =>
        {
            entity.HasKey(e => e.PageId).HasName("PK__Pages__C565B104C0639EA8");

            entity.Property(e => e.InsTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PageName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PagePermission>(entity =>
        {
            entity.HasKey(e => e.PagePermissionId).HasName("PK__PagePerm__C298ABD14A51FA82");

            entity.Property(e => e.InsTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PermissionType)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Page).WithMany(p => p.PagePermissions)
                .HasForeignKey(d => d.PageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PagePermi__PageI__32767D0B");
        });

        modelBuilder.Entity<Parameter>(entity =>
        {
            entity.HasKey(e => e.ParameterId).HasName("PK__Paramete__F80C62974CF431C1");

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("Parameters_Log_D");
                    tb.HasTrigger("Parameters_Log_I");
                    tb.HasTrigger("Parameters_Log_U");
                });

            entity.Property(e => e.CategoryName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.InsTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ParameterName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UpdTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<ParameterValue>(entity =>
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

            entity.HasOne(d => d.Parameter).WithMany(p => p.ParameterValues)
                .HasForeignKey(d => d.ParameterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Parameter__Param__79FD19BE");
        });

        modelBuilder.Entity<PaymentType>(entity =>
        {
            entity.HasKey(e => e.PaymentTypeId).HasName("PK__PaymentT__BA430B35F7143919");

            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.InsTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PaymentType1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PaymentType");
        });

        modelBuilder.Entity<Place>(entity =>
        {
            entity.HasKey(e => e.PlaceId).HasName("PK__Places__D5222B6EB34A0F4F");

            entity.Property(e => e.Community)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CommunityCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.InsTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PlaceName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Province)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ProvinceCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.StateCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UpdTime).HasColumnType("datetime");
            entity.Property(e => e.UpdUser)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Country).WithMany(p => p.Places)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Places__CountryI__41B8C09B");
        });

        modelBuilder.Entity<PostalCode>(entity =>
        {
            entity.HasKey(e => e.PostalCodeId).HasName("PK__PostalCo__E197FE416FF1DB15");

            entity.Property(e => e.InsTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Latitude)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Longitude)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.PostalCode1)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("PostalCode");
            entity.Property(e => e.UpdTime).HasColumnType("datetime");
            entity.Property(e => e.UpdUser)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Country).WithMany(p => p.PostalCodes)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PostalCod__Count__467D75B8");

            entity.HasOne(d => d.Place).WithMany(p => p.PostalCodes)
                .HasForeignKey(d => d.PlaceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PostalCod__Place__4589517F");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.ProjectId).HasName("PK__Projects__761ABEF097C0C1BB");

            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.InsTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ProjectName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE1A8ACBD94B");

            entity.Property(e => e.InsTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Sector>(entity =>
        {
            entity.HasKey(e => e.SectorId).HasName("PK__Sectors__755E57E96418AC72");

            entity.Property(e => e.Code)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.InsTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SectorName)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Shipment>(entity =>
        {
            entity.HasKey(e => e.ShipmentId).HasName("PK__Shipment__5CAD37ED4E9679F1");

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("Shipments_Log_D");
                    tb.HasTrigger("Shipments_Log_I");
                    tb.HasTrigger("Shipments_Log_U");
                });

            entity.Property(e => e.AdditionalFreight).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Art)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ChargeableWeight).HasColumnType("decimal(7, 2)");
            entity.Property(e => e.ConfirmationTime).HasColumnType("datetime");
            entity.Property(e => e.ConsignmentNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CustomerInfoText)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CustomerName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CustomerReference)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CustomsInfoText)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DeliveryDate).HasColumnType("datetime");
            entity.Property(e => e.DeliveryTimeBegin).HasColumnType("datetime");
            entity.Property(e => e.DeliveryTimeEnd).HasColumnType("datetime");
            entity.Property(e => e.DeliveryType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Department)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Freight).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.FreightPaymentTerms)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Height).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.IncotermNew)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.InsTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.InternalText)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.LDM).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Length).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.LoadNotificationText)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LoadWithT1Text)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LoadingPalletExchange)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LoadingPostCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.LoadingTime).HasColumnType("datetime");
            entity.Property(e => e.OrderType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PalletCompany)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PublicText)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.ReceiverWarehouseCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ReferenceNo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ReferenceNoc)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ReferenceShip)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SenderWarehouseCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Waiting");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Unit)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UnloadingDate).HasColumnType("datetime");
            entity.Property(e => e.UnloadingPalletExchange)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UnloadingPostCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UnloadingTime).HasColumnType("datetime");
            entity.Property(e => e.UnloadingTimeBegin).HasColumnType("datetime");
            entity.Property(e => e.UnloadingTimeEnd).HasColumnType("datetime");
            entity.Property(e => e.UnloadingType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdTime).HasColumnType("datetime");
            entity.Property(e => e.VATRate).HasColumnType("decimal(4, 2)");
            entity.Property(e => e.VTLBildirilmeZamani).HasColumnType("datetime");
            entity.Property(e => e.ValueOfGoods)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Volume).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.WarehouseCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.WarehouseHub)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.WaybillNumText)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Weight).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Width).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Currency).WithMany(p => p.Shipments)
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Shipments_Currencies");

            entity.HasOne(d => d.Customer).WithMany(p => p.Shipments)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Shipments__Custo__7B5B524B");

            entity.HasOne(d => d.DepartmentNavigation).WithMany(p => p.Shipments)
                .HasPrincipalKey(p => p.Code)
                .HasForeignKey(d => d.Department)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Shipments__Depar__7D439ABD");

            entity.HasOne(d => d.Document).WithMany(p => p.Shipments)
                .HasForeignKey(d => d.DocumentId)
                .HasConstraintName("FK__Shipments__Docum__7C4F7684");
        });

        modelBuilder.Entity<Stage>(entity =>
        {
            entity.HasKey(e => e.StageId).HasName("PK__Stages__03EB7AD86E70AC9C");

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("Stages_Log_D");
                    tb.HasTrigger("Stages_Log_I");
                    tb.HasTrigger("Stages_Log_U");
                });

            entity.Property(e => e.InsTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LoadingDateTime).HasColumnType("datetime");
            entity.Property(e => e.LoadingPostCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.StageStatus)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UnloadingDateTime).HasColumnType("datetime");
            entity.Property(e => e.UnloadingPostCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UpdTime).HasColumnType("datetime");

            entity.HasOne(d => d.Shipment).WithMany(p => p.Stages)
                .HasForeignKey(d => d.ShipmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Stages__Shipment__09A971A2");

            entity.HasOne(d => d.Voyage).WithMany(p => p.Stages)
                .HasForeignKey(d => d.VoyageId)
                .HasConstraintName("FK__Stages__VoyageId__0A9D95DB");
        });

        modelBuilder.Entity<StageLocation>(entity =>
        {
            entity.HasKey(e => e.StageLocationId).HasName("PK__StageLoc__54B0552FC94F7C28");

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("StageLocations_Log_D");
                    tb.HasTrigger("StageLocations_Log_I");
                    tb.HasTrigger("StageLocations_Log_U");
                });

            entity.Property(e => e.InsTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LoadingType)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UpdTime).HasColumnType("datetime");

            entity.HasOne(d => d.Location).WithMany(p => p.StageLocations)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StageLoca__Locat__0F624AF8");

            entity.HasOne(d => d.Stage).WithMany(p => p.StageLocations)
                .HasForeignKey(d => d.StageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StageLoca__Stage__0E6E26BF");
        });

        modelBuilder.Entity<Translation>(entity =>
        {
            entity.HasKey(e => e.TranslateId).HasName("PK__Translat__049D61D83C8D74E0");

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("Translations_Log_D");
                    tb.HasTrigger("Translations_Log_I");
                    tb.HasTrigger("Translations_Log_U");
                });

            entity.Property(e => e.InsDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsPassive).HasDefaultValue(false);
            entity.Property(e => e.UpdDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C31C6B49F");

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("Users_Log_D");
                    tb.HasTrigger("Users_Log_I");
                    tb.HasTrigger("Users_Log_U");
                });

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.InsTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsPassive).HasDefaultValue(false);
            entity.Property(e => e.Password)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Position)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdTime).HasColumnType("datetime");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Department).WithMany(p => p.Users)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Department");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Roles");
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.VehicleId).HasName("PK__Vehicles__476B549210C86077");

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("Vehicles_Log_D");
                    tb.HasTrigger("Vehicles_Log_I");
                    tb.HasTrigger("Vehicles_Log_U");
                });

            entity.Property(e => e.InsTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsPassive).HasDefaultValue(false);
            entity.Property(e => e.Plate)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.UpdTime).HasColumnType("datetime");

            entity.HasOne(d => d.Department).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vehicles_Departments");

            entity.HasOne(d => d.Document).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.DocumentId)
                .HasConstraintName("FK__Vehicles__Docume__59FA5E80");

            entity.HasOne(d => d.Project).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK_Vehicles_Projects");

            entity.HasOne(d => d.VehicleType).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.VehicleTypeId)
                .HasConstraintName("FK_Vehicles_VehicleTypes");
        });

        modelBuilder.Entity<VehicleType>(entity =>
        {
            entity.HasKey(e => e.VehicleTypeId).HasName("PK__VehicleT__9F449643F95089E6");

            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.InsTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.VehicleTypeName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ViewSetting>(entity =>
        {
            entity.HasKey(e => e.SettingId).HasName("PK__ViewSett__54372B1DE248E62B");

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("ViewSettings_Log_D");
                    tb.HasTrigger("ViewSettings_Log_I");
                    tb.HasTrigger("ViewSettings_Log_U");
                });

            entity.Property(e => e.InsTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UpdTime).HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.ViewSettings)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ViewSetti__UserI__66603565");
        });

        modelBuilder.Entity<Voyage>(entity =>
        {
            entity.HasKey(e => e.VoyageId).HasName("PK__Voyages__577D734382565272");

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("Voyages_Log_D");
                    tb.HasTrigger("Voyages_Log_I");
                    tb.HasTrigger("Voyages_Log_U");
                });

            entity.Property(e => e.ArrivalTime).HasColumnType("datetime");
            entity.Property(e => e.DepartureTime).HasColumnType("datetime");
            entity.Property(e => e.InsTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LoadingPostCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UnloadingPostCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UpdTime).HasColumnType("datetime");
            entity.Property(e => e.VoyageKM).HasColumnType("decimal(7, 2)");

            entity.HasOne(d => d.Carrier).WithMany(p => p.Voyages)
                .HasForeignKey(d => d.CarrierId)
                .HasConstraintName("FK__Voyages__Carrier__02FC7413");

            entity.HasOne(d => d.Driver).WithMany(p => p.Voyages)
                .HasForeignKey(d => d.DriverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Voyages__DriverI__05D8E0BE");

            entity.HasOne(d => d.Trailer).WithMany(p => p.VoyageTrailers)
                .HasForeignKey(d => d.TrailerId)
                .HasConstraintName("FK__Voyages__Trailer__04E4BC85");

            entity.HasOne(d => d.Truck).WithMany(p => p.VoyageTrucks)
                .HasForeignKey(d => d.TruckId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Voyages__TruckId__03F0984C");
        });

        modelBuilder.Entity<VtlAdditional>(entity =>
        {
            entity.HasKey(e => e.ShipmentId).HasName("PK__VtlAddit__5CAD37ED114898B3");

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("VtlAdditionals_Log_D");
                    tb.HasTrigger("VtlAdditionals_Log_I");
                    tb.HasTrigger("VtlAdditionals_Log_U");
                });

            entity.Property(e => e.CadisBildirilmeZamani).HasColumnType("datetime");
            entity.Property(e => e.CallBeforeLoading)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CallBeforeLoadingDay)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CallBeforeUnloading)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CallDriver)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CashOnDeliveryPayment)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CustomDocNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CustomInfo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CustomerOrderNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DeliveryDelayReport)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EkaerNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IncoTerms)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LicencePlate)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Lkw)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NewStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OldStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OrderService)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OrderingDepot)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OtherDeliveryPayment)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PaletReference)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PaletType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PaymentType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PlantCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PlateNumber)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.ShipmentWarehouseCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StatusInfo)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.WaybillNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Week)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VtlAdrType>(entity =>
        {
            entity.HasKey(e => e.AdrTypeId).HasName("PK__VtlAdrTy__D744AA27B2FB1526");

            entity.Property(e => e.ADRGueltigBis)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ADRVersion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Beförderungskategorie)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Benennung_DE)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Benennung DE");
            entity.Property(e => e.Benennung_FR)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Benennung FR");
            entity.Property(e => e.Benennung_GB)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Benennung GB");
            entity.Property(e => e.Hauptgefahr)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Kennzeichen_der_gefGüter_mit_hohem_Gefahrenpotential)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Kennzeichen der gefGüter mit hohem Gefahrenpotential");
            entity.Property(e => e.Klasse)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Klassifizierungscode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LQ)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Multiplikator)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.N_A_G_Kennzeichen)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("N A G Kennzeichen");
            entity.Property(e => e.Nebengefahr1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nebengefahr2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nebengefahr3)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nebengefahr4)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Sondervorschriften)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Stammdaten_FLUESSIG)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Stammdaten FLUESSIG");
            entity.Property(e => e.Tunnelvorschrift)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Type)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UN_Nummer)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("UN-Nummer");
            entity.Property(e => e.UN_Unternummer)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("UN-Unternummer");
            entity.Property(e => e.VTLSTRG)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Verpackungsgruppe)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Änderungsdatum)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VtlPackage>(entity =>
        {
            entity.HasKey(e => e.PackageId).HasName("PK__VtlPacka__322035CC533202F4");

            entity.ToTable("VtlPackage", tb =>
                {
                    tb.HasTrigger("VtlPackage_Log_D");
                    tb.HasTrigger("VtlPackage_Log_I");
                    tb.HasTrigger("VtlPackage_Log_U");
                });

            entity.Property(e => e.CargoContents)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ConsignmentPackage)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Identifier)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NumberOfPackages)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PackageType)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Shipment).WithMany(p => p.VtlPackages)
                .HasForeignKey(d => d.ShipmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__VtlPackag__Shipm__2B0A656D");
        });

        modelBuilder.Entity<VtlPackageADR>(entity =>
        {
            entity.HasKey(e => e.PackageADRId).HasName("PK__VtlPacka__0DDF143D1219BB11");

            entity.ToTable("VtlPackageADR", tb =>
                {
                    tb.HasTrigger("VtlPackageADR_Log_D");
                    tb.HasTrigger("VtlPackageADR_Log_I");
                    tb.HasTrigger("VtlPackageADR_Log_U");
                });

            entity.Property(e => e.ADRNag)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ADRNem).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ADRPackageType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ADRUn)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.AdrActualWeight).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Package).WithMany(p => p.VtlPackageADRs)
                .HasForeignKey(d => d.PackageId)
                .HasConstraintName("FK__VtlPackag__Packa__2DE6D218");
        });

        modelBuilder.Entity<VtlPackageInfo>(entity =>
        {
            entity.HasKey(e => e.PackageInfoId).HasName("PK__VtlPacka__4A455624476BCCD6");

            entity.ToTable("VtlPackageInfo", tb =>
                {
                    tb.HasTrigger("VtlPackageInfo_Log_D");
                    tb.HasTrigger("VtlPackageInfo_Log_I");
                    tb.HasTrigger("VtlPackageInfo_Log_U");
                });

            entity.Property(e => e.Barcode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CargoNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ConsignmentPackage)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CountryOfOrigin)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Package).WithMany(p => p.VtlPackageInfos)
                .HasForeignKey(d => d.PackageId)
                .HasConstraintName("FK__VtlPackag__Packa__30C33EC3");
        });

        modelBuilder.Entity<VtlStatu>(entity =>
        {
            entity.HasKey(e => e.StatuId).HasName("PK__VtlStatu__C7DB7B594F449F1E");

            entity.ToTable("VtlStatu", tb =>
                {
                    tb.HasTrigger("VtlStatu_Log_D");
                    tb.HasTrigger("VtlStatu_Log_I");
                    tb.HasTrigger("VtlStatu_Log_U");
                });

            entity.Property(e => e.InsTime).HasColumnType("datetime");
            entity.Property(e => e.ReferenceNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StatuCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.StatuDescription)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.StatuTime).HasColumnType("datetime");

            entity.HasOne(d => d.Shipment).WithMany(p => p.VtlStatus)
                .HasForeignKey(d => d.ShipmentId)
                .HasConstraintName("FK__VtlStatu__Shipme__339FAB6E");
        });

        modelBuilder.Entity<VtlStatuError>(entity =>
        {
            entity.HasKey(e => e.StatuErrorId).HasName("PK__VtlStatu__C5B01D0A2495817B");

            entity.ToTable("VtlStatuError", tb =>
                {
                    tb.HasTrigger("VtlStatuError_Log_D");
                    tb.HasTrigger("VtlStatuError_Log_I");
                    tb.HasTrigger("VtlStatuError_Log_U");
                });

            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FileName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.InsTime).HasColumnType("datetime");
            entity.Property(e => e.ReferenceNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StatuCode)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.StatuTime).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
*/