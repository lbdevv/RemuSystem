using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndRemuneraciones.Models
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AFCModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Contrato = table.Column<string>(nullable: true),
                    FinanciamientoEmpleador = table.Column<decimal>(nullable: false),
                    FinanciamientoEmpleado = table.Column<decimal>(nullable: false),
                    EstaActivo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AFCModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AfpModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FechaPrevision = table.Column<DateTime>(nullable: false),
                    EstaActiva = table.Column<bool>(nullable: false),
                    NombreAfp = table.Column<string>(nullable: true),
                    DependientesTasaAfp = table.Column<decimal>(nullable: false),
                    DependientesSis = table.Column<decimal>(nullable: false),
                    IndependientesTasaAfp = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AfpModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApvModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FechaPrevision = table.Column<DateTime>(nullable: false),
                    EstaActiva = table.Column<bool>(nullable: false),
                    Tope = table.Column<string>(nullable: true),
                    MontoTope = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApvModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AsigFamiliarTramo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FechaPrevision = table.Column<DateTime>(nullable: false),
                    EstaActiva = table.Column<bool>(nullable: false),
                    Tramo = table.Column<string>(nullable: false),
                    Monto = table.Column<decimal>(nullable: false),
                    TopeCompararConRenta = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsigFamiliarTramo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BancoNomina",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BancoNomina", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BeneficiosEmpleado",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DiasAddVacaciones = table.Column<int>(nullable: false),
                    CantidadDiasAdmin = table.Column<int>(nullable: false),
                    MesesImponiblesReconocidos = table.Column<int>(nullable: false),
                    MesesImponiblesRecDesde = table.Column<int>(nullable: false),
                    PagaLosPrimeros3DiasDeLicencia = table.Column<bool>(nullable: false),
                    MantieneLaRentaLiquidaLicencia = table.Column<bool>(nullable: false),
                    BeneficiosAdicionales = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeneficiosEmpleado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CajaCompensacion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CajaCompensacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CargosModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Detalle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargosModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoriasHaberes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasHaberes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IMMModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    EstaActiva = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IMMModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImpuestoUnico",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateTime>(nullable: false),
                    RangoDesde = table.Column<decimal>(nullable: false),
                    RangoHasta = table.Column<decimal>(nullable: false),
                    FactorExento = table.Column<decimal>(nullable: false),
                    CandidadRebaja = table.Column<decimal>(nullable: false),
                    TasaImpuestoEfectivaMaxXtramoRenta = table.Column<string>(nullable: true),
                    EstaActiva = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImpuestoUnico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InstitucionesApvModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstitucionesApvModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IsapreModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IsapreModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegionModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RentasMinImponibles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreCaso = table.Column<string>(nullable: true),
                    Monto = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentasMinImponibles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RentasTopasImpModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreTipoRenta = table.Column<string>(nullable: true),
                    UFCLP = table.Column<decimal>(nullable: false),
                    Tope_id = table.Column<int>(nullable: false),
                    EstaActiva = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentasTopasImpModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SueldoEmpleado",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TipoPago = table.Column<string>(nullable: true),
                    SueldoBase = table.Column<decimal>(nullable: false),
                    MontoGratificacion = table.Column<decimal>(nullable: false),
                    AsignMovilizacion = table.Column<decimal>(nullable: false),
                    AsignColacion = table.Column<decimal>(nullable: false),
                    AnticipoPactado = table.Column<decimal>(nullable: false),
                    FormaPago = table.Column<string>(nullable: true),
                    CuentaCorriente = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SueldoEmpleado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoContratoModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoContratoModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoEmpresa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEmpresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UFModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    EstaActiva = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UFModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    Contrasena = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Perfil = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UTMModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    EstaActiva = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UTMModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContratoEmpleado",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Empleador = table.Column<string>(nullable: true),
                    CargoId = table.Column<int>(nullable: false),
                    ContratoDesde = table.Column<DateTime>(nullable: false),
                    ContratoHasta = table.Column<DateTime>(nullable: false),
                    Antiguedad = table.Column<string>(nullable: true),
                    Jefe = table.Column<string>(nullable: true),
                    HorasDeJornada = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratoEmpleado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContratoEmpleado_CargosModel_CargoId",
                        column: x => x.CargoId,
                        principalTable: "CargosModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrevisionEmpleado",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AFPId = table.Column<int>(nullable: false),
                    IsapreId = table.Column<int>(nullable: false),
                    MontoPactadoIsapre = table.Column<decimal>(nullable: false),
                    Tipo = table.Column<int>(nullable: false),
                    TramoAsignFamiliar = table.Column<int>(nullable: false),
                    AdscribeSeguroCesantia = table.Column<bool>(nullable: false),
                    EsPensionado = table.Column<bool>(nullable: false),
                    TrabajoPesaNomPuesto = table.Column<string>(nullable: true),
                    CodigoINE = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrevisionEmpleado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrevisionEmpleado_AfpModel_AFPId",
                        column: x => x.AFPId,
                        principalTable: "AfpModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrevisionEmpleado_IsapreModel_IsapreId",
                        column: x => x.IsapreId,
                        principalTable: "IsapreModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComunaModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    RegionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComunaModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComunaModels_RegionModels_RegionId",
                        column: x => x.RegionId,
                        principalTable: "RegionModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FichaEmpresa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Rut = table.Column<string>(nullable: true),
                    Principal = table.Column<bool>(nullable: false),
                    RazonSocial = table.Column<string>(nullable: true),
                    TipoEmpresa = table.Column<int>(nullable: false),
                    Giro = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    RepresentanteLegal = table.Column<string>(nullable: true),
                    RutRepresentanteLegal = table.Column<string>(nullable: true),
                    CajaCompensacion = table.Column<int>(nullable: true),
                    MutualPorcentajeDescuento = table.Column<decimal>(nullable: false),
                    Comuna = table.Column<int>(nullable: false),
                    Telefono = table.Column<int>(nullable: false),
                    BancoPagoNomina = table.Column<int>(nullable: false),
                    Vigente = table.Column<bool>(nullable: false),
                    FormaPagoGratif = table.Column<int>(nullable: false),
                    FormPagoMoviColacion = table.Column<int>(nullable: false),
                    UsuarioEmpresaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichaEmpresa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FichaEmpresa_Usuario_UsuarioEmpresaId",
                        column: x => x.UsuarioEmpresaId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ColeccionDescuentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmpresaId = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    ValorCalculo = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColeccionDescuentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColeccionDescuentos_FichaEmpresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "FichaEmpresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ColeccionHaberes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmpresaId = table.Column<int>(nullable: false),
                    Categoria_id = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    ValorCalculo = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColeccionHaberes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColeccionHaberes_FichaEmpresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "FichaEmpresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbempleados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Rut = table.Column<string>(nullable: true),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    Nacionalidad = table.Column<string>(nullable: true),
                    Sexo = table.Column<int>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    EstaDisponible = table.Column<bool>(nullable: false),
                    Ciudad = table.Column<int>(nullable: false),
                    Comuna = table.Column<int>(nullable: false),
                    Telefono = table.Column<int>(nullable: false),
                    Direccion = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EstadoCivil = table.Column<string>(nullable: true),
                    ContratoEmpId = table.Column<int>(nullable: false),
                    SueldoEmpId = table.Column<int>(nullable: false),
                    PrevisionEmpId = table.Column<int>(nullable: false),
                    EmpresaEmpleadoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbempleados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbempleados_ContratoEmpleado_ContratoEmpId",
                        column: x => x.ContratoEmpId,
                        principalTable: "ContratoEmpleado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbempleados_FichaEmpresa_EmpresaEmpleadoId",
                        column: x => x.EmpresaEmpleadoId,
                        principalTable: "FichaEmpresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbempleados_PrevisionEmpleado_PrevisionEmpId",
                        column: x => x.PrevisionEmpId,
                        principalTable: "PrevisionEmpleado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbempleados_SueldoEmpleado_SueldoEmpId",
                        column: x => x.SueldoEmpId,
                        principalTable: "SueldoEmpleado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ColeccionDescuentosEmpleados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TbEmpleado_id = table.Column<int>(nullable: false),
                    EmpleadoId = table.Column<int>(nullable: true),
                    ColeccionDescuentos_id = table.Column<int>(nullable: false),
                    DescuentosId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColeccionDescuentosEmpleados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColeccionDescuentosEmpleados_ColeccionDescuentos_DescuentosId",
                        column: x => x.DescuentosId,
                        principalTable: "ColeccionDescuentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ColeccionDescuentosEmpleados_Tbempleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Tbempleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ColeccionHaberesEmpleados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TbEmpelado_id = table.Column<int>(nullable: false),
                    EmpleadoId = table.Column<int>(nullable: true),
                    ColeccionHaberes_id = table.Column<int>(nullable: false),
                    HaberesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColeccionHaberesEmpleados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColeccionHaberesEmpleados_Tbempleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Tbempleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ColeccionHaberesEmpleados_ColeccionHaberes_HaberesId",
                        column: x => x.HaberesId,
                        principalTable: "ColeccionHaberes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HaberesYDescuentosEmpleado",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmpresaId = table.Column<int>(nullable: false),
                    EmpleadoId = table.Column<int>(nullable: false),
                    HaberOdescuentoId = table.Column<int>(nullable: false),
                    TipoHoD = table.Column<int>(nullable: false),
                    Monto = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HaberesYDescuentosEmpleado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HaberesYDescuentosEmpleado_Tbempleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Tbempleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HaberesYDescuentosEmpleado_FichaEmpresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "FichaEmpresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LibroRemuneraciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmpleadoId = table.Column<int>(nullable: false),
                    GratLegal = table.Column<decimal>(nullable: false),
                    OtrosImp = table.Column<decimal>(nullable: false),
                    TotalImp = table.Column<decimal>(nullable: false),
                    TotalNoImp = table.Column<decimal>(nullable: false),
                    TotalHaberes = table.Column<decimal>(nullable: false),
                    Prevision = table.Column<decimal>(nullable: false),
                    Salud = table.Column<decimal>(nullable: false),
                    ImpUnico = table.Column<decimal>(nullable: false),
                    SegCesantia = table.Column<decimal>(nullable: false),
                    DescLegales = table.Column<decimal>(nullable: false),
                    DescVariables = table.Column<decimal>(nullable: false),
                    TotalDescuentos = table.Column<decimal>(nullable: false),
                    OtrDescuentosLegales = table.Column<decimal>(nullable: false),
                    AsigFamiliar = table.Column<decimal>(nullable: false),
                    OtrosNoImp = table.Column<decimal>(nullable: false),
                    TotalLiquido = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibroRemuneraciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LibroRemuneraciones_Tbempleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Tbempleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LiquidacionesGeneradas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmpresaId = table.Column<int>(nullable: false),
                    CargosId = table.Column<int>(nullable: false),
                    EmpleadoId = table.Column<int>(nullable: false),
                    EmpeladoId = table.Column<int>(nullable: true),
                    FechaLiquidacion = table.Column<DateTime>(nullable: false),
                    TotalImponibles = table.Column<decimal>(nullable: false),
                    TotalNoImponibles = table.Column<decimal>(nullable: false),
                    TotalDescuentosLegales = table.Column<decimal>(nullable: false),
                    TotalDescuentosPersonales = table.Column<decimal>(nullable: false),
                    TotalHaberes = table.Column<decimal>(nullable: false),
                    TotalDescuentos = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiquidacionesGeneradas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LiquidacionesGeneradas_CargosModel_CargosId",
                        column: x => x.CargosId,
                        principalTable: "CargosModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LiquidacionesGeneradas_Tbempleados_EmpeladoId",
                        column: x => x.EmpeladoId,
                        principalTable: "Tbempleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LiquidacionesGeneradas_FichaEmpresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "FichaEmpresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Novedades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmpleadoId = table.Column<int>(nullable: false),
                    NombreNovedad = table.Column<string>(nullable: true),
                    MontoNovedad = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Novedades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Novedades_Tbempleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Tbempleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ColeccionDescuentos_EmpresaId",
                table: "ColeccionDescuentos",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_ColeccionDescuentosEmpleados_DescuentosId",
                table: "ColeccionDescuentosEmpleados",
                column: "DescuentosId");

            migrationBuilder.CreateIndex(
                name: "IX_ColeccionDescuentosEmpleados_EmpleadoId",
                table: "ColeccionDescuentosEmpleados",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_ColeccionHaberes_EmpresaId",
                table: "ColeccionHaberes",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_ColeccionHaberesEmpleados_EmpleadoId",
                table: "ColeccionHaberesEmpleados",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_ColeccionHaberesEmpleados_HaberesId",
                table: "ColeccionHaberesEmpleados",
                column: "HaberesId");

            migrationBuilder.CreateIndex(
                name: "IX_ComunaModels_RegionId",
                table: "ComunaModels",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratoEmpleado_CargoId",
                table: "ContratoEmpleado",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_FichaEmpresa_UsuarioEmpresaId",
                table: "FichaEmpresa",
                column: "UsuarioEmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_HaberesYDescuentosEmpleado_EmpleadoId",
                table: "HaberesYDescuentosEmpleado",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_HaberesYDescuentosEmpleado_EmpresaId",
                table: "HaberesYDescuentosEmpleado",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_LibroRemuneraciones_EmpleadoId",
                table: "LibroRemuneraciones",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_LiquidacionesGeneradas_CargosId",
                table: "LiquidacionesGeneradas",
                column: "CargosId");

            migrationBuilder.CreateIndex(
                name: "IX_LiquidacionesGeneradas_EmpeladoId",
                table: "LiquidacionesGeneradas",
                column: "EmpeladoId");

            migrationBuilder.CreateIndex(
                name: "IX_LiquidacionesGeneradas_EmpresaId",
                table: "LiquidacionesGeneradas",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Novedades_EmpleadoId",
                table: "Novedades",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_PrevisionEmpleado_AFPId",
                table: "PrevisionEmpleado",
                column: "AFPId");

            migrationBuilder.CreateIndex(
                name: "IX_PrevisionEmpleado_IsapreId",
                table: "PrevisionEmpleado",
                column: "IsapreId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbempleados_ContratoEmpId",
                table: "Tbempleados",
                column: "ContratoEmpId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbempleados_EmpresaEmpleadoId",
                table: "Tbempleados",
                column: "EmpresaEmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbempleados_PrevisionEmpId",
                table: "Tbempleados",
                column: "PrevisionEmpId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbempleados_SueldoEmpId",
                table: "Tbempleados",
                column: "SueldoEmpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AFCModel");

            migrationBuilder.DropTable(
                name: "ApvModel");

            migrationBuilder.DropTable(
                name: "AsigFamiliarTramo");

            migrationBuilder.DropTable(
                name: "BancoNomina");

            migrationBuilder.DropTable(
                name: "BeneficiosEmpleado");

            migrationBuilder.DropTable(
                name: "CajaCompensacion");

            migrationBuilder.DropTable(
                name: "CategoriasHaberes");

            migrationBuilder.DropTable(
                name: "ColeccionDescuentosEmpleados");

            migrationBuilder.DropTable(
                name: "ColeccionHaberesEmpleados");

            migrationBuilder.DropTable(
                name: "ComunaModels");

            migrationBuilder.DropTable(
                name: "HaberesYDescuentosEmpleado");

            migrationBuilder.DropTable(
                name: "IMMModel");

            migrationBuilder.DropTable(
                name: "ImpuestoUnico");

            migrationBuilder.DropTable(
                name: "InstitucionesApvModels");

            migrationBuilder.DropTable(
                name: "LibroRemuneraciones");

            migrationBuilder.DropTable(
                name: "LiquidacionesGeneradas");

            migrationBuilder.DropTable(
                name: "Novedades");

            migrationBuilder.DropTable(
                name: "RentasMinImponibles");

            migrationBuilder.DropTable(
                name: "RentasTopasImpModel");

            migrationBuilder.DropTable(
                name: "TipoContratoModel");

            migrationBuilder.DropTable(
                name: "TipoEmpresa");

            migrationBuilder.DropTable(
                name: "UFModel");

            migrationBuilder.DropTable(
                name: "UTMModel");

            migrationBuilder.DropTable(
                name: "ColeccionDescuentos");

            migrationBuilder.DropTable(
                name: "ColeccionHaberes");

            migrationBuilder.DropTable(
                name: "RegionModels");

            migrationBuilder.DropTable(
                name: "Tbempleados");

            migrationBuilder.DropTable(
                name: "ContratoEmpleado");

            migrationBuilder.DropTable(
                name: "FichaEmpresa");

            migrationBuilder.DropTable(
                name: "PrevisionEmpleado");

            migrationBuilder.DropTable(
                name: "SueldoEmpleado");

            migrationBuilder.DropTable(
                name: "CargosModel");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "AfpModel");

            migrationBuilder.DropTable(
                name: "IsapreModel");
        }
    }
}
