using System;
using BackEndRemuneraciones.Models.Empresa;
using BackEndRemuneraciones.Models.Empleado.Ficha;
using BackEndRemuneraciones.Models.Empleado.Condiciones;
using BackEndRemuneraciones.Models.Empleado.Prevision;
using BackEndRemuneraciones.Models.Liquidacion.Descuentos;
using BackEndRemuneraciones.Models.Liquidacion.Haberes;
using BackEndRemuneraciones.Models.ModelosVariables;
using BackEndRemuneraciones.Models;
using BackEndRemuneraciones.Models.Autenticacion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BackEndRemuneraciones.Models.Liquidacion;
using BackEndRemuneraciones.Models.Liquidacion.ImpuestoUnico;
using BackEndRemuneraciones.Models.Reportes;
using System.Linq;

namespace BackEndRemuneraciones.Models.Data
{
    public partial class remuneracionesContext : DbContext
    {
        public remuneracionesContext()
        {
        }

        public remuneracionesContext(DbContextOptions<remuneracionesContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Tbempleados> Tbempleados { get; set; }
        public virtual DbSet<AfpModel> AfpModel { get; set; }
        public virtual DbSet<RentasTopasImpModel> RentasTopasImpModel { get; set; }
        public virtual DbSet<ApvModel> ApvModel { get; set; }
        public virtual DbSet<AsigFamiliarTramo> AsigFamiliarTramo { get; set; }
        public virtual DbSet<RentasMinImponibles> RentasMinImponibles { get; set; }
        public virtual DbSet<FichaEmpresa> FichaEmpresa { get; set; }
        public virtual DbSet<BancoNomina> BancoNomina { get; set; }
        public virtual DbSet<CajaCompensacion> CajaCompensacion { get; set; }
        public virtual DbSet<ContratoEmpleado> ContratoEmpleado { get; set; }
        public virtual DbSet<BeneficiosEmpleado> BeneficiosEmpleado { get; set; }
        public virtual DbSet<SueldoEmpleado> SueldoEmpleado { get; set; }
        public virtual DbSet<PrevisionEmpleado> PrevisionEmpleado { get; set; }
        public virtual DbSet<CategoriasHaberes> CategoriasHaberes { get; set; }
        public virtual DbSet<ColeccionHaberes> ColeccionHaberes { get; set; }
        public virtual DbSet<ColeccionDescuentos> ColeccionDescuentos { get; set; }
        public virtual DbSet<ColeccionHaberesEmpleado> ColeccionHaberesEmpleados { get; set; }
        public virtual DbSet<ColeccionDescuentosEmpleado> ColeccionDescuentosEmpleados { get; set; }
        public virtual DbSet<IsapreModel> IsapreModel { get;set; }
        public virtual DbSet<TipoContratoModel> TipoContratoModel { get;set; }
        public virtual DbSet<RegionModel> RegionModels { get;set; }
        public virtual DbSet<ComunaModel> ComunaModels { get; set; }
        public virtual DbSet<UFModel> UFModel {get;set;}
        public virtual DbSet<UTMModel> UTMModel {get;set;}
        public virtual DbSet<IMMModel> IMMModel {get;set;}
        public virtual DbSet<CargosModel> CargosModel {get;set;}
        public virtual DbSet<InstitucionesApvModel> InstitucionesApvModels { get; set;}
        public virtual DbSet<LiquidacionesGeneradas> LiquidacionesGeneradas { get; set; }
        public virtual DbSet<Novedades> Novedades { get; set; }
        public virtual DbSet<HaberesYDescuentosEmpleado> HaberesYDescuentosEmpleado { get; set; }
        public virtual DbSet<ImpuestoUnico> ImpuestoUnico { get; set; }
        public virtual DbSet<AFCModel> AFCModel { get; set; }
        public virtual DbSet<LibroRemuneraciones> LibroRemuneraciones { get; set; }
        public virtual DbSet<TipoEmpresa> TipoEmpresa { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //         optionsBuilder.UseMySql("server=localhost;port=3306;database=remuneraciones;uid=root;pwd=", x => x.ServerVersion("10.1.31-mariadb"));
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                                                 .SelectMany(t => t.GetProperties())
                                                 .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                if (property.GetColumnType() == null)
                    property.SetColumnType("decimal(18,2)");
            }

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
