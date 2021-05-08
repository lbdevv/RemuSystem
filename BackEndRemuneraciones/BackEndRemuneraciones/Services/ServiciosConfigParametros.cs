using System;
using System.Collections.Generic;
using System.Linq;
using BackEndRemuneraciones.Helpers;
using BackEndRemuneraciones.Models;
using BackEndRemuneraciones.Models.ModelosVariables;
using BackEndRemuneraciones.Services.RequestConfigServices;
using BackEndRemuneraciones.Models.Data;

namespace BackEndRemuneraciones.Services
{
    public class ServiciosConfigParametros
    {


        public static bool ActualizarIndicadoresEconomicos(RequestIE Request, remuneracionesContext db)
        {
            bool Result = false;
            try
            {
                if (!string.IsNullOrWhiteSpace(Request.MontoIMM) &&
                    !string.IsNullOrWhiteSpace(Request.MontoUTM) &&
                    !string.IsNullOrWhiteSpace(Request.MontoUF))
                {
                    IMMModel IMMactiva = db.IMMModel.SingleOrDefault(x => x.EstaActiva);
                    IMMactiva.EstaActiva = false;
                    db.IMMModel.Update(IMMactiva);

                    IMMModel NuevaIMM = new IMMModel()
                    {
                        Nombre = IMMactiva.Nombre,
                        Fecha = Utiles.ToDD_MM_AAAA_Multi(Request.FechaIMM),
                        Valor = Convert.ToDecimal(Request.MontoIMM),
                        EstaActiva = true
                    };

                    db.IMMModel.Add(NuevaIMM);


                    UTMModel UTMactiva = db.UTMModel.SingleOrDefault(x => x.EstaActiva);
                    UTMactiva.EstaActiva = false;
                    db.UTMModel.Update(UTMactiva);

                    UTMModel NuevaUTM = new UTMModel()
                    {
                        Nombre = UTMactiva.Nombre,
                        Fecha = Utiles.ToDD_MM_AAAA_Multi(Request.FechaUTM),
                        Valor = Convert.ToDecimal(Request.MontoUTM),
                        EstaActiva = true
                    };

                    db.UTMModel.Add(NuevaUTM);


                    UFModel UFactiva = db.UFModel.SingleOrDefault(x => x.EstaActiva);
                    UFactiva.EstaActiva = false;
                    db.UFModel.Update(UFactiva);

                    UFModel NuevaUF = new UFModel()
                    {
                        Nombre = UFactiva.Nombre,
                        Fecha = Utiles.ToDD_MM_AAAA_Multi(Request.FechaUF),
                        Valor = Convert.ToDecimal(Request.MontoUF),
                        EstaActiva = true
                    };

                    db.UFModel.Add(NuevaUF);

                    db.SaveChanges();
                    Result = true;
                }
            }
            catch (Exception)
            {
                Result = false;
            }

            return Result;
        }

        public static bool ActualizarAFP(RequestAFP Request, remuneracionesContext db)
        {
            bool Result = false;        
            try{
                if(Request != null)
                {
                    //revisar esto para cuando se cambien todos los valores
                    List<AfpModel> AFPactiva = db.AfpModel.Where(x => x.EstaActiva).ToList();
                    AFPactiva.Select(x => { x.EstaActiva = false; return x; });
                    db.AfpModel.UpdateRange(AFPactiva);

                    AfpModel NuevosDatosAfp = new AfpModel()
                    {
                        NombreAfp = Request.NombreAFP,
                        DependientesTasaAfp = UtilesLiquidacion.DePorcentajeAdecimal(Request.PorcentajeTasaAFP),
                        IndependientesTasaAfp = UtilesLiquidacion.DePorcentajeAdecimal(Request.PorcentajeTasaAFP),
                        FechaPrevision = Utiles.ToDD_MM_AAAA_Multi(Request.Fecha),
                        EstaActiva = true
                    };

                    db.AfpModel.Add(NuevosDatosAfp);
                    db.SaveChanges();
                }
            }
            catch(Exception)
            {
                Result = false;
            }

            return Result;
        }

        public static List<RentasTopasImpModel> ObtenerTopesActivos(remuneracionesContext db)
        {
            var ReturnValues = new List<RentasTopasImpModel>();
            ReturnValues = db.RentasTopasImpModel.Where(x => x.EstaActiva).ToList();

            return ReturnValues;
        }

        public static bool ActualizarTopes(RequestTopes Request, remuneracionesContext db)
        {
            bool Result = false;
            try{
                if(Request != null)
                {
                    if(Request.NombreTope == TipoTope.AFP.ToString())
                    {
                        var TopeToUpdate = db.RentasTopasImpModel.Where(x => x.Tope_id == TipoTope.AFP && x.EstaActiva).FirstOrDefault();
                        TopeToUpdate.EstaActiva = false;
                        db.RentasTopasImpModel.Update(TopeToUpdate);
                        var NuevoTope = new RentasTopasImpModel()
                        {
                            EstaActiva = true,
                            NombreTipoRenta = TopeToUpdate.NombreTipoRenta,
                            UFCLP = Convert.ToDecimal(Request.MontoTope),

                            Fecha = Utiles.ToDD_MM_AAAA_Multi(Request.FechaTope),     
                            Tope_id = TipoTope.AFP
                        };

                        db.RentasTopasImpModel.Add(NuevoTope);
                        db.SaveChanges();
                        Result = true;
                    }
                    if(Request.NombreTope == TipoTope.IPS.ToString())
                    {
                        var TopeToUpdate = db.RentasTopasImpModel.Where(x => x.Tope_id == TipoTope.IPS && x.EstaActiva).FirstOrDefault();
                        TopeToUpdate.EstaActiva = false;
                        db.RentasTopasImpModel.Update(TopeToUpdate);
                        var NuevoTope = new RentasTopasImpModel()
                        {
                            EstaActiva = true,
                            NombreTipoRenta = TopeToUpdate.NombreTipoRenta,
                            UFCLP = Convert.ToDecimal(Request.MontoTope),
                            Fecha = Utiles.ToDD_MM_AAAA_Multi(Request.FechaTope),
                            Tope_id = TipoTope.IPS
                        };

                        db.RentasTopasImpModel.Add(NuevoTope);
                        db.SaveChanges();
                        Result = true;
                    }
                    if(Request.NombreTope == TipoTope.SEGURO_CESANTIA.ToString())
                    {
                        var TopeToUpdate = db.RentasTopasImpModel.Where(x => x.Tope_id == TipoTope.SEGURO_CESANTIA && x.EstaActiva).FirstOrDefault();
                        TopeToUpdate.EstaActiva = false;
                        db.RentasTopasImpModel.Update(TopeToUpdate);
                        var NuevoTope = new RentasTopasImpModel()
                        {
                            EstaActiva = true,
                            NombreTipoRenta = TopeToUpdate.NombreTipoRenta,
                            UFCLP = Convert.ToDecimal(Request.MontoTope),
                            Fecha = Utiles.ToDD_MM_AAAA_Multi(Request.FechaTope),
                            Tope_id = TipoTope.SEGURO_CESANTIA
                        };

                        db.RentasTopasImpModel.Add(NuevoTope);
                        db.SaveChanges();
                        Result = true;
                    }
                }
                else
                {
                    throw new Exception();
                }

            }
            catch(Exception)
            {
                Result = false;
            }
            return Result;
        }

        public static bool ActualizarDatosSalud()
        {
            bool Result = false;
            return Result;
        }

        public static bool ActualizarAFC(remuneracionesContext db)
        {
            bool Result = false;
            List<AFCModel> AFCactiva = db.AFCModel.Where(x => x.EstaActivo == true).ToList();
            AFCactiva.Select(x => { x.EstaActivo = false; return x; });
            db.AFCModel.UpdateRange(AFCactiva);
            db.SaveChanges();
            return Result;
        }
    }
}