﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecruitmentService.Persistance;

#nullable disable

namespace RecruitmentService.Persistance.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240420154450_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RecruitmentService.Domain.Entities.Candidate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("About")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BitrhDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmploymentType")
                        .HasColumnType("int");

                    b.Property<int>("Expirience")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ScheduleType")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Candidates");
                });

            modelBuilder.Entity("RecruitmentService.Domain.Entities.Job", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CandidateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Expirience")
                        .HasColumnType("int");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("RecruitmentService.Domain.Entities.Offer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("VacancyId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("VacancyId");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("RecruitmentService.Domain.Entities.Requirement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("VacancyId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("VacancyId");

                    b.ToTable("Requirements");
                });

            modelBuilder.Entity("RecruitmentService.Domain.Entities.Response", b =>
                {
                    b.Property<Guid>("VacancyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CandidateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("VacancyId", "CandidateId");

                    b.HasIndex("CandidateId");

                    b.ToTable("Responses");
                });

            modelBuilder.Entity("RecruitmentService.Domain.Entities.Vacancy", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("About")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExpirienceYearsFrom")
                        .HasColumnType("int");

                    b.Property<int>("ExpirienceYearsTo")
                        .HasColumnType("int");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SalaryFrom")
                        .HasColumnType("int");

                    b.Property<int>("SalaryTo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Vacancies");
                });

            modelBuilder.Entity("RecruitmentService.Domain.Entities.Job", b =>
                {
                    b.HasOne("RecruitmentService.Domain.Entities.Candidate", "Candidate")
                        .WithMany("Jobs")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");
                });

            modelBuilder.Entity("RecruitmentService.Domain.Entities.Offer", b =>
                {
                    b.HasOne("RecruitmentService.Domain.Entities.Vacancy", "Vacancy")
                        .WithMany("Offers")
                        .HasForeignKey("VacancyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vacancy");
                });

            modelBuilder.Entity("RecruitmentService.Domain.Entities.Requirement", b =>
                {
                    b.HasOne("RecruitmentService.Domain.Entities.Vacancy", "Vacancy")
                        .WithMany("Requirements")
                        .HasForeignKey("VacancyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vacancy");
                });

            modelBuilder.Entity("RecruitmentService.Domain.Entities.Response", b =>
                {
                    b.HasOne("RecruitmentService.Domain.Entities.Candidate", "Candidate")
                        .WithMany("Responses")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RecruitmentService.Domain.Entities.Vacancy", "Vacancy")
                        .WithMany("Responses")
                        .HasForeignKey("VacancyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");

                    b.Navigation("Vacancy");
                });

            modelBuilder.Entity("RecruitmentService.Domain.Entities.Candidate", b =>
                {
                    b.Navigation("Jobs");

                    b.Navigation("Responses");
                });

            modelBuilder.Entity("RecruitmentService.Domain.Entities.Vacancy", b =>
                {
                    b.Navigation("Offers");

                    b.Navigation("Requirements");

                    b.Navigation("Responses");
                });
#pragma warning restore 612, 618
        }
    }
}