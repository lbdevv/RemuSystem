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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseMySql("server=localhost;port=3306;database=remuneraciones;uid=root;pwd=root", x => x.ServerVersion("10.1.31-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Aspnetroleclaims>(entity =>
            //{
            //    entity.ToTable("aspnetroleclaims");

            //    entity.HasIndex(e => e.RoleId)
            //        .HasName("IX_AspNetRoleClaims_RoleId");

            //    entity.Property(e => e.Id).HasColumnType("int(11)");

            //    entity.Property(e => e.ClaimType)
            //        .HasColumnType("longtext")
            //        .HasCharSet("utf8mb4")
            //        .HasCollation("utf8mb4_general_ci");

            //    entity.Property(e => e.ClaimValue)
            //        .HasColumnType("longtext")
            //        .HasCharSet("utf8mb4")
            //        .HasCollation("utf8mb4_general_ci");

            //    entity.Property(e => e.RoleId)
            //        .IsRequired()
            //        .HasColumnType("varchar(127)")
            //        .HasCharSet("utf8mb4")
            //        .HasCollation("utf8mb4_general_ci");

            //    entity.HasOne(d => d.Role)
            //        .WithMany(p => p.Aspnetroleclaims)
            //        .HasForeignKey(d => d.RoleId)
            //        .HasConstraintName("FK_AspNetRoleClaims_AspNetRoles_RoleId");
            //});

            //modelBuilder.Entity<Aspnetroles>(entity =>
            //{
            //    entity.ToTable("aspnetroles");

            //    entity.HasIndex(e => e.NormalizedName)
            //        .HasName("RoleNameIndex")
            //        .IsUnique();

            //    entity.Property(e => e.Id)
            //        .HasColumnType("varchar(127)")
            //        .HasCharSet("utf8mb4")
            //        .HasCollation("utf8mb4_general_ci");

            //    entity.Property(e => e.ConcurrencyStamp)
            //        .HasColumnType("longtext")
            //        .HasCharSet("utf8mb4")
            //        .HasCollation("utf8mb4_general_ci");

            //    entity.Property(e => e.Name)
            //        .HasColumnType("varchar(127)")
            //        .HasCharSet("utf8mb4")
            //        .HasCollation("utf8mb4_general_ci");

            //    entity.Property(e => e.NormalizedName)
            //        .HasColumnType("varchar(127)")
            //        .HasCharSet("utf8mb4")
            //        .HasCollation("utf8mb4_general_ci");
            //});

            //modelBuilder.Entity<Aspnetuserclaims>(entity =>
            //{
            //    entity.ToTable("aspnetuserclaims");

            //    entity.HasIndex(e => e.UserId)
            //        .HasName("IX_AspNetUserClaims_UserId");

            //    entity.Property(e => e.Id).HasColumnType("int(11)");

            //    entity.Property(e => e.ClaimType)
            //        .HasColumnType("longtext")
            //        .HasCharSet("utf8mb4")
            //        .HasCollation("utf8mb4_general_ci");

            //    entity.Property(e => e.ClaimValue)
            //        .HasColumnType("longtext")
            //        .HasCharSet("utf8mb4")
            //        .HasCollation("utf8mb4_general_ci");

            //    entity.Property(e => e.UserId)
            //        .IsRequired()
            //        .HasColumnType("varchar(127)")
            //        .HasCharSet("utf8mb4")
            //        .HasCollation("utf8mb4_general_ci");

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.Aspnetuserclaims)
            //        .HasForeignKey(d => d.UserId)
            //        .HasConstraintName("FK_AspNetUserClaims_AspNetUsers_UserId");
            //});

            //modelBuilder.Entity<Aspnetuserlogins>(entity =>
            //{
            //    entity.HasKey(e => new { e.LoginProvider, e.ProviderKey })
            //        .HasName("PRIMARY");

            //    entity.ToTable("aspnetuserlogins");

            //    entity.HasIndex(e => e.UserId)
            //        .HasName("IX_AspNetUserLogins_UserId");

            //    entity.Property(e => e.LoginProvider)
            //        .HasColumnType("varchar(127)")
            //        .HasCharSet("utf8mb4")
            //        .HasCollation("utf8mb4_general_ci");

            //    entity.Property(e => e.ProviderKey)
            //        .HasColumnType("varchar(127)")
            //        .HasCharSet("utf8mb4")
            //        .HasCollation("utf8mb4_general_ci");

            //    entity.Property(e => e.ProviderDisplayName)
            //        .HasColumnType("longtext")
            //        .HasCharSet("utf8mb4")
            //        .HasCollation("utf8mb4_general_ci");

            //    entity.Property(e => e.UserId)
            //        .IsRequired()
            //        .HasColumnType("varchar(127)")
            //        .HasCharSet("utf8mb4")
            //        .HasCollation("utf8mb4_general_ci");

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.Aspnetuserlogins)
            //        .HasForeignKey(d => d.UserId)
            //        .HasConstraintName("FK_AspNetUserLogins_AspNetUsers_UserId");
            //});

            //modelBuilder.Entity<Aspnetuserroles>(entity =>
            //{
            //    entity.HasKey(e => new { e.UserId, e.RoleId })
            //        .HasName("PRIMARY");

            //    entity.ToTable("aspnetuserroles");

            //    entity.HasIndex(e => e.RoleId)
            //        .HasName("IX_AspNetUserRoles_RoleId");

            //    entity.Property(e => e.UserId)
            //        .HasColumnType("varchar(127)")
            //        .HasCharSet("utf8mb4")
            //        .HasCollation("utf8mb4_general_ci");

            //    entity.Property(e => e.RoleId)
            //        .HasColumnType("varchar(127)")
            //        .HasCharSet("utf8mb4")
            //        .HasCollation("utf8mb4_general_ci");

            //    entity.HasOne(d => d.Role)
            //        .WithMany(p => p.Aspnetuserroles)
            //        .HasForeignKey(d => d.RoleId)
            //        .HasConstraintName("FK_AspNetUserRoles_AspNetRoles_RoleId");

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.Aspnetuserroles)
            //        .HasForeignKey(d => d.UserId)
            //        .HasConstraintName("FK_AspNetUserRoles_AspNetUsers_UserId");
            //});

            //modelBuilder.Entity<Aspnetusers>(entity =>
            //{
            //    entity.ToTable("aspnetusers");

            //    entity.HasIndex(e => e.NormalizedEmail)
            //        .HasName("EmailIndex");

            //    entity.HasIndex(e => e.NormalizedUserName)
            //        .HasName("UserNameIndex")
            //        .IsUnique();

            //    entity.Property(e => e.Id)
            //        .HasColumnType("varchar(127)")
            //        .HasCharSet("utf8mb4")
            //        .HasCollation("utf8mb4_general_ci");

            //    entity.Property(e => e.AccessFailedCount).HasColumnType("int(11)");

            //    entity.Property(e => e.ConcurrencyStamp)
            //        .HasColumnType("longtext")
            //        .HasCharSet("utf8mb4")
            //        .HasCollation("utf8mb4_general_ci");

            //    entity.Property(e => e.Email)
            //        .HasColumnType("varchar(256)")
            //        .HasCharSet("utf8mb4")
            //        .HasCollation("utf8mb4_general_ci");

            //    entity.Property(e => e.NormalizedEmail)
            //        .HasColumnType("varchar(256)")
            //        .HasCharSet("utf8mb4")
            //        .HasCollation("utf8mb4_general_ci");

            //    entity.Property(e => e.NormalizedUserName)
            //        .HasColumnType("varchar(127)")
            //        .HasCharSet("utf8mb4")
            //        .HasCollation("utf8mb4_general_ci");

            //    entity.Property(e => e.PasswordHash)
            //        .HasColumnType("longtext")
            //        .HasCharSet("utf8mb4")
            //        .HasCollation("utf8mb4_general_ci");

            //    entity.Property(e => e.PhoneNumber)
            //        .HasColumnType("longtext")
            //        .HasCharSet("utf8mb4")
            //        .HasCollation("utf8mb4_general_ci");

            //    entity.Property(e => e.SecurityStamp)
            //        .HasColumnType("longtext")
            //        .HasCharSet("utf8mb4")
            //        .HasCollation("utf8mb4_general_ci");

            //    entity.Property(e => e.UserName)
            //        .HasColumnType("varchar(127)")
            //        .HasCharSet("utf8mb4")
            //        .HasCollation("utf8mb4_general_ci");
            //});

            //modelBuilder.Entity<Aspnetusertokens>(entity =>
            //{
            //    entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name })
            //        .HasName("PRIMARY");

            //    entity.ToTable("aspnetusertokens");

            //    entity.Property(e => e.UserId)
            //        .HasColumnType("varchar(127)")
            //        .HasCharSet("utf8mb4")
            //        .HasCollation("utf8mb4_general_ci");

            //    entity.Property(e => e.LoginProvider)
            //        .HasColumnType("varchar(127)")
            //        .HasCharSet("utf8mb4")
            //        .HasCollation("utf8mb4_general_ci");

            //    entity.Property(e => e.Name)
            //        .HasColumnType("varchar(127)")
            //        .HasCharSet("utf8mb4")
            //        .HasCollation("utf8mb4_general_ci");

            //    entity.Property(e => e.Value)
            //        .HasColumnType("longtext")
            //        .HasCharSet("utf8mb4")
            //        .HasCollation("utf8mb4_general_ci");

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.Aspnetusertokens)
            //        .HasForeignKey(d => d.UserId)
            //        .HasConstraintName("FK_AspNetUserTokens_AspNetUsers_UserId");
            //});


            //modelBuilder.Entity<Tbempleados>(entity =>
            //{
            //    entity.ToTable("tbempleados");

            //    entity.Property(e => e.Id).HasColumnType("int(11)");

            //    entity.Property(e => e.Apellido)
            //        .IsRequired()
            //        .HasColumnType("varchar(25)")
            //        .HasCharSet("utf8mb4")
            //        .HasCollation("utf8mb4_general_ci");

            //    entity.Property(e => e.Ciudad).HasColumnType("int(11)");

            //    entity.Property(e => e.Comuna).HasColumnType("int(11)");

            //    entity.Property(e => e.Direccion)
            //        .HasColumnType("longtext")
            //        .HasCharSet("utf8mb4")
            //        .HasCollation("utf8mb4_general_ci");

            //    entity.Property(e => e.Email)
            //        .HasColumnType("varchar(30)")
            //        .HasCharSet("utf8mb4")
            //        .HasCollation("utf8mb4_general_ci");

            //    entity.Property(e => e.EstadoCivil)
            //        .HasColumnType("varchar(15)")
            //        .HasCharSet("utf8mb4")
            //        .HasCollation("utf8mb4_general_ci");

            //    entity.Property(e => e.Nacionalidad).HasColumnType("varchar(25)");

            //    entity.Property(e => e.Nombre)
            //        .IsRequired()
            //        .HasColumnType("varchar(25)")
            //        .HasCharSet("utf8mb4")
            //        .HasCollation("utf8mb4_general_ci");

            //    entity.Property(e => e.Rut)
            //        .IsRequired()
            //        .HasColumnType("varchar(15)")
            //        .HasCharSet("utf8mb4")
            //        .HasCollation("utf8mb4_general_ci");

            //    entity.Property(e => e.Sexo).HasColumnType("int(11)");
            //});

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
