﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PractiaApi.Data;

#nullable disable

namespace PractiaApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221103170711_api")]
    partial class api
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PractiaApi.Model.Hospital", b =>
                {
                    b.Property<int>("HospitalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HospitalId"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Organization")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HospitalId");

                    b.ToTable("Hospitals");
                });

            modelBuilder.Entity("PractiaApi.Model.HospitalService", b =>
                {
                    b.Property<int>("HospitalId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("HospitalId", "ServiceId");

                    b.HasIndex("ServiceId");

                    b.ToTable("HospitalServices");
                });

            modelBuilder.Entity("PractiaApi.Model.Pacient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pacients");
                });

            modelBuilder.Entity("PractiaApi.Model.Record", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ResultDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("_HospitalHospitalId")
                        .HasColumnType("int");

                    b.Property<int>("_PacientId")
                        .HasColumnType("int");

                    b.Property<int>("_ServiceServiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("_HospitalHospitalId");

                    b.HasIndex("_PacientId");

                    b.HasIndex("_ServiceServiceId");

                    b.ToTable("Records");
                });

            modelBuilder.Entity("PractiaApi.Model.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceId"), 1L, 1);

                    b.Property<string>("NameService")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ServiceId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("PractiaApi.Model.HospitalService", b =>
                {
                    b.HasOne("PractiaApi.Model.Hospital", "Hospital")
                        .WithMany("HospitalServices")
                        .HasForeignKey("HospitalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PractiaApi.Model.Service", "Service")
                        .WithMany("HospitalServices")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hospital");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("PractiaApi.Model.Record", b =>
                {
                    b.HasOne("PractiaApi.Model.Hospital", "_Hospital")
                        .WithMany()
                        .HasForeignKey("_HospitalHospitalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PractiaApi.Model.Pacient", "_Pacient")
                        .WithMany("Records")
                        .HasForeignKey("_PacientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PractiaApi.Model.Service", "_Service")
                        .WithMany()
                        .HasForeignKey("_ServiceServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("_Hospital");

                    b.Navigation("_Pacient");

                    b.Navigation("_Service");
                });

            modelBuilder.Entity("PractiaApi.Model.Hospital", b =>
                {
                    b.Navigation("HospitalServices");
                });

            modelBuilder.Entity("PractiaApi.Model.Pacient", b =>
                {
                    b.Navigation("Records");
                });

            modelBuilder.Entity("PractiaApi.Model.Service", b =>
                {
                    b.Navigation("HospitalServices");
                });
#pragma warning restore 612, 618
        }
    }
}
