﻿// <auto-generated />
using System;
using EmployeeService.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EmployeeService.Persistence.Migrations
{
    [DbContext(typeof(EmployeeServiceDbContext))]
    [Migration("20240510190944_AddedEmployeeStatus")]
    partial class AddedEmployeeStatus
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EmployeeService.Models.Entities.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("EmployeeService.Models.Entities.Country", b =>
                {
                    b.Property<int>("ISOCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ISOCode"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UrlPng")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UrlSvg")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ISOCode");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("EmployeeService.Models.Entities.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AvatarUrl")
                        .HasColumnType("text");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uuid");

                    b.Property<int?>("CountryCode")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("EmployeeStatus")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Patronimic")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<int>("RoleType")
                        .HasColumnType("integer");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("CountryCode");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EmployeeService.Models.Entities.EmployeeUnit", b =>
                {
                    b.Property<Guid>("UnitId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uuid");

                    b.HasKey("UnitId", "EmployeeId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeUnits");
                });

            modelBuilder.Entity("EmployeeService.Models.Entities.Unit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("LeadId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("ParentUnitId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("LeadId");

                    b.HasIndex("ParentUnitId");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("EmployeeService.Models.Entities.Employee", b =>
                {
                    b.HasOne("EmployeeService.Models.Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployeeService.Models.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryCode");

                    b.Navigation("Company");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("EmployeeService.Models.Entities.EmployeeUnit", b =>
                {
                    b.HasOne("EmployeeService.Models.Entities.Employee", "Employee")
                        .WithMany("EmployeeUnits")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployeeService.Models.Entities.Unit", "Unit")
                        .WithMany("EmployeeUnits")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("EmployeeService.Models.Entities.Unit", b =>
                {
                    b.HasOne("EmployeeService.Models.Entities.Company", "Company")
                        .WithMany("Units")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployeeService.Models.Entities.Employee", "Lead")
                        .WithMany("LeadingUnits")
                        .HasForeignKey("LeadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployeeService.Models.Entities.Unit", "ParentUnit")
                        .WithMany("ChildUnits")
                        .HasForeignKey("ParentUnitId");

                    b.Navigation("Company");

                    b.Navigation("Lead");

                    b.Navigation("ParentUnit");
                });

            modelBuilder.Entity("EmployeeService.Models.Entities.Company", b =>
                {
                    b.Navigation("Units");
                });

            modelBuilder.Entity("EmployeeService.Models.Entities.Employee", b =>
                {
                    b.Navigation("EmployeeUnits");

                    b.Navigation("LeadingUnits");
                });

            modelBuilder.Entity("EmployeeService.Models.Entities.Unit", b =>
                {
                    b.Navigation("ChildUnits");

                    b.Navigation("EmployeeUnits");
                });
#pragma warning restore 612, 618
        }
    }
}
