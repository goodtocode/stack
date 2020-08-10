﻿
//https://www.syncfusion.com/blogs/post/build-crud-application-with-asp-net-core-entity-framework-visual-studio-2019.aspx
using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace GoodToCode.Subjects.Models
{
    public partial class SubjectsDbContext : DbContext, ISubjectsDbContext
    {
        public SubjectsDbContext()
        {
        }

        public SubjectsDbContext(DbContextOptions<SubjectsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Business> Business { get; set; }
        public virtual DbSet<Detail> Detail { get; set; }
        public virtual DbSet<DetailType> DetailType { get; set; }
        public virtual DbSet<Entity> Entity { get; set; }
        public virtual DbSet<EntityAppointment> EntityAppointment { get; set; }
        public virtual DbSet<EntityDetail> EntityDetail { get; set; }
        public virtual DbSet<EntityLocation> EntityLocation { get; set; }
        public virtual DbSet<EntityOption> EntityOption { get; set; }
        public virtual DbSet<EntityTimeRecurring> EntityTimeRecurring { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Government> Government { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<ItemGroup> ItemGroup { get; set; }
        public virtual DbSet<ItemType> ItemType { get; set; }
        public virtual DbSet<Option> Option { get; set; }
        public virtual DbSet<OptionGroup> OptionGroup { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Resource> Resource { get; set; }
        public virtual DbSet<ResourceItem> ResourceItem { get; set; }
        public virtual DbSet<ResourcePerson> ResourcePerson { get; set; }
        public virtual DbSet<ResourceTimeRecurring> ResourceTimeRecurring { get; set; }
        public virtual DbSet<ResourceType> ResourceType { get; set; }
        public virtual DbSet<Venture> Venture { get; set; }
        public virtual DbSet<VentureAppointment> VentureAppointment { get; set; }
        public virtual DbSet<VentureDetail> VentureDetail { get; set; }
        public virtual DbSet<VentureEntityOption> VentureEntityOption { get; set; }
        public virtual DbSet<VentureLocation> VentureLocation { get; set; }
        public virtual DbSet<VentureOption> VentureOption { get; set; }
        public virtual DbSet<VentureResource> VentureResource { get; set; }
        public virtual DbSet<VentureSchedule> VentureSchedule { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "Server=tcp:goodtocodestack.database.windows.net,1433;Initial Catalog=StackData;Persist Security Info=False;User ID=LocalAdmin;Password=1202cc89-cb6f-453a-ac7e-550b3b5d2d0c;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Business>(entity =>
            {
                entity.ToTable("Business", "Subjects");
                entity.HasIndex(e => e.BusinessKey)
                    .HasName("IX_Business_Key")
                    .IsUnique();

                entity.Property(e => e.BusinessName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.TaxNumber)
                    .IsRequired()
                    .HasMaxLength(20);

            });

            modelBuilder.Entity<Detail>(entity =>
            {
                entity.ToTable("Detail", "Subjects");

                entity.HasIndex(e => e.DetailKey)
                    .HasName("IX_Detail_Key")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DetailData)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<DetailType>(entity =>
            {
                entity.ToTable("DetailType", "Subjects");

                entity.HasIndex(e => e.DetailTypeKey)
                    .HasName("IX_DetailType_Key")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DetailTypeDescription)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.DetailTypeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Entity>(entity =>
            {
                entity.ToTable("Entity", "Subjects");

                entity.HasIndex(e => e.EntityKey)
                    .HasName("IX_EntityLocation_Entity")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<EntityAppointment>(entity =>
            {
                entity.ToTable("EntityAppointment", "Subjects");

                entity.HasIndex(e => e.EntityAppointmentKey)
                    .HasName("IX_EntityAppointment_Key")
                    .IsUnique();

                entity.HasIndex(e => new { e.EntityKey, e.AppointmentKey })
                    .HasName("IX_EntityAppointment_All")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<EntityDetail>(entity =>
            {
                entity.ToTable("EntityDetail", "Subjects");

                entity.HasIndex(e => e.EntityDetailKey)
                    .HasName("IX_EntityDetail_Key")
                    .IsUnique();

                entity.HasIndex(e => new { e.EntityKey, e.EntityDetailKey })
                    .HasName("IX_EntityDetail_All")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<EntityLocation>(entity =>
            {
                entity.ToTable("EntityLocation", "Subjects");

                entity.HasIndex(e => new { e.EntityKey, e.LocationKey })
                    .HasName("IX_EntityLocation_All")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<EntityOption>(entity =>
            {
                entity.ToTable("EntityOption", "Subjects");

                entity.HasIndex(e => new { e.EntityKey, e.OptionKey })
                    .HasName("IX_EntityOption_All")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<EntityTimeRecurring>(entity =>
            {
                entity.ToTable("EntityTimeRecurring", "Subjects");

                entity.HasIndex(e => e.EntityTimeRecurringKey)
                    .HasName("IX_EntityTimeRecurring_Key")
                    .IsUnique();

                entity.HasIndex(e => new { e.EntityKey, e.TimeRecurringKey })
                    .HasName("IX_EntityTimeRecurring_All")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DayName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.TimeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.ToTable("Gender", "Subjects");

                entity.HasIndex(e => e.GenderCode)
                    .HasName("IX_Gender_Code")
                    .IsUnique();

                entity.HasCheckConstraint("CC_Gender_GenderCode", "GenderCode in ('M', 'F', 'N/A', 'U/K')");

                entity.HasIndex(e => e.GenderKey)
                    .HasName("IX_Gender_Key")
                    .IsUnique();

                entity.Property(e => e.GenderCode).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.GenderCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.GenderName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Government>(entity =>
            {
                entity.ToTable("Government", "Subjects");

                entity.HasIndex(e => e.GovernmentKey)
                    .HasName("IX_Government_Entity")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.GovernmentName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("Item", "Subjects");

                entity.HasIndex(e => e.ItemKey)
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ItemDescription)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ItemGroup>(entity =>
            {
                entity.ToTable("ItemGroup", "Subjects");

                entity.HasIndex(e => e.ItemGroupKey)
                    .HasName("IX_ItemGroup_Key")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ItemGroupDescription)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ItemGroupName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ItemType>(entity =>
            {
                entity.ToTable("ItemType", "Subjects");

                entity.HasIndex(e => e.ItemTypeKey)
                    .HasName("IX_ItemType_Key")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ItemTypeDescription)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ItemTypeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Option>(entity =>
            {
                entity.ToTable("Option", "Subjects");

                entity.HasIndex(e => e.OptionKey)
                    .IsUnique();

                entity.HasIndex(e => new { e.OptionGroupKey, e.OptionCode })
                    .HasName("IX_Option_OptionCode")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.OptionCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.OptionDescription)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.OptionName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<OptionGroup>(entity =>
            {
                entity.ToTable("OptionGroup", "Subjects");

                entity.HasIndex(e => e.OptionGroupCode)
                    .HasName("IX_Option_OptionGroupCode")
                    .IsUnique();

                entity.HasIndex(e => e.OptionGroupKey)
                    .HasName("IX_Option_OptionGroupKey")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.OptionGroupCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.OptionGroupDescription)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.OptionGroupName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person", "Subjects");

                entity.HasIndex(e => e.PersonKey)
                    .HasName("IX_Person_Entity")
                    .IsUnique();

                entity.HasIndex(e => new { e.FirstName, e.MiddleName, e.LastName, e.BirthDate })
                    .HasName("IX_Person_All");

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.GenderCode).HasMaxLength(3);
                entity.HasCheckConstraint("CC_Person_GenderCode", "GenderCode in ('M', 'F', 'N/A', 'U/K')");
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.ToTable("Resource", "Subjects");

                entity.HasIndex(e => e.ResourceKey)
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ResourceDescription)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ResourceName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ResourceItem>(entity =>
            {
                entity.ToTable("ResourceItem", "Subjects");

                entity.HasIndex(e => e.ItemKey)
                    .HasName("IX_ResourceItem_Item");

                entity.HasIndex(e => e.ResourceItemKey)
                    .HasName("IX_ResourceItem_Key")
                    .IsUnique();

                entity.HasIndex(e => e.ResourceKey)
                    .HasName("IX_ResourceItem_Resource");

                entity.HasIndex(e => new { e.ResourceKey, e.ItemKey })
                    .HasName("IX_ResourceItem_All")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ResourcePerson>(entity =>
            {
                entity.ToTable("ResourcePerson", "Subjects");

                entity.HasIndex(e => e.PersonKey)
                    .HasName("IX_ResourcePerson_Person");

                entity.HasIndex(e => e.ResourceKey)
                    .HasName("IX_ResourcePerson_Resource");

                entity.HasIndex(e => e.ResourcePersonKey)
                    .HasName("IX_ResourcePerson_Key")
                    .IsUnique();

                entity.HasIndex(e => new { e.ResourceKey, e.PersonKey })
                    .HasName("IX_ResourcePerson_All")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ResourceTimeRecurring>(entity =>
            {
                entity.ToTable("ResourceTimeRecurring", "Subjects");

                entity.HasIndex(e => e.ResourceTimeRecurringKey)
                    .HasName("IX_ResourceTimeRecurring_Resource")
                    .IsUnique();

                entity.HasIndex(e => new { e.ResourceKey, e.TimeRecurringKey })
                    .HasName("IX_ResourceTimeRecurring_All")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DayName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.TimeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ResourceType>(entity =>
            {
                entity.ToTable("ResourceType", "Subjects");

                entity.HasIndex(e => e.ResourceTypeKey)
                    .HasName("IX_ResourceType_Key")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ResourceTypeDescription)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ResourceTypeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Venture>(entity =>
            {
                entity.ToTable("Venture", "Subjects");

                entity.HasIndex(e => e.VentureKey)
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.VentureDescription)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.VentureName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.VentureSlogan)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<VentureAppointment>(entity =>
            {
                entity.ToTable("VentureAppointment", "Subjects");

                entity.HasIndex(e => e.VentureAppointmentKey)
                    .HasName("IX_VentureAppointment_Key")
                    .IsUnique();

                entity.HasIndex(e => new { e.VentureKey, e.AppointmentKey })
                    .HasName("IX_VentureAppointment_All")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<VentureDetail>(entity =>
            {
                entity.ToTable("VentureDetail", "Subjects");

                entity.HasIndex(e => e.VentureDetailKey)
                    .HasName("IX_VentureDetail_Key")
                    .IsUnique();

                entity.HasIndex(e => new { e.VentureKey, e.VentureDetailKey })
                    .HasName("IX_VentureDetail_All")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<VentureEntityOption>(entity =>
            {
                entity.ToTable("VentureEntityOption", "Subjects");

                entity.HasIndex(e => e.VentureEntityOptionKey)
                    .HasName("IX_VentureEntityOption_Key")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<VentureLocation>(entity =>
            {
                entity.ToTable("VentureLocation", "Subjects");

                entity.HasIndex(e => e.VentureLocationKey)
                    .HasName("IX_VentureLocation_Key")
                    .IsUnique();

                entity.HasIndex(e => new { e.VentureKey, e.LocationKey })
                    .HasName("IX_VentureLocation_All")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<VentureOption>(entity =>
            {
                entity.ToTable("VentureOption", "Subjects");

                entity.HasIndex(e => new { e.VentureKey, e.OptionKey })
                    .HasName("IX_VentureOption_All")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<VentureResource>(entity =>
            {
                entity.ToTable("VentureResource", "Subjects");

                entity.HasIndex(e => e.VentureResourceKey)
                    .HasName("IX_VentureResource_Key")
                    .IsUnique();

                entity.HasIndex(e => new { e.VentureKey, e.ResourceKey })
                    .HasName("IX_VentureResource_All")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<VentureSchedule>(entity =>
            {
                entity.ToTable("VentureSchedule", "Subjects");

                entity.HasIndex(e => e.VentureScheduleKey)
                    .HasName("IX_VentureSchedule_Key")
                    .IsUnique();

                entity.HasIndex(e => new { e.VentureKey, e.ScheduleKey })
                    .HasName("IX_VentureSchedule_All")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
