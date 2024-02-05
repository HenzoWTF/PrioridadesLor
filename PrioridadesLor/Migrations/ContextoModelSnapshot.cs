﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PrioridadesLor.DAL;

#nullable disable

namespace PrioridadesLor.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("PrioridadesLor.Models.Cliente", b =>
                {
                    b.Property<int>("ClientesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CelularCliente")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("DireccionCliente")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("EmailCliente")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreCliente")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RNC")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("TEXT");

                    b.Property<string>("TelefonoCliente")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ClientesID");

                    b.ToTable("clientes");
                });

            modelBuilder.Entity("PrioridadesLor.Models.Prioridades", b =>
                {
                    b.Property<int>("IdPrioridad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("DiasCompromiso")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdPrioridad");

                    b.ToTable("prioridades");
                });

            modelBuilder.Entity("PrioridadesLor.Models.Sistemas", b =>
                {
                    b.Property<int>("SistemasId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("SistemasNombres")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("SistemasId");

                    b.ToTable("sistemas");
                });

            modelBuilder.Entity("PrioridadesLor.Models.Tickets", b =>
                {
                    b.Property<int>("TicketdId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Asunto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<int>("PrioridadId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SistemasId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SolicitadoPor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TicketdId");

                    b.ToTable("tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
