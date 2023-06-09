﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using csi.asp.net.core.data.App.Context;

#nullable disable

namespace csi.asp.net.core.data.Migrations
{
    [DbContext(typeof(CSI_AppContext))]
    partial class CSI_AppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("csi.asp.net.core.model.model.Beneficiary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("HouseholdId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("HouseholdId");

                    b.ToTable("Beneficiary");
                });

            modelBuilder.Entity("csi.asp.net.core.model.model.CollaboratorRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("CollaboratorRole");
                });

            modelBuilder.Entity("csi.asp.net.core.model.model.FamilyHead", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("FamilyHead");
                });

            modelBuilder.Entity("csi.asp.net.core.model.model.FamilyOriginRef", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("FamilyOriginRef");
                });

            modelBuilder.Entity("csi.asp.net.core.model.model.Household", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Block")
                        .IsRequired()
                        .HasColumnType("varchar(5)");

                    b.Property<string>("ClosePlaceToHome")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FamilyHeadId")
                        .HasColumnType("int");

                    b.Property<int?>("FamilyOriginRefId")
                        .HasColumnType("int");

                    b.Property<string>("FamilyPhoneNumber")
                        .IsRequired()
                        .HasColumnType("varchar(9)");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("NeighborhoodName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("OtherFamilyOriginRef")
                        .HasColumnType("varchar(20)");

                    b.Property<int>("PartnerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("FamilyHeadId");

                    b.HasIndex("FamilyOriginRefId");

                    b.HasIndex("PartnerId");

                    b.ToTable("Household");
                });

            modelBuilder.Entity("csi.asp.net.core.model.model.Partner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CollaboratorRoleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("PartnerId")
                        .HasColumnType("int");

                    b.Property<int>("SiteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CollaboratorRoleId");

                    b.HasIndex("PartnerId");

                    b.HasIndex("SiteId");

                    b.ToTable("Partner");
                });

            modelBuilder.Entity("csi.asp.net.core.model.model.Site", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Site");
                });

            modelBuilder.Entity("csi.asp.net.core.model.model.Beneficiary", b =>
                {
                    b.HasOne("csi.asp.net.core.model.model.Household", "Household")
                        .WithMany("Beneficiaries")
                        .HasForeignKey("HouseholdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Household");
                });

            modelBuilder.Entity("csi.asp.net.core.model.model.Household", b =>
                {
                    b.HasOne("csi.asp.net.core.model.model.FamilyHead", "FamilyHead")
                        .WithMany()
                        .HasForeignKey("FamilyHeadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("csi.asp.net.core.model.model.FamilyOriginRef", "FamilyOriginRef")
                        .WithMany()
                        .HasForeignKey("FamilyOriginRefId");

                    b.HasOne("csi.asp.net.core.model.model.Partner", "Partner")
                        .WithMany()
                        .HasForeignKey("PartnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FamilyHead");

                    b.Navigation("FamilyOriginRef");

                    b.Navigation("Partner");
                });

            modelBuilder.Entity("csi.asp.net.core.model.model.Partner", b =>
                {
                    b.HasOne("csi.asp.net.core.model.model.CollaboratorRole", "CollaboratorRole")
                        .WithMany()
                        .HasForeignKey("CollaboratorRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("csi.asp.net.core.model.model.Partner", "Superior")
                        .WithMany()
                        .HasForeignKey("PartnerId");

                    b.HasOne("csi.asp.net.core.model.model.Site", "Site")
                        .WithMany()
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CollaboratorRole");

                    b.Navigation("Site");

                    b.Navigation("Superior");
                });

            modelBuilder.Entity("csi.asp.net.core.model.model.Household", b =>
                {
                    b.Navigation("Beneficiaries");
                });
#pragma warning restore 612, 618
        }
    }
}
