﻿// <auto-generated />
using System;
using Infraestructure.Persistance.PostgresSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infraestructure.Persistance.PostgresSQL.Migrations
{
    [DbContext(typeof(CenturyContext))]
    partial class CenturyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Domain.Entities.Activo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Año");

                    b.Property<string>("Chasis");

                    b.Property<string>("Dominio")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<Guid>("EmpleadoResponsableID");

                    b.Property<DateTime>("FechaCompra");

                    b.Property<string>("Motor");

                    b.Property<int>("NumeroInterno");

                    b.Property<int>("TipoActivoId");

                    b.Property<int>("TipoModeloId");

                    b.Property<string>("Ubicacion")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.HasIndex("Dominio")
                        .IsUnique();

                    b.HasIndex("NumeroInterno")
                        .IsUnique();

                    b.HasIndex("TipoActivoId");

                    b.HasIndex("TipoModeloId");

                    b.ToTable("Activos");
                });

            modelBuilder.Entity("Domain.Entities.DocumentacionActivo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ActivoId");

                    b.Property<DateTime>("FechaVencimiento");

                    b.Property<string>("TipoDocumentacionActivoId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ActivoId");

                    b.HasIndex("TipoDocumentacionActivoId");

                    b.HasIndex("FechaVencimiento", "ActivoId");

                    b.ToTable("DocumentacionesActivo");
                });

            modelBuilder.Entity("Domain.Entities.Inspeccion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ActivoId");

                    b.Property<Guid>("ListadoInspeccionId");

                    b.Property<string>("Observacion");

                    b.Property<string>("TipoInspeccionId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ActivoId");

                    b.HasIndex("ListadoInspeccionId");

                    b.HasIndex("TipoInspeccionId");

                    b.ToTable("Inspecciones");
                });

            modelBuilder.Entity("Domain.Entities.InspeccionEstado", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Fecha");

                    b.Property<Guid>("InspeccionId");

                    b.Property<string>("Observacion");

                    b.Property<int>("TipoEstadoInspeccionId");

                    b.Property<string>("Ubicacion");

                    b.Property<string>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("InspeccionId");

                    b.HasIndex("TipoEstadoInspeccionId");

                    b.ToTable("Inspecciones_Estados");
                });

            modelBuilder.Entity("Domain.Entities.Inspeccion_ItemControl_Valores", b =>
                {
                    b.Property<Guid>("InspeccionId");

                    b.Property<int>("ItemControlId");

                    b.Property<string>("Observacion");

                    b.Property<int>("Orden");

                    b.Property<string>("TipoAccionRecomendadaId")
                        .IsRequired();

                    b.Property<int>("TipoLecturaItemInspeccionId");

                    b.Property<int>("ValorLectura");

                    b.HasKey("InspeccionId", "ItemControlId");

                    b.HasIndex("ItemControlId");

                    b.HasIndex("TipoAccionRecomendadaId");

                    b.HasIndex("TipoLecturaItemInspeccionId");

                    b.ToTable("Inspecciones_ItemsControl_Valores");
                });

            modelBuilder.Entity("Domain.Entities.ItemControl", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ListadoInspeccionId");

                    b.Property<string>("Nombre")
                        .HasMaxLength(300);

                    b.Property<bool>("RealizarLectura");

                    b.Property<string>("TipoRubroItemControlId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ListadoInspeccionId");

                    b.HasIndex("TipoRubroItemControlId");

                    b.ToTable("ItemsControl");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nombre = "Nivel Aceite Motor",
                            RealizarLectura = true,
                            TipoRubroItemControlId = "1"
                        },
                        new
                        {
                            Id = 2,
                            Nombre = "Carga de la bateria",
                            RealizarLectura = true,
                            TipoRubroItemControlId = "2"
                        });
                });

            modelBuilder.Entity("Domain.Entities.ListadoInspeccion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion");

                    b.Property<string>("TipoMedidaPeriodicidadId")
                        .IsRequired();

                    b.Property<int>("UnidadPeriodicidad");

                    b.HasKey("Id");

                    b.HasIndex("TipoMedidaPeriodicidadId");

                    b.ToTable("ListadosInspeccion");
                });

            modelBuilder.Entity("Domain.Entities.ListadoInspeccion_TipoActivo", b =>
                {
                    b.Property<Guid>("ListadoInspeccionId");

                    b.Property<int?>("TipoActivoId");

                    b.HasKey("ListadoInspeccionId", "TipoActivoId");

                    b.HasIndex("TipoActivoId");

                    b.ToTable("ListadosInspeccion_TipoActivo");
                });

            modelBuilder.Entity("Domain.Entities.TipoAccionRecomendada", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion")
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.ToTable("TiposAccionesRecomendada");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Descripcion = "Reparar"
                        },
                        new
                        {
                            Id = "2",
                            Descripcion = "Cambiar"
                        },
                        new
                        {
                            Id = "3",
                            Descripcion = "Proveer"
                        },
                        new
                        {
                            Id = "4",
                            Descripcion = "No Aplica"
                        },
                        new
                        {
                            Id = "5",
                            Descripcion = "Ninguna"
                        });
                });

            modelBuilder.Entity("Domain.Entities.TipoActivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion")
                        .HasMaxLength(300);

                    b.Property<bool>("DominioObligatorio");

                    b.Property<Guid?>("ListadoInspeccionId");

                    b.HasKey("Id");

                    b.HasIndex("ListadoInspeccionId");

                    b.ToTable("TiposActivo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Camioneta",
                            DominioObligatorio = true
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "Perfodaora",
                            DominioObligatorio = false
                        });
                });

            modelBuilder.Entity("Domain.Entities.TipoDocumentacionActivo", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion")
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.ToTable("TiposDocumentacionActivo");
                });

            modelBuilder.Entity("Domain.Entities.TipoEstadoInspeccion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion");

                    b.HasKey("Id");

                    b.ToTable("TipoEstadoInspeccion");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Realizado"
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "Controlado"
                        },
                        new
                        {
                            Id = 3,
                            Descripcion = "Supervisado"
                        });
                });

            modelBuilder.Entity("Domain.Entities.TipoInspeccion", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion");

                    b.HasKey("Id");

                    b.ToTable("TiposInspeccion");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Descripcion = "Inspeccion de ingreso"
                        },
                        new
                        {
                            Id = "2",
                            Descripcion = "Inspeccion de egreso"
                        },
                        new
                        {
                            Id = "3",
                            Descripcion = "Inspeccion de rutina"
                        });
                });

            modelBuilder.Entity("Domain.Entities.TipoLecturaItemInspeccion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion")
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.ToTable("TiposLecturaItemInspeccion");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Bien"
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "Mal"
                        });
                });

            modelBuilder.Entity("Domain.Entities.TipoMarca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion")
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.ToTable("TiposMarca");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Ford"
                        });
                });

            modelBuilder.Entity("Domain.Entities.TipoMedidaPeriodicidad", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion")
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.ToTable("TiposMedidaPeriodicidad");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Descripcion = "Horas"
                        },
                        new
                        {
                            Id = "2",
                            Descripcion = "Semanas"
                        });
                });

            modelBuilder.Entity("Domain.Entities.TipoModelo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion")
                        .HasMaxLength(300);

                    b.Property<int>("TipoMarcaId");

                    b.HasKey("Id");

                    b.HasIndex("TipoMarcaId");

                    b.ToTable("TiposModelo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Mustang",
                            TipoMarcaId = 1
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "F-100",
                            TipoMarcaId = 1
                        });
                });

            modelBuilder.Entity("Domain.Entities.TipoRubroItemControl", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion")
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.ToTable("TiposRubroItemsControl");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Descripcion = "Estado General"
                        },
                        new
                        {
                            Id = "2",
                            Descripcion = "Motor"
                        },
                        new
                        {
                            Id = "3",
                            Descripcion = "Seguridad"
                        });
                });

            modelBuilder.Entity("Infraestructure.Persistance.PostgresSQL.Models.ListadoInspeccion_ItemControl", b =>
                {
                    b.Property<Guid>("ListadoInspeccionId");

                    b.Property<int>("ItemControlId");

                    b.Property<int>("Orden");

                    b.HasKey("ListadoInspeccionId", "ItemControlId");

                    b.HasIndex("ItemControlId");

                    b.ToTable("ListadosInspeccion_ItemsControl");
                });

            modelBuilder.Entity("Domain.Entities.Activo", b =>
                {
                    b.HasOne("Domain.Entities.TipoActivo", "TipoActivo")
                        .WithMany()
                        .HasForeignKey("TipoActivoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.TipoModelo", "TipoModelo")
                        .WithMany()
                        .HasForeignKey("TipoModeloId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.DocumentacionActivo", b =>
                {
                    b.HasOne("Domain.Entities.Activo")
                        .WithMany("Documentos")
                        .HasForeignKey("ActivoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.TipoDocumentacionActivo", "TipoDocumentacionActivo")
                        .WithMany()
                        .HasForeignKey("TipoDocumentacionActivoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.Inspeccion", b =>
                {
                    b.HasOne("Domain.Entities.Activo", "Activo")
                        .WithMany()
                        .HasForeignKey("ActivoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.ListadoInspeccion", "ListadoInspeccion")
                        .WithMany()
                        .HasForeignKey("ListadoInspeccionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.TipoInspeccion", "TipoInspeccion")
                        .WithMany()
                        .HasForeignKey("TipoInspeccionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.InspeccionEstado", b =>
                {
                    b.HasOne("Domain.Entities.Inspeccion", "Inspeccion")
                        .WithMany()
                        .HasForeignKey("InspeccionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.TipoEstadoInspeccion", "TipoEstadoInspeccion")
                        .WithMany()
                        .HasForeignKey("TipoEstadoInspeccionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.Inspeccion_ItemControl_Valores", b =>
                {
                    b.HasOne("Domain.Entities.Inspeccion", "Inspeccion")
                        .WithMany()
                        .HasForeignKey("InspeccionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.ItemControl", "ItemControl")
                        .WithMany()
                        .HasForeignKey("ItemControlId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.TipoAccionRecomendada", "TipoAccionRecomendada")
                        .WithMany()
                        .HasForeignKey("TipoAccionRecomendadaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.TipoLecturaItemInspeccion", "TipoLecturaItemInspeccion")
                        .WithMany()
                        .HasForeignKey("TipoLecturaItemInspeccionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.ItemControl", b =>
                {
                    b.HasOne("Domain.Entities.ListadoInspeccion")
                        .WithMany("ItemControl")
                        .HasForeignKey("ListadoInspeccionId");

                    b.HasOne("Domain.Entities.TipoRubroItemControl", "TipoRubroItemControl")
                        .WithMany()
                        .HasForeignKey("TipoRubroItemControlId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.ListadoInspeccion", b =>
                {
                    b.HasOne("Domain.Entities.TipoMedidaPeriodicidad", "TipoMedidaPeriodicidad")
                        .WithMany()
                        .HasForeignKey("TipoMedidaPeriodicidadId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.ListadoInspeccion_TipoActivo", b =>
                {
                    b.HasOne("Domain.Entities.ListadoInspeccion", "ListadoInspeccion")
                        .WithMany()
                        .HasForeignKey("ListadoInspeccionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.TipoActivo", "TipoActivo")
                        .WithMany()
                        .HasForeignKey("TipoActivoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.TipoActivo", b =>
                {
                    b.HasOne("Domain.Entities.ListadoInspeccion")
                        .WithMany("TipoActivo")
                        .HasForeignKey("ListadoInspeccionId");
                });

            modelBuilder.Entity("Domain.Entities.TipoModelo", b =>
                {
                    b.HasOne("Domain.Entities.TipoMarca", "TipoMarca")
                        .WithMany()
                        .HasForeignKey("TipoMarcaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Infraestructure.Persistance.PostgresSQL.Models.ListadoInspeccion_ItemControl", b =>
                {
                    b.HasOne("Domain.Entities.ItemControl", "ItemControl")
                        .WithMany()
                        .HasForeignKey("ItemControlId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.ListadoInspeccion", "ListadoInspeccion")
                        .WithMany()
                        .HasForeignKey("ListadoInspeccionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}