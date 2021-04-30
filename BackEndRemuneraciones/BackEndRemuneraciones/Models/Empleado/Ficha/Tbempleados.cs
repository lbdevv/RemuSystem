using BackEndRemuneraciones.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using BackEndRemuneraciones.Models.Data;
using BackEndRemuneraciones.Helpers;
using BackEndRemuneraciones.Models.Empleado.Condiciones;
using BackEndRemuneraciones.Models.Empleado.Prevision;
using BackEndRemuneraciones.Models.Liquidacion;
using Microsoft.EntityFrameworkCore;
using BackEndRemuneraciones.Models.Empresa;
using BackEndRemuneraciones.Models.Liquidacion.Haberes;
using BackEndRemuneraciones.Models.Liquidacion.Descuentos;
using BackEndRemuneraciones.Models.Liquidacion.ImpuestoUnico;
using BackEndRemuneraciones.Services;
using BackEndRemuneraciones.Models.ModelosVariables;




namespace BackEndRemuneraciones.Models.Empleado.Ficha
{
    public partial class Tbempleados
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Rut { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Nacionalidad { get; set; }
        public int Sexo { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public bool EstaDisponible { get; set; } = true;
        public int Ciudad { get; set; }
        public int Comuna { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string EstadoCivil { get; set; }
        public int ContratoEmpId { get; set; } = 0;
        public int SueldoEmpId { get; set; } = 0;
        public int PrevisionEmpId { get; set; } = 0;
        public int EmpresaEmpleadoId { get; set; }
        public List<ColeccionHaberesEmpleado> ListadoHaberes { get; set; }
        public List<ColeccionDescuentosEmpleado> ListadoDescuentos { get; set; }
        public virtual FichaEmpresa EmpresaEmpleado { get; set; }
        public virtual ContratoEmpleado ContratoEmp { get; set; }
        public virtual SueldoEmpleado SueldoEmp { get; set; }
        public virtual PrevisionEmpleado PrevisionEmp { get; set; }

        //Nota cuando se crea al empleado y se le asigna una empresa y un contrato también se le asigna una coleccion de haberes y descuentos por defecto con coherencia a su contrato

        public static List<ListaEmpleadoRequestModel> ListarEmpleados(remuneracionesContext db)
        {
            List<ListaEmpleadoRequestModel> lstEmpleados = new List<ListaEmpleadoRequestModel>();

                lstEmpleados = db.Tbempleados.Select(x => new ListaEmpleadoRequestModel()
                {
                    Id = x.Id,
                    Rut = x.Rut,
                    Nombre = x.Nombre,
                    Apellido  = x.Apellido,
                    FechaNacimiento = x.FechaNacimiento.ToString("dd-MM-yyyy")
                }).ToList();
            

            return lstEmpleados;
        }


        public static bool InsertarEmpleado(FichaEmpleadoRequestModel NuevoEmp, remuneracionesContext db)
        {
            bool Result = false;

    
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Tbempleados InsertEmpleado = new Tbempleados();
                        SueldoEmpleado InsertEmpleadoSueldo = new SueldoEmpleado();
                        ContratoEmpleado InsertEmpleadoContrato = new ContratoEmpleado();
                        PrevisionEmpleado InsertEmpleadoPrevi = new PrevisionEmpleado();
                        List<Tbempleados> LstEmpleados = new List<Tbempleados>();

                        FichaEmpresa ObjEmpresa = new FichaEmpresa();
                        ObjEmpresa.RazonSocial = "TestEmpresa";
                        ObjEmpresa.lstEmpleados = LstEmpleados;
                        ObjEmpresa.Comuna = 1;
                        ObjEmpresa.Direccion = "Barca 2560";
                        ObjEmpresa.Principal = true;
                        ObjEmpresa.Rut = "13519830-7";
                        ObjEmpresa.TipoEmpresa = 1;
                        ObjEmpresa.Giro = "Venta";
                        ObjEmpresa.RepresentanteLegal = "PedritoVega";
                        ObjEmpresa.RutRepresentanteLegal = "19507432-1";
                        ObjEmpresa.Vigente = true;
                        ObjEmpresa.FormaPagoGratif = 1;
                        ObjEmpresa.FormPagoMoviColacion = 1;
                        ObjEmpresa.UsuarioEmpresaId = 1;

                        InsertEmpleado.EstaDisponible = Convert.ToBoolean(NuevoEmp.EstaVigente);
                        InsertEmpleado.Nombre = NuevoEmp.Nombre;
                        InsertEmpleado.Apellido = NuevoEmp.Apellido;
                        InsertEmpleado.Rut = NuevoEmp.Rut;
                        InsertEmpleado.Nacionalidad = NuevoEmp.Nacionalidad;
                        InsertEmpleado.Email = NuevoEmp.EmailPersonal;
                        InsertEmpleado.Direccion = NuevoEmp.NumCasa + "  " + NuevoEmp.Departamento + "  " + NuevoEmp.Calle;
                        InsertEmpleado.Sexo = Convert.ToInt32(NuevoEmp.Sexo);
                        InsertEmpleado.Telefono = Convert.ToInt32(NuevoEmp.Telefono);
                        InsertEmpleado.FechaNacimiento = Helpers.Utiles.ToDD_MM_AAAA_Multi(NuevoEmp.FechaNacimiento);
                        InsertEmpleado.FechaCreacion = DateTime.Now;


                        //Contrato
                        InsertEmpleadoContrato.ContratoDesde = Helpers.Utiles.ToDD_MM_AAAA_Multi(NuevoEmp.ContratoDesde);
                        InsertEmpleadoContrato.ContratoHasta = Helpers.Utiles.ToDD_MM_AAAA_Multi(NuevoEmp.ContratoHasta);
                        CargosModel Cargo = new CargosModel();
                        if(NuevoEmp.Cargo != "Selecciona")
                        {
                             Cargo = db.CargosModel.Where(x => x.Id == Convert.ToInt32(NuevoEmp.Cargo)).FirstOrDefault();
                        }
                         InsertEmpleadoContrato.Cargo = Cargo;

                        //Sueldo
                        InsertEmpleadoSueldo.AsignColacion = Convert.ToDecimal(NuevoEmp.AsignColacion);
                        InsertEmpleadoSueldo.AsignMovilizacion = Convert.ToDecimal(NuevoEmp.AsignMovilizacion);
                        InsertEmpleadoSueldo.SueldoBase = Convert.ToDecimal(NuevoEmp.SueldoBase);
                        InsertEmpleadoSueldo.CuentaCorriente = Convert.ToInt32(NuevoEmp.NumCuenta);

                        AfpModel AfpEmpleado = db.AfpModel.SingleOrDefault(x => x.Id == Convert.ToInt32(NuevoEmp.AFPId));

                        //Prevision
                        //ver la posilidad de nulos en las relaciones
                        var isapreObject = new IsapreModel();
                        InsertEmpleadoPrevi.AFPId = AfpEmpleado.Id;
                        if (!string.IsNullOrWhiteSpace(NuevoEmp.IsapreId) && !string.IsNullOrWhiteSpace(NuevoEmp.IsapreTipoMonto))
                        {
                            int TipoMontoPac = Convert.ToInt32(NuevoEmp.IsapreTipoMonto);
                            TipoMontoPactado TipoMontoNuevoEmp = (TipoMontoPactado)TipoMontoPac;
                            InsertEmpleadoPrevi.Tipo = TipoMontoNuevoEmp;
                            InsertEmpleadoPrevi.IsapreId = Convert.ToInt32(NuevoEmp.IsapreId);
                            InsertEmpleadoPrevi.MontoPactadoIsapre = Convert.ToDecimal(NuevoEmp.IsapreMonto);
                        }
                         InsertEmpleadoPrevi.Isapre = isapreObject;

                        InsertEmpleado.ContratoEmp = InsertEmpleadoContrato;
                        InsertEmpleado.SueldoEmp = InsertEmpleadoSueldo;
                        InsertEmpleado.PrevisionEmp = InsertEmpleadoPrevi;


                        //Registro de haberes y descuentos base.
                        LstEmpleados.Add(InsertEmpleado);

                        db.FichaEmpresa.Add(ObjEmpresa);
                        db.Tbempleados.Add(InsertEmpleado);
                        db.SaveChanges();

                        List<ColeccionHaberes> LsthaberesAregistrar = new List<ColeccionHaberes>()
                        {
                            new ColeccionHaberes(){ Nombre = "Sueldo Base", Categoria_id = CategoriaHaberes.IMPONIBLE, ValorCalculo = InsertEmpleadoSueldo.SueldoBase, EmpresaId = ObjEmpresa.Id},
                            new ColeccionHaberes(){ Nombre = "Movilizacion",Categoria_id = CategoriaHaberes.NOIMPONIBLE, ValorCalculo = InsertEmpleadoSueldo.AsignMovilizacion, EmpresaId = ObjEmpresa.Id},
                            new ColeccionHaberes(){ Nombre = "Colacion", Categoria_id = CategoriaHaberes.NOIMPONIBLE, ValorCalculo = InsertEmpleadoSueldo.AsignColacion, EmpresaId = ObjEmpresa.Id }
                        };
                        //Por Evaluar
                        List<ColeccionDescuentos> LstDescuentosAregistrar = new List<ColeccionDescuentos>()
                        {
                            new ColeccionDescuentos(){ Nombre =  InsertEmpleadoPrevi.AFP.NombreAfp, ValorCalculo = AfpEmpleado.DependientesTasaAfp, EmpresaId = ObjEmpresa.Id }
                        };

                        db.ColeccionHaberes.AddRange(LsthaberesAregistrar);
                        db.ColeccionDescuentos.AddRange(LstDescuentosAregistrar);
                        db.SaveChanges();


                        var LstHaberesYdescARegistrar = new List<HaberesYDescuentosEmpleado>();
                        foreach (ColeccionHaberes ItemHaber in LsthaberesAregistrar)
                        {
                            var HaberAResgistrar = new HaberesYDescuentosEmpleado()
                            {
                                EmpleadoId = InsertEmpleado.Id,
                                EmpresaId = ObjEmpresa.Id,
                                HaberOdescuentoId = ItemHaber.Id,
                                TipoHoD = TipoHaberODescuento.HABER,
                                Monto = ItemHaber.ValorCalculo

                            };
                            LstHaberesYdescARegistrar.Add(HaberAResgistrar);
                        }

                        foreach (ColeccionDescuentos ItemDescuento in LstDescuentosAregistrar)
                        {
                            var DescuentoARegistrar = new HaberesYDescuentosEmpleado()
                            {
                                EmpleadoId = InsertEmpleado.Id,
                                EmpresaId = ObjEmpresa.Id,
                                HaberOdescuentoId = ItemDescuento.Id,
                                TipoHoD = TipoHaberODescuento.DESCUENTO,
                                Monto = Convert.ToDecimal(ItemDescuento.ValorCalculo)
                            };
                            LstHaberesYdescARegistrar.Add(DescuentoARegistrar);
                        }

                        db.HaberesYDescuentosEmpleado.AddRange(LstHaberesYdescARegistrar);
                        db.SaveChanges();

                        dbContextTransaction.Commit();
                        Result = true;
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                    }

                }
            


            return Result;
        }

        public static LiquidacionEmpleado ObtenerLiquidacionEmpleado(int IdEmp, remuneracionesContext db)
        {
            if (IdEmp <= 0) return null;

            var Liquidacion = new LiquidacionEmpleado();
      
                try
                {
                    //Falta listar los topes y tramos.
                    //Tope Gratificacion
                    //Tope Seguro de cesantia
                    //Tope Imposiciones -> al parecer tiene que ver con las afp o con todos los descuentos
                    //Tope Salud
                    //Si es fonasa calcular por el 7%
                    //calcular monto AFP
                    //Seguro de Cesantia


                    //----- GRATIFICACION -----
                    //Existen calculos de gratificaciones del articulo 50 y el articulo 47
                    //----- CONTRATOS --------
                    //----- LOS PLAZOS DE TODOS LOS CONTRATOS VAN EN LA CLAUSULA NOVENA DE LOS ARTICULOS ------------------
                    //contrato individual y contrato colectivo Articulo 6 indiviual -> empleador a trabajador
                    //Colectivo de uno o más empleadores con una o más organizaciones sindicales
                    //Contrato por plazo: Plazo fijo, indefinido
                    //Contrato por obra o faena Articulo 10 bis
                    //Contrato por jornada parcial Articulo 40 bis
                    //Contratos Especiales Articulos  77 al 152
                    //------SALUD-------
                    //Cuando calculamos salud aveces hay montos adicionales por reglas que desconozco
                    //Es Isapre -> (Pueden ser muchas) o Fonasa que está aislado y con sus reglas
                    //Isapre tiene más beneficios pero es más costoso y cada isapre tiene sus montos y reglas además de reglas estantard para cada una
                    //Fonasa es más economico y más barato pero con más problemas de atención y menos beneficios.
                    //Se puede definir como Fonasa para el sector(publico) y Isapre (Privado)
                    //Si estás en fonasa te asignan un tramo el que indicara tu nivel de cobertura dependiendo del sueldo tendrás más cobertura o no siempre será el 7% de tu sueldo
                    //En Isapre si puedes elegir
                    //Fonasa en fijo Isapre es dinamico
                    //IMPORTANTE Si tienes y Isapre y el 7% de tu sueldo llega a un monto que cubre tu plan de isapre solo se descuenta ese 7% en caso
                    //Que el 7% de tu sueldo no cubra el plan de la isapre a la que perteneces entonces se cobrará adicional
                    //Considerar Seguro de vida...

                    //DESCUENTOS
                    //Además de la AFP hay que considerar cosas como el S.I.S = Seguro de invalidez y sobrevivencia.
                    //Considerar Aguinaldo
                    //Considerar anticipo
                    //Considerar APV
                    //Cuota sindical
                    //Impuesto Unico

                    //CALCULO IMPUESTO UNICO
                    // Any IPU = "Impuesto Unico"
                    //1.- Revisar la tabla proveida por el SII
                    //2.- Revisar el tramo en el que está el trabajador
                    //3.- Calcular antes el imponible tributable F(Total Imponible - Descuentos)
                    //------ VARIABLES CALCULO IMPUESTO UNICO --------
                    //1.- F((Imponible tributable * Factor(Es el exento de la tabla IPU)) - Monto Rebaja)
                    // simplificado ((ImponibleT * Exento) - MontoRebaja)


                    List<RentasTopasImpModel> TopesRentasImponibles = db.RentasTopasImpModel.ToList();

                    decimal AFPTope = TopesRentasImponibles.SingleOrDefault(x => x.Tope_id == TipoTope.AFP && x.EstaActiva == true).UFCLP;
                    decimal IPSTope = TopesRentasImponibles.SingleOrDefault(x => x.Tope_id == TipoTope.IPS && x.EstaActiva == true).UFCLP;
                    decimal SCesantiaTope = TopesRentasImponibles.SingleOrDefault(x => x.Tope_id == TipoTope.SEGURO_CESANTIA && x.EstaActiva == true).UFCLP;

                    List<RentasMinImponibles> rentasMinImponibles = db.RentasMinImponibles.ToList();


                    List<AFCModel> AFCRules = db.AFCModel.Where(x => x.EstaActivo == true).ToList();

                    UTMModel UTM = db.UTMModel.SingleOrDefault(x => x.EstaActiva == true);
                    IMMModel SueldoMinimo = db.IMMModel.SingleOrDefault(x => x.EstaActiva == true);
                    UFModel UF = db.UFModel.SingleOrDefault(x => x.EstaActiva == true);

                    IndicadoresEconomicos Indicadores = new IndicadoresEconomicos()
                    {
                        UF = UF,
                        UTM = UTM,
                        SueldoMinimo = SueldoMinimo
                    };

                    int CantidadHorasTrabajadas = 0;

                    Liquidacion.indicadoresEco = Indicadores;

                    var LstHaberImponible = new List<HaberImponible>();
                    var LstHaberNoImponible = new List<HaberNoImponible>();
                    var LstDescuentos = new List<DescuentosLiquidacion>();

                    Tbempleados ObjEmpleado = db.Tbempleados.Include(e => e.EmpresaEmpleado)
                                                            .Include(s => s.SueldoEmp)
                                                            .Include(c => c.ContratoEmp)
                                                            .ThenInclude(cargo => cargo.Cargo)
                                                            .Include(p => p.PrevisionEmp)
                                                            .ThenInclude(a => a.AFP)
                                                            .SingleOrDefault(Emp => Emp.Id == IdEmp);


                    InfoEmpleadoEmpresa InfoEmp = new InfoEmpleadoEmpresa()
                    {
                        EmpleadoId = ObjEmpleado.Id.ToString(),
                        NombreEmpleado = ObjEmpleado.Nombre,
                        RutEmpleado = ObjEmpleado.Rut,
                        CargoEmpleado = ObjEmpleado.ContratoEmp.Cargo.Nombre,
                        FechaIngresoEmpleado = ObjEmpleado.FechaCreacion.ToString("dd-MM-yyyy"),
                        RazonSocialEmpresa = ObjEmpleado.EmpresaEmpleado.RazonSocial,
                        RutEmpresa = ObjEmpleado.EmpresaEmpleado.Rut,
                        DireccionEmpresa = ObjEmpleado.EmpresaEmpleado.Direccion
                    };

                    List<ImpuestoUnico> InfoImpuestoUnicoActual = db.ImpuestoUnico.Where(x => x.EstaActiva == true).ToList();

                    AfpModel AFP = ObjEmpleado.PrevisionEmp.AFP;
                    ContratoEmpleado Contrato = ObjEmpleado.ContratoEmp;
                    CantidadHorasTrabajadas = Contrato.HorasDeJornada;


                    if (ObjEmpleado != null)
                    {
                        var HyDemp = ServiciosHyD.ObtenerHyDEmpleado(IdEmp, db);

                        if (HyDemp.Item1.Count() <= 0 || HyDemp.Item2.Count() <= 0) return null;

                        LstHaberImponible = HyDemp.Item1.Where(x => x.Categoria_id == CategoriaHaberes.IMPONIBLE)
                        .Select(x => new HaberImponible
                        {
                            NombreHaber = x.Nombre,
                            MontoHaber = x.ValorCalculo
                        }).ToList();

                        LstHaberNoImponible = HyDemp.Item1.Where(x => x.Categoria_id == CategoriaHaberes.NOIMPONIBLE)
                        .Select(x => new HaberNoImponible
                        {
                            NombreHaber = x.Nombre,
                            MontoHaber = x.ValorCalculo
                        }).ToList();

                        LstDescuentos = HyDemp.Item2.Select(x => new DescuentosLiquidacion
                        {
                            NombreDescuento = x.Nombre,
                            MontoDescuento = x.ValorCalculo
                        }).ToList();

                        decimal CalculoDescuentoAFP = CalculosLiquidacion.CalculoAFPIndefinido(AFP.DependientesTasaAfp, ObjEmpleado.SueldoEmp.SueldoBase, AFPTope);
                        string DescuentoAFPNombre = CalculosLiquidacion.VistaPorcentajeLiquidacion(AFP.DependientesTasaAfp, CalculoDescuentoAFP, AFP.NombreAfp);

                        //Busca el registro del descuento AFP y updatea el monto
                        LstDescuentos.Where(x => x.NombreDescuento == AFP.NombreAfp)
                                     .Select(x =>
                                            {
                                                x.NombreDescuento = DescuentoAFPNombre;
                                                x.MontoDescuento = CalculoDescuentoAFP;
                                                return x;
                                            }).ToList();

                        //verificar si hay que calcularla o se deja directamente así
                        decimal MontoGratificacion = CalculosLiquidacion.CalcularGratificacionLegal(ObjEmpleado.SueldoEmp.SueldoBase, 0, 0, db);
                        var GratificacionLegal = new HaberImponible()
                        {
                            NombreHaber = "Gratificación",
                            MontoHaber = MontoGratificacion
                        };
                        LstHaberImponible.Add(GratificacionLegal);

                        decimal TotalHaberesImponibles = LstHaberImponible.Sum(x => x.MontoHaber);
                        decimal TotalHaberesNoImp = LstHaberNoImponible.Sum(x => x.MontoHaber);

                        decimal TotalDescuentoCesantia = CalculosLiquidacion.CalculoSeguroDeCesantia(TotalHaberesImponibles, AFCRules.FirstOrDefault().FinanciamientoEmpleado, SCesantiaTope);
                        var DescuentoCesantia = new DescuentosLiquidacion()
                        {
                            NombreDescuento = "Seguro de Cesantia",
                            MontoDescuento = TotalDescuentoCesantia
                        };
                        LstDescuentos.Add(DescuentoCesantia);

                        decimal TotalDescuentoSalud = CalculosLiquidacion.CalculoFonasa(TotalHaberesImponibles);
                        if (ObjEmpleado.PrevisionEmp.IsapreId > 0 && ObjEmpleado.PrevisionEmp.MontoPactadoIsapre > 0)
                        {
                            decimal MontoIsapre = 0;

                            MontoIsapre = CalculosLiquidacion.ProcesarMontoPactadoIsapre(ObjEmpleado.PrevisionEmp, UF.Valor);

                            if (MontoIsapre > TotalDescuentoSalud)
                            {
                                decimal MontoAdicional = 0;
                                MontoAdicional = CalculosLiquidacion.MontoIsapreAdicional(TotalDescuentoSalud, MontoIsapre);

                                var DescuentoIsapre = new DescuentosLiquidacion()
                                {
                                    NombreDescuento = "Isapre",
                                    MontoDescuento = TotalDescuentoSalud
                                };

                                var DescuentosAdicional = new DescuentosLiquidacion()
                                {
                                    NombreDescuento = "Adicional",
                                    MontoDescuento = MontoAdicional
                                };

                                LstDescuentos.Add(DescuentoIsapre);
                                LstDescuentos.Add(DescuentosAdicional);
                            }
                            else if(TotalDescuentoSalud >= MontoIsapre)
                            {
                                var DescuentosSaludIsapre = new DescuentosLiquidacion()
                                {
                                    NombreDescuento = "Isapre",
                                    MontoDescuento = TotalDescuentoSalud
                                };
                                LstDescuentos.Add(DescuentosSaludIsapre);
                            }
                        }
                        else
                        {
                            var DescuentoSaludFonasa = new DescuentosLiquidacion()
                            {
                                NombreDescuento = "Fonasa",
                                MontoDescuento = TotalDescuentoSalud
                            };
                            LstDescuentos.Add(DescuentoSaludFonasa);

                        }

                        decimal TotalDescuentos = LstDescuentos.Sum(x => x.MontoDescuento);
                        decimal TotalImponibleTributable = CalculosLiquidacion.CalcularImponibleTributable(TotalHaberesImponibles, TotalDescuentos);

                        bool EstaAfectaAimp = CalculosLiquidacion.EstaAfectaAimpuestos(InfoImpuestoUnicoActual, TotalImponibleTributable);
                        decimal TotalImpuestoUnico = 0;

                        if (EstaAfectaAimp) TotalImpuestoUnico = CalculosLiquidacion.CalculoImpuestoUnico(InfoImpuestoUnicoActual, TotalImponibleTributable);

                        if (TotalImpuestoUnico > 0)
                        {
                            var DescuentoImpuestoUnico = new DescuentosLiquidacion()
                            {
                                NombreDescuento = "Impuesto Único",
                                MontoDescuento = TotalImpuestoUnico
                            };
                            LstDescuentos.Add(DescuentoImpuestoUnico);
                        }

                        decimal TotalHaberes = TotalHaberesImponibles + TotalHaberesNoImp;

                        Liquidacion.MesLiquidacion = Utiles.obtenerNombreMes(DateTime.Now.Month);
                        Liquidacion.InfoEmpleado = InfoEmp;
                        Liquidacion.lstHaberImponible = LstHaberImponible;
                        Liquidacion.lstHaberNoImponible = LstHaberNoImponible;
                        Liquidacion.HorasTrabajadas = ObjEmpleado.ContratoEmp.HorasDeJornada;
                        Liquidacion.indicadoresEco = Indicadores;
                        Liquidacion.lstDescuentos = LstDescuentos;
                        Liquidacion.FechaLiquidacion = DateTime.Now.ToString("dd-MM-yyyy");
                        Liquidacion.TotalHaberes = TotalHaberes;
                        Liquidacion.TotalDescuentos = TotalDescuentos;
                        Liquidacion.TotalHaberesImp = TotalHaberesImponibles;
                        Liquidacion.TotalHaberesNoImp = TotalHaberesNoImp;
                        Liquidacion.TotalLiquido = TotalHaberes - TotalDescuentos;

                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
            

            return Liquidacion;
        }

        public static bool AgregarLiquidacion(int IdEmp, remuneracionesContext db)
        {
            bool Result = false;

            LiquidacionEmpleado LiquidacionEmpleado = ObtenerLiquidacionEmpleado(IdEmp, db);
            Result = ServiciosLiquidacion.InsertarLiquidacion(LiquidacionEmpleado, db);

            return Result;
        }

        public static LiquidacionEmpleado ObtenerEmpleado(int IdEmp, remuneracionesContext db)
    {
            var UTM = db.UTMModel.FirstOrDefault(); //Esta logica puede cambiar en el futuro cuando se inserten las nuevas fechas
            var SueldoMinimo = db.IMMModel.FirstOrDefault();
            var UF = db.UFModel.FirstOrDefault();

            IndicadoresEconomicos Indicadores = new IndicadoresEconomicos();
            Indicadores.UF = UF;
            Indicadores.UTM = UTM;
            Indicadores.SueldoMinimo = SueldoMinimo;

            var ObjEmpleado = db.Tbempleados.Include(c => c.ContratoEmp)
                                            .Include(s => s.SueldoEmp)
                                            .Include(p => p.PrevisionEmp)
                                            .ThenInclude(a => a.AFP)
                                            .SingleOrDefault(Emp => Emp.Id == IdEmp);

            LiquidacionEmpleado DatosLiquidacion = new LiquidacionEmpleado();
            HaberImponible HaberImp = new HaberImponible();
            HaberImponible HaberImp2 = new HaberImponible();
            HaberNoImponible HaberNoImp = new HaberNoImponible();
            HaberNoImponible HaberNoImp2 = new HaberNoImponible();
            DescuentosLiquidacion Descuentos = new DescuentosLiquidacion();

            var DatosEmpleado = new InfoEmpleadoEmpresa();
            var lstHaberImponible = new List<HaberImponible>();
            var lstHaberNoImponible = new List<HaberNoImponible>();
            var lstDescuentos = new List<DescuentosLiquidacion>();

            SueldoEmpleado InfoSueldoEmp = ObjEmpleado.SueldoEmp;
            AfpModel InfoAFP = ObjEmpleado.PrevisionEmp.AFP;
            ContratoEmpleado Contrato = ObjEmpleado.ContratoEmp;

            if (InfoSueldoEmp.SueldoBase > 0)
            {
                HaberImp.NombreHaber = "Sueldo Base";
                HaberImp.MontoHaber = InfoSueldoEmp.SueldoBase;
            }
            if (InfoSueldoEmp.AsignMovilizacion > 0)
            {
                HaberNoImp.NombreHaber = "Movilización";
                HaberNoImp.MontoHaber = InfoSueldoEmp.AsignMovilizacion;
            }
            if (InfoSueldoEmp.AsignColacion > 0)
            {
                HaberNoImp2.NombreHaber = "Colación";
                HaberNoImp2.MontoHaber = InfoSueldoEmp.AsignColacion;
            }
            if (InfoAFP != null)
            {
                decimal CalculoDescuento = InfoSueldoEmp.SueldoBase * InfoAFP.DependientesTasaAfp;



                decimal VistaPorcentaje = Math.Round(InfoAFP.DependientesTasaAfp * 100, 2);

                Descuentos.NombreDescuento = "AFP:" + " " + InfoAFP.NombreAfp + "{ " + VistaPorcentaje.ToString() + "%" + " }";
                Descuentos.MontoDescuento = CalculoDescuento;
            }

            DatosEmpleado.NombreEmpleado = ObjEmpleado.Nombre;
            DatosEmpleado.RutEmpleado = ObjEmpleado.Rut;
            DatosEmpleado.CargoEmpleado = db.CargosModel.SingleOrDefault(x => x.Id == Contrato.CargoId).Nombre;
            DatosEmpleado.FechaIngresoEmpleado = ObjEmpleado.FechaCreacion.ToString("dd-MM-yyyy");

            lstHaberImponible.Add(HaberImp);
            lstHaberNoImponible.Add(HaberNoImp);
            lstHaberNoImponible.Add(HaberNoImp2);
            lstDescuentos.Add(Descuentos);

            decimal MontoBonoDePrueba = 100000;
            decimal MontoHorasExtras = 50000;
            decimal MontoGratificacion = CalculosLiquidacion.CalcularGratificacionLegal(InfoSueldoEmp.SueldoBase, MontoHorasExtras, MontoBonoDePrueba, db);
            HaberImp2.NombreHaber = "Gratificacion";
            HaberImp2.MontoHaber = MontoGratificacion;

            lstHaberImponible.Add(HaberImp2);

            decimal TotalHaberes = lstHaberImponible.Sum(x => Convert.ToDecimal(x.MontoHaber)) + lstHaberNoImponible.Sum(x => Convert.ToDecimal(x.MontoHaber));
            decimal TotalDescuentos = lstDescuentos.Sum(x => Convert.ToDecimal(x.MontoDescuento));

            DatosLiquidacion.InfoEmpleado = DatosEmpleado;
            DatosLiquidacion.lstDescuentos = lstDescuentos;
            DatosLiquidacion.lstHaberImponible = lstHaberImponible;
            DatosLiquidacion.lstHaberNoImponible = lstHaberNoImponible;
            DatosLiquidacion.indicadoresEco = Indicadores;
            DatosLiquidacion.TotalHaberes = TotalHaberes;
            DatosLiquidacion.TotalDescuentos = TotalDescuentos;

                //Planificación liquidación

                //F() -> Formula utilizada para calcular "X" cosa

                //Datos principales
                //UTM | UF | Sueldo minimo

                //B2 = UF, B3 = UTM, B4 = SM

                //Se calculan con...
                //Monto gratificacion -> F(SM * Gratificacion(¿Monto pactado?) / 12) ¿Los meses del año "12"?
                //Tope Imp AFP        -> F(UF * tope imp.afp y salud)
                //tope imp.ces        -> F(UTM * tope imp.cesantia)
                //Gratificación       -> F(if(base gratificacion * tope gratificacion) > tope gratificación){ Monto Gratificación else{ F(base gratificacion * tope gratificacion)}}
                //Con palabras lo de arriba -> Si la (Base gratificacion * tope gratificacion son mayores al monto gratificacion entonces usar el monto gratificacion ya que no se puede pasar de este monto si no dejar el monto multiplicado por la base gratificacion y el tope gratificacion)

                //Total haberes imponibles F(SUMA DE TODOS LOS QUE CAEN EN ESTA CATEGORIA) (Hecho)
                //Total haberes no imp F(SUMA DE TODOS LOS QUE CAEN EN ESTA CATEGORIA) (Hecho)

                //Descuentos legales F(SUMA DE TODOS LOS QUE CAEN EN ESTA CATEGORIA)

                //Otros descuentos (Anticipo por ejemplo), (TODO LO QUE NO CAIGA DENTRO DE LAS OTRAS CATEGORIAS ES OTROS DESCUENTOS Y OBVIO LA SUMATORIA DE TODOS LOS QUE CAIGAN EN ESTA CATEGORIA DAN EL TOTAL DE ESTA CATEGORIA)

                //Liquido a pagar -> F( (hab.imponibles + hab.no imponibles) - (Descuentos legales - Otros descuentos) )

                //Base gratificación -> F(Sueldo Base + Otros Haberes)
                //Impuesto único

                //¿Cual es el sueldo bruto?
                // R: El sueldo base más la gratificación, comisiones u horas extrás es tu sueldo bruto (total haberes)
                //    , que es el dinero que la empresa debe pagar por tenerte en la empresa.


                //Dependencias de la liquidacion de sueldo

                //DEPENDENCIAS OBLIGATORIAS
                //UF, UTM, Sueldo minimo
                //Horas extras -> Cantidad de horas trabajadas -> dias trabajados
                //Gratificaciones
                //Salud
                //Seguro de cesantia
                //Impuesto unico...

                //DEPENDENCIAS OPCIONALES
                //Semana Corrida (opcional)
                // APV (opcional)
                //Comisiones (opcional)
                //Bonos (opcional)
                //Otros descuentos legales (opcional)
                //Otros descuentos (opcional)
                //Asignación familiar (opcional)


                //Calculo gratificación legal con el articulo 50
                //Se considera: F((Sueldo base + Horas extras + Bonos imponibles) * 25%)
                //Todo esto considerando los topes de IMM (Ingreso minimo mensual)

                //Ejemplo gratificación 25%
                //Sueldo base: $320.500
                //Horas Extras: $57.000
                //Bono de producción: $120.000
                //Total: 497.500
                // F(Total * 25%) = $124.375 (En este caso al no super los 4.75 IMM puede obtener el 100% de la gratificación)
                // F(IMM * 4.75) = 1.522.375 -> Este es el tope maximo que se puede recibir por gratificación ANUAL.
                // F(IMM * 4.75) = 1.522.375 / 12 = 126.865 -> Este es el tope maximo de gratificación MENSUAL
                // Se concluye el ejemplo: En este caso se pagará la gratificación mensual calculada en primera instancia.
                // Ya que es menor al tope mensual de gratificación permitida según el articulo 50.
                return DatosLiquidacion;
            
        }

        public static bool ActualizarEmpleado(Tbempleados Emp)
        {
            bool Result = false;
            using (remuneracionesContext db = new remuneracionesContext())
            {
                db.Tbempleados.Update(Emp);
                db.SaveChanges();
                Result = true;
            }

            return Result;
        }

        public static bool DarDeBajaempleado(Tbempleados Emp)
        {
            bool Result = false;

            using (remuneracionesContext db = new remuneracionesContext())
            {
                Emp.EstaDisponible = false;
                db.Tbempleados.Update(Emp);
                db.SaveChanges();
                Result = true;
            }

            return Result;
        }

        public static int AgregarEmpDesdeExcel(List<List<string>> ExcelEmp, remuneracionesContext db)
        {
            int Result = 0;
            ExcelEmp.RemoveAt(0);
            List<Tbempleados> EmpleadoToEmpresa = new List<Tbempleados>();
   

            FichaEmpresa ObjEmpresa = new FichaEmpresa();
            ObjEmpresa.RazonSocial = "TestEmpresa";
            ObjEmpresa.lstEmpleados = EmpleadoToEmpresa;
            ObjEmpresa.Comuna = 1;
            ObjEmpresa.Direccion = "Barca 2560";
            ObjEmpresa.Principal = true;
            ObjEmpresa.Rut = "13519830-7";
            ObjEmpresa.TipoEmpresa = 1;
            ObjEmpresa.Giro = "Venta de weas";
            ObjEmpresa.RepresentanteLegal = "PedritoVega";
            ObjEmpresa.RutRepresentanteLegal = "19507432-1";
            ObjEmpresa.Vigente = true;
            ObjEmpresa.FormaPagoGratif = 1;
            ObjEmpresa.FormPagoMoviColacion = 1;

            foreach (List<string> Columna in ExcelEmp)
            {
                string AFPExcel = Columna[23];

                var AFPempleado = db.AfpModel.SingleOrDefault(AFP => AFP.NombreAfp == AFPExcel);

                string Rut = Columna[0];
                string Nombre = Columna[1];
                string Apellido = Columna[2];
                string Nacionalidad = Columna[7];
                int Telefono = Convert.ToInt32(Columna[9]);
                string Cargo = Columna[17]; //La idea es que Cargo sea un int

                decimal SueldoBase = Convert.ToDecimal(Columna[30]);
                decimal Movilizacion = Convert.ToDecimal(Columna[31]);
                decimal Colacion = Convert.ToDecimal(Columna[32]);

                CargosModel CargoACrear = new CargosModel() { Nombre = Cargo, Detalle = "Sin Detalle" };
                db.CargosModel.Add(CargoACrear);
                db.SaveChanges();

                DateTime FechaNacimiento = Utiles.ToDD_MM_AAAA_Multi(Columna[3]);

                SueldoEmpleado ObjSueldo = new SueldoEmpleado
                {
                    SueldoBase = SueldoBase,
                    AsignMovilizacion = Movilizacion,
                    AsignColacion = Colacion
                };

                ContratoEmpleado ObjContrato = new ContratoEmpleado
                {
                    Cargo = CargoACrear
                };

                PrevisionEmpleado ObjPrevision = new PrevisionEmpleado();
                if (AFPempleado != null)
                {
                    ObjPrevision.AFP = AFPempleado;
                }

                Tbempleados EmpleadoAInsertar = new Tbempleados
                {
                    Rut = Rut,
                    Nombre = Nombre,
                    Apellido = Apellido,
                    FechaNacimiento = FechaNacimiento,
                    Nacionalidad = Nacionalidad,
                    Telefono = Telefono,
                    SueldoEmp = ObjSueldo,
                    ContratoEmp = ObjContrato,
                    PrevisionEmp = ObjPrevision,
                    EmpresaEmpleado = ObjEmpresa
                };

                EmpleadoToEmpresa.Add(EmpleadoAInsertar);
            }

            db.FichaEmpresa.Add(ObjEmpresa);
            db.Tbempleados.AddRange(EmpleadoToEmpresa);
            Result = db.SaveChanges();

            return Result;
        }



    }
}
