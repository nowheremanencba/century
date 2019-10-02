using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infraestructure.Persistance.PostgresSQL.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoEstadoInspeccion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEstadoInspeccion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposAccionesRecomendada",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposAccionesRecomendada", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposDocumentacionActivo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposDocumentacionActivo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposInspeccion",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposInspeccion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposLecturaItemInspeccion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Descripcion = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposLecturaItemInspeccion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposMarca",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Descripcion = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposMarca", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposMedidaPeriodicidad",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposMedidaPeriodicidad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposRubroItemsControl",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposRubroItemsControl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposModelo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Descripcion = table.Column<string>(maxLength: 300, nullable: true),
                    TipoMarcaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposModelo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TiposModelo_TiposMarca_TipoMarcaId",
                        column: x => x.TipoMarcaId,
                        principalTable: "TiposMarca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListadosInspeccion",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    UnidadPeriodicidad = table.Column<int>(nullable: false),
                    TipoMedidaPeriodicidadId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListadosInspeccion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListadosInspeccion_TiposMedidaPeriodicidad_TipoMedidaPeriod~",
                        column: x => x.TipoMedidaPeriodicidadId,
                        principalTable: "TiposMedidaPeriodicidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemsControl",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Nombre = table.Column<string>(maxLength: 300, nullable: true),
                    RealizarLectura = table.Column<bool>(nullable: false),
                    TipoRubroItemControlId = table.Column<string>(nullable: false),
                    ListadoInspeccionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsControl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemsControl_ListadosInspeccion_ListadoInspeccionId",
                        column: x => x.ListadoInspeccionId,
                        principalTable: "ListadosInspeccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemsControl_TiposRubroItemsControl_TipoRubroItemControlId",
                        column: x => x.TipoRubroItemControlId,
                        principalTable: "TiposRubroItemsControl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TiposActivo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Descripcion = table.Column<string>(maxLength: 300, nullable: true),
                    DominioObligatorio = table.Column<bool>(nullable: false),
                    ListadoInspeccionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposActivo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TiposActivo_ListadosInspeccion_ListadoInspeccionId",
                        column: x => x.ListadoInspeccionId,
                        principalTable: "ListadosInspeccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ListadosInspeccion_ItemsControl",
                columns: table => new
                {
                    ListadoInspeccionId = table.Column<Guid>(nullable: false),
                    ItemControlId = table.Column<int>(nullable: false),
                    Orden = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListadosInspeccion_ItemsControl", x => new { x.ListadoInspeccionId, x.ItemControlId });
                    table.ForeignKey(
                        name: "FK_ListadosInspeccion_ItemsControl_ItemsControl_ItemControlId",
                        column: x => x.ItemControlId,
                        principalTable: "ItemsControl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListadosInspeccion_ItemsControl_ListadosInspeccion_ListadoI~",
                        column: x => x.ListadoInspeccionId,
                        principalTable: "ListadosInspeccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Activos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Dominio = table.Column<string>(maxLength: 150, nullable: false),
                    NumeroInterno = table.Column<int>(nullable: false),
                    Año = table.Column<string>(nullable: true),
                    EmpleadoResponsableID = table.Column<Guid>(nullable: false),
                    Chasis = table.Column<string>(nullable: true),
                    Motor = table.Column<string>(nullable: true),
                    Ubicacion = table.Column<string>(maxLength: 300, nullable: false),
                    FechaCompra = table.Column<DateTime>(nullable: false),
                    TipoModeloId = table.Column<int>(nullable: false),
                    TipoActivoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activos_TiposActivo_TipoActivoId",
                        column: x => x.TipoActivoId,
                        principalTable: "TiposActivo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activos_TiposModelo_TipoModeloId",
                        column: x => x.TipoModeloId,
                        principalTable: "TiposModelo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListadosInspeccion_TipoActivo",
                columns: table => new
                {
                    ListadoInspeccionId = table.Column<Guid>(nullable: false),
                    TipoActivoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListadosInspeccion_TipoActivo", x => new { x.ListadoInspeccionId, x.TipoActivoId });
                    table.ForeignKey(
                        name: "FK_ListadosInspeccion_TipoActivo_ListadosInspeccion_ListadoIns~",
                        column: x => x.ListadoInspeccionId,
                        principalTable: "ListadosInspeccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListadosInspeccion_TipoActivo_TiposActivo_TipoActivoId",
                        column: x => x.TipoActivoId,
                        principalTable: "TiposActivo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentacionesActivo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FechaVencimiento = table.Column<DateTime>(nullable: false),
                    TipoDocumentacionActivoId = table.Column<string>(nullable: false),
                    ActivoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentacionesActivo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentacionesActivo_Activos_ActivoId",
                        column: x => x.ActivoId,
                        principalTable: "Activos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentacionesActivo_TiposDocumentacionActivo_TipoDocument~",
                        column: x => x.TipoDocumentacionActivoId,
                        principalTable: "TiposDocumentacionActivo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inspecciones",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Observacion = table.Column<string>(nullable: true),
                    ActivoId = table.Column<Guid>(nullable: false),
                    TipoInspeccionId = table.Column<string>(nullable: false),
                    ListadoInspeccionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspecciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inspecciones_Activos_ActivoId",
                        column: x => x.ActivoId,
                        principalTable: "Activos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inspecciones_ListadosInspeccion_ListadoInspeccionId",
                        column: x => x.ListadoInspeccionId,
                        principalTable: "ListadosInspeccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inspecciones_TiposInspeccion_TipoInspeccionId",
                        column: x => x.TipoInspeccionId,
                        principalTable: "TiposInspeccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inspecciones_Estados",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UsuarioId = table.Column<string>(nullable: true),
                    Observacion = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Ubicacion = table.Column<string>(nullable: true),
                    InspeccionId = table.Column<Guid>(nullable: false),
                    TipoEstadoInspeccionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspecciones_Estados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inspecciones_Estados_Inspecciones_InspeccionId",
                        column: x => x.InspeccionId,
                        principalTable: "Inspecciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inspecciones_Estados_TipoEstadoInspeccion_TipoEstadoInspecc~",
                        column: x => x.TipoEstadoInspeccionId,
                        principalTable: "TipoEstadoInspeccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inspecciones_ItemsControl_Valores",
                columns: table => new
                {
                    ItemControlId = table.Column<int>(nullable: false),
                    InspeccionId = table.Column<Guid>(nullable: false),
                    Observacion = table.Column<string>(nullable: true),
                    Orden = table.Column<int>(nullable: false),
                    ValorLectura = table.Column<int>(nullable: false),
                    TipoAccionRecomendadaId = table.Column<string>(nullable: false),
                    TipoLecturaItemInspeccionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspecciones_ItemsControl_Valores", x => new { x.InspeccionId, x.ItemControlId });
                    table.ForeignKey(
                        name: "FK_Inspecciones_ItemsControl_Valores_Inspecciones_InspeccionId",
                        column: x => x.InspeccionId,
                        principalTable: "Inspecciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inspecciones_ItemsControl_Valores_ItemsControl_ItemControlId",
                        column: x => x.ItemControlId,
                        principalTable: "ItemsControl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inspecciones_ItemsControl_Valores_TiposAccionesRecomendada_~",
                        column: x => x.TipoAccionRecomendadaId,
                        principalTable: "TiposAccionesRecomendada",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inspecciones_ItemsControl_Valores_TiposLecturaItemInspeccio~",
                        column: x => x.TipoLecturaItemInspeccionId,
                        principalTable: "TiposLecturaItemInspeccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TipoEstadoInspeccion",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Realizado" },
                    { 2, "Controlado" },
                    { 3, "Supervisado" }
                });

            migrationBuilder.InsertData(
                table: "TiposAccionesRecomendada",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { "1", "Reparar" },
                    { "2", "Cambiar" },
                    { "3", "Proveer" },
                    { "4", "No Aplica" },
                    { "5", "Ninguna" }
                });

            migrationBuilder.InsertData(
                table: "TiposActivo",
                columns: new[] { "Id", "Descripcion", "DominioObligatorio", "ListadoInspeccionId" },
                values: new object[,]
                {
                    { 1, "Camioneta", true, null },
                    { 2, "Perfodaora", false, null }
                });

            migrationBuilder.InsertData(
                table: "TiposInspeccion",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { "3", "Inspeccion de rutina" },
                    { "1", "Inspeccion de ingreso" },
                    { "2", "Inspeccion de egreso" }
                });

            migrationBuilder.InsertData(
                table: "TiposLecturaItemInspeccion",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Bien" },
                    { 2, "Mal" }
                });

            migrationBuilder.InsertData(
                table: "TiposMarca",
                columns: new[] { "Id", "Descripcion" },
                values: new object[] { 1, "Ford" });

            migrationBuilder.InsertData(
                table: "TiposMedidaPeriodicidad",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { "1", "Horas" },
                    { "2", "Semanas" }
                });

            migrationBuilder.InsertData(
                table: "TiposRubroItemsControl",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { "2", "Motor" },
                    { "1", "Estado General" },
                    { "3", "Seguridad" }
                });

            migrationBuilder.InsertData(
                table: "ItemsControl",
                columns: new[] { "Id", "ListadoInspeccionId", "Nombre", "RealizarLectura", "TipoRubroItemControlId" },
                values: new object[,]
                {
                    { 1, null, "Nivel Aceite Motor", true, "1" },
                    { 2, null, "Carga de la bateria", true, "2" }
                });

            migrationBuilder.InsertData(
                table: "TiposModelo",
                columns: new[] { "Id", "Descripcion", "TipoMarcaId" },
                values: new object[,]
                {
                    { 1, "Mustang", 1 },
                    { 2, "F-100", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activos_Dominio",
                table: "Activos",
                column: "Dominio",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Activos_NumeroInterno",
                table: "Activos",
                column: "NumeroInterno",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Activos_TipoActivoId",
                table: "Activos",
                column: "TipoActivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Activos_TipoModeloId",
                table: "Activos",
                column: "TipoModeloId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentacionesActivo_ActivoId",
                table: "DocumentacionesActivo",
                column: "ActivoId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentacionesActivo_TipoDocumentacionActivoId",
                table: "DocumentacionesActivo",
                column: "TipoDocumentacionActivoId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentacionesActivo_FechaVencimiento_ActivoId",
                table: "DocumentacionesActivo",
                columns: new[] { "FechaVencimiento", "ActivoId" });

            migrationBuilder.CreateIndex(
                name: "IX_Inspecciones_ActivoId",
                table: "Inspecciones",
                column: "ActivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspecciones_ListadoInspeccionId",
                table: "Inspecciones",
                column: "ListadoInspeccionId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspecciones_TipoInspeccionId",
                table: "Inspecciones",
                column: "TipoInspeccionId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspecciones_Estados_InspeccionId",
                table: "Inspecciones_Estados",
                column: "InspeccionId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspecciones_Estados_TipoEstadoInspeccionId",
                table: "Inspecciones_Estados",
                column: "TipoEstadoInspeccionId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspecciones_ItemsControl_Valores_ItemControlId",
                table: "Inspecciones_ItemsControl_Valores",
                column: "ItemControlId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspecciones_ItemsControl_Valores_TipoAccionRecomendadaId",
                table: "Inspecciones_ItemsControl_Valores",
                column: "TipoAccionRecomendadaId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspecciones_ItemsControl_Valores_TipoLecturaItemInspeccion~",
                table: "Inspecciones_ItemsControl_Valores",
                column: "TipoLecturaItemInspeccionId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsControl_ListadoInspeccionId",
                table: "ItemsControl",
                column: "ListadoInspeccionId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsControl_TipoRubroItemControlId",
                table: "ItemsControl",
                column: "TipoRubroItemControlId");

            migrationBuilder.CreateIndex(
                name: "IX_ListadosInspeccion_TipoMedidaPeriodicidadId",
                table: "ListadosInspeccion",
                column: "TipoMedidaPeriodicidadId");

            migrationBuilder.CreateIndex(
                name: "IX_ListadosInspeccion_ItemsControl_ItemControlId",
                table: "ListadosInspeccion_ItemsControl",
                column: "ItemControlId");

            migrationBuilder.CreateIndex(
                name: "IX_ListadosInspeccion_TipoActivo_TipoActivoId",
                table: "ListadosInspeccion_TipoActivo",
                column: "TipoActivoId");

            migrationBuilder.CreateIndex(
                name: "IX_TiposActivo_ListadoInspeccionId",
                table: "TiposActivo",
                column: "ListadoInspeccionId");

            migrationBuilder.CreateIndex(
                name: "IX_TiposModelo_TipoMarcaId",
                table: "TiposModelo",
                column: "TipoMarcaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentacionesActivo");

            migrationBuilder.DropTable(
                name: "Inspecciones_Estados");

            migrationBuilder.DropTable(
                name: "Inspecciones_ItemsControl_Valores");

            migrationBuilder.DropTable(
                name: "ListadosInspeccion_ItemsControl");

            migrationBuilder.DropTable(
                name: "ListadosInspeccion_TipoActivo");

            migrationBuilder.DropTable(
                name: "TiposDocumentacionActivo");

            migrationBuilder.DropTable(
                name: "TipoEstadoInspeccion");

            migrationBuilder.DropTable(
                name: "Inspecciones");

            migrationBuilder.DropTable(
                name: "TiposAccionesRecomendada");

            migrationBuilder.DropTable(
                name: "TiposLecturaItemInspeccion");

            migrationBuilder.DropTable(
                name: "ItemsControl");

            migrationBuilder.DropTable(
                name: "Activos");

            migrationBuilder.DropTable(
                name: "TiposInspeccion");

            migrationBuilder.DropTable(
                name: "TiposRubroItemsControl");

            migrationBuilder.DropTable(
                name: "TiposActivo");

            migrationBuilder.DropTable(
                name: "TiposModelo");

            migrationBuilder.DropTable(
                name: "ListadosInspeccion");

            migrationBuilder.DropTable(
                name: "TiposMarca");

            migrationBuilder.DropTable(
                name: "TiposMedidaPeriodicidad");
        }
    }
}
