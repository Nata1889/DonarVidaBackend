﻿// <auto-generated />
using System;
using BackendFinal.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackendFinal.Migrations
{
    [DbContext(typeof(BackendContext))]
    [Migration("20250122204031_CambioBaseDeDatos")]
    partial class CambioBaseDeDatos
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("BackendFinal.Models.CentroDonacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacidad")
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("CentrosDonacion");
                });

            modelBuilder.Entity("BackendFinal.Models.Donacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DonanteId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("FechaDonacion")
                        .HasColumnType("date");

                    b.Property<int>("ProgramaDonacionId")
                        .HasColumnType("int");

                    b.Property<string>("TipoDonacion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("DonanteId");

                    b.HasIndex("ProgramaDonacionId");

                    b.ToTable("Donaciones");
                });

            modelBuilder.Entity("BackendFinal.Models.Donante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Contacto")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DNI")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FactorRH")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("FechaNacimiento")
                        .HasColumnType("date");

                    b.Property<string>("GrupoSanguineo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Donantes");
                });

            modelBuilder.Entity("BackendFinal.Models.ProgramaDonacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CentroDonacionId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("FechaFin")
                        .HasColumnType("date");

                    b.Property<DateOnly>("FechaInicio")
                        .HasColumnType("date");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TipoSangreSolicitada")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CentroDonacionId");

                    b.ToTable("ProgramasDonacion");
                });

            modelBuilder.Entity("BackendFinal.Models.Donacion", b =>
                {
                    b.HasOne("BackendFinal.Models.Donante", "Donante")
                        .WithMany()
                        .HasForeignKey("DonanteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackendFinal.Models.ProgramaDonacion", "ProgramaDonacion")
                        .WithMany()
                        .HasForeignKey("ProgramaDonacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Donante");

                    b.Navigation("ProgramaDonacion");
                });

            modelBuilder.Entity("BackendFinal.Models.ProgramaDonacion", b =>
                {
                    b.HasOne("BackendFinal.Models.CentroDonacion", "CentroDonacion")
                        .WithMany()
                        .HasForeignKey("CentroDonacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CentroDonacion");
                });
#pragma warning restore 612, 618
        }
    }
}
