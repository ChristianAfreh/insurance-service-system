using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InsuranceServiceApp.Models.Data
{
    public partial class InsuranceSystemDBContext : DbContext
    {
        public InsuranceSystemDBContext()
        {
        }

        public InsuranceSystemDBContext(DbContextOptions<InsuranceSystemDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Insurer> Insurers { get; set; } = null!;
        public virtual DbSet<InsurerType> InsurerTypes { get; set; } = null!;
        public virtual DbSet<Invoice> Invoices { get; set; } = null!;
        public virtual DbSet<Make> Makes { get; set; } = null!;
        public virtual DbSet<Model> Models { get; set; } = null!;
        public virtual DbSet<Region> Regions { get; set; } = null!;
        public virtual DbSet<ServiceRequest> ServiceRequests { get; set; } = null!;
        public virtual DbSet<ServiceRequestStatus> ServiceRequestStatuses { get; set; } = null!;
        public virtual DbSet<ServiceRequestType> ServiceRequestTypes { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<Vehicle> Vehicles { get; set; } = null!;
        public virtual DbSet<VehicleType> VehicleTypes { get; set; } = null!;
        public virtual DbSet<Zone> Zones { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.ClientId)
                    .HasName("PK1")
                    .IsClustered(false);

                entity.ToTable("Client");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.Cellphone).HasMaxLength(20);

                entity.Property(e => e.CreateAppUserId).HasColumnName("CreateAppUserID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(30);

                entity.Property(e => e.Employer).HasMaxLength(250);

                entity.Property(e => e.LastDateUpdated).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateAppUserId).HasColumnName("LastUpdateAppUserID");

                entity.Property(e => e.Othername).HasMaxLength(250);

                entity.Property(e => e.PostalAddress).HasMaxLength(250);

                entity.Property(e => e.ResidentialAddress).HasMaxLength(250);

                entity.Property(e => e.Surname).HasMaxLength(250);

                entity.Property(e => e.ZoneId).HasColumnName("ZoneID");

                entity.HasOne(d => d.Zone)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.ZoneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefZone9");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.CountryId)
                    .HasName("PK9")
                    .IsClustered(false);

                entity.ToTable("Country");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.CreatedAppUserId).HasColumnName("CreatedAppUserID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastDateUpdated).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateAppUserId).HasColumnName("LastUpdateAppUserID");

                entity.Property(e => e.Name).HasMaxLength(250);
            });

            modelBuilder.Entity<Insurer>(entity =>
            {
                entity.HasKey(e => e.InsurerId)
                    .HasName("PK3")
                    .IsClustered(false);

                entity.ToTable("Insurer");

                entity.Property(e => e.InsurerId).HasColumnName("InsurerID");

                entity.Property(e => e.Cellphone).HasMaxLength(20);

                entity.Property(e => e.CreateAppUserId).HasColumnName("CreateAppUserID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(30);

                entity.Property(e => e.InsurerTypeId).HasColumnName("InsurerTypeID");

                entity.Property(e => e.LastDateUpdated).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateAppUserId).HasColumnName("LastUpdateAppUserID");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.PostalAddress).HasMaxLength(250);

                entity.Property(e => e.ResidentialAddress).HasMaxLength(250);

                entity.HasOne(d => d.InsurerType)
                    .WithMany(p => p.Insurers)
                    .HasForeignKey(d => d.InsurerTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefInsurerType2");
            });

            modelBuilder.Entity<InsurerType>(entity =>
            {
                entity.HasKey(e => e.InsurerTypeId)
                    .HasName("PK6")
                    .IsClustered(false);

                entity.ToTable("InsurerType");

                entity.Property(e => e.InsurerTypeId).HasColumnName("InsurerTypeID");

                entity.Property(e => e.CreateAppUserId).HasColumnName("CreateAppUserID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastDateUpdated).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateAppUserId).HasColumnName("LastUpdateAppUserID");

                entity.Property(e => e.Name).HasMaxLength(250);
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.InvoiceId)
                    .HasName("PK5")
                    .IsClustered(false);

                entity.ToTable("Invoice");

                entity.Property(e => e.InvoiceId).HasColumnName("InvoiceID");

                entity.Property(e => e.ClientAddress).HasMaxLength(250);

                entity.Property(e => e.ClientCellphone).HasMaxLength(20);

                entity.Property(e => e.ClientEmail).HasMaxLength(30);

                entity.Property(e => e.ClientName).HasMaxLength(250);

                entity.Property(e => e.CreateAppUserId).HasColumnName("CreateAppUserID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.InsurerAddress).HasMaxLength(250);

                entity.Property(e => e.InsurerName).HasMaxLength(250);

                entity.Property(e => e.InvoiceNo).HasMaxLength(30);

                entity.Property(e => e.LastDateUpdated).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateAppUserId).HasColumnName("LastUpdateAppUserID");

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefServiceRequest8");
            });

            modelBuilder.Entity<Make>(entity =>
            {
                entity.HasKey(e => e.MakeId)
                    .HasName("PK13")
                    .IsClustered(false);

                entity.ToTable("Make");

                entity.Property(e => e.MakeId).HasColumnName("MakeID");

                entity.Property(e => e.CreateAppUserId).HasColumnName("CreateAppUserID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastDateUpdated).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateAppUserId).HasColumnName("LastUpdateAppUserID");

                entity.Property(e => e.Name).HasMaxLength(250);
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.HasKey(e => e.ModelId)
                    .HasName("PK14")
                    .IsClustered(false);

                entity.ToTable("Model");

                entity.Property(e => e.ModelId).HasColumnName("ModelID");

                entity.Property(e => e.CreateAppUserId).HasColumnName("CreateAppUserID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastDateUpdated).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateAppUserId).HasColumnName("LastUpdateAppUserID");

                entity.Property(e => e.MakeId).HasColumnName("MakeID");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.HasOne(d => d.Make)
                    .WithMany(p => p.Models)
                    .HasForeignKey(d => d.MakeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefMake15");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.HasKey(e => e.RegionId)
                    .HasName("PK10")
                    .IsClustered(false);

                entity.ToTable("Region");

                entity.Property(e => e.RegionId).HasColumnName("RegionID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.CreateAppUserId).HasColumnName("CreateAppUserID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastDateUpdated).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateAppUserId).HasColumnName("LastUpdateAppUserID");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Regions)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefCountry11");
            });

            modelBuilder.Entity<ServiceRequest>(entity =>
            {
                entity.HasKey(e => e.RequestId)
                    .HasName("PK4")
                    .IsClustered(false);

                entity.ToTable("ServiceRequest");

                entity.Property(e => e.RequestId)
                    .ValueGeneratedNever()
                    .HasColumnName("RequestID");

                entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.CreateAppUserId).HasColumnName("CreateAppUserID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.InsurerId).HasColumnName("InsurerID");

                entity.Property(e => e.LastDateUpdated).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateAppUserId).HasColumnName("LastUpdateAppUserID");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.RequestTypeId).HasColumnName("RequestTypeID");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ServiceRequests)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefClient3");

                entity.HasOne(d => d.Insurer)
                    .WithMany(p => p.ServiceRequests)
                    .HasForeignKey(d => d.InsurerId)
                    .HasConstraintName("RefInsurer5");

                entity.HasOne(d => d.RequestType)
                    .WithMany(p => p.ServiceRequests)
                    .HasForeignKey(d => d.RequestTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefServiceRequestType7");
            });

            modelBuilder.Entity<ServiceRequestStatus>(entity =>
            {
                entity.HasKey(e => e.ServiceRequestStatusId)
                    .HasName("PK12")
                    .IsClustered(false);

                entity.ToTable("ServiceRequestStatus");

                entity.Property(e => e.ServiceRequestStatusId).HasColumnName("ServiceRequestStatusID");

                entity.Property(e => e.CreateAppUserId).HasColumnName("CreateAppUserID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastDateUpdated).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateAppUserId).HasColumnName("LastUpdateAppUserID");

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.ServiceRequestStatuses)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefServiceRequest12");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.ServiceRequestStatuses)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefStatus13");
            });

            modelBuilder.Entity<ServiceRequestType>(entity =>
            {
                entity.HasKey(e => e.RequestTypeId)
                    .HasName("PK7")
                    .IsClustered(false);

                entity.ToTable("ServiceRequestType");

                entity.Property(e => e.RequestTypeId).HasColumnName("RequestTypeID");

                entity.Property(e => e.CreateAppUserId).HasColumnName("CreateAppUserID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastDateUpdated).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateAppUserId).HasColumnName("LastUpdateAppUserID");

                entity.Property(e => e.Title).HasMaxLength(250);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("PK11")
                    .IsClustered(false);

                entity.ToTable("Status");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.CreateAppUserId).HasColumnName("CreateAppUserID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastDateUpdated).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateAppUserId).HasColumnName("LastUpdateAppUserID");

                entity.Property(e => e.Name).HasMaxLength(250);
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasKey(e => e.VehicleId)
                    .HasName("PK2")
                    .IsClustered(false);

                entity.ToTable("Vehicle");

                entity.Property(e => e.VehicleId).HasColumnName("VehicleID");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.Colour).HasMaxLength(250);

                entity.Property(e => e.CreateAppUserId).HasColumnName("CreateAppUserID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastDateUpdated).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateAppUserId).HasColumnName("LastUpdateAppUserID");

                entity.Property(e => e.ModelId).HasColumnName("ModelID");

                entity.Property(e => e.RegistrationNo).HasMaxLength(250);

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("RefClient14");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.ModelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefModel16");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("RefVehicleType17");
            });

            modelBuilder.Entity<VehicleType>(entity =>
            {
                entity.HasKey(e => e.TypeId)
                    .HasName("PK15")
                    .IsClustered(false);

                entity.ToTable("VehicleType");

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.Property(e => e.CreateAppUserId).HasColumnName("CreateAppUserID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastDateUpdated).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateAppUserId).HasColumnName("LastUpdateAppUserID");

                entity.Property(e => e.TypeName).HasMaxLength(250);
            });

            modelBuilder.Entity<Zone>(entity =>
            {
                entity.HasKey(e => e.ZoneId)
                    .HasName("PK8")
                    .IsClustered(false);

                entity.ToTable("Zone");

                entity.Property(e => e.ZoneId).HasColumnName("ZoneID");

                entity.Property(e => e.CreateAppUserId).HasColumnName("CreateAppUserID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastDateUpdated).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateAppUserId).HasColumnName("LastUpdateAppUserID");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.RegionId).HasColumnName("RegionID");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Zones)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefRegion10");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
