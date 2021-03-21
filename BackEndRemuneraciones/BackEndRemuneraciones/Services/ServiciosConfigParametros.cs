using System;
using System.Collections.Generic;
using System.Linq;
using BackEndRemuneraciones.Helpers;
using BackEndRemuneraciones.Models.Data;
using BackEndRemuneraciones.Models;
using BackEndRemuneraciones.Models.ModelosVariables;
using BackEndRemuneraciones.Services.RequestConfigServices;

namespace BackEndRemuneraciones.Services
{
    public class ServiciosConfigParametros
    {
        public static bool ActualizarIndicadoresEconomicos(remuneracionesContext db, RequestIE Request)
        {
            bool Result = false;
            try
            {
                if (!string.IsNullOrWhiteSpace(Request.MontoIMM) &&
                    !string.IsNullOrWhiteSpace(Request.MontoUTM) &&
                    !string.IsNullOrWhiteSpace(Request.MontoUF))
                {
                    IMMModel IMMactiva = db.IMMModel.SingleOrDefault(x => x.EstaActiva == true);
                    IMMactiva.EstaActiva = false;

                    IMMModel NuevaIMM = new IMMModel()
                    {
                        Nombre = IMMactiva.Nombre,
                        Fecha = Utiles.ToDD_MM_AAAA_Multi(Request.Fecha),
                        Valor = Convert.ToInt32(Request.MontoIMM),
                        EstaActiva = true
                    };

                    db.IMMModel.Add(NuevaIMM);


                    UTMModel UTMactiva = db.UTMModel.SingleOrDefault(x => x.EstaActiva == true);
                    UTMactiva.EstaActiva = false;

                    UTMModel NuevaUTM = new UTMModel()
                    {
                        Nombre = UTMactiva.Nombre,
                        Fecha = Utiles.ToDD_MM_AAAA_Multi(Request.Fecha),
                        Valor = Convert.ToInt32(Request.MontoUTM),
                        EstaActiva = true
                    };

                    db.UTMModel.Add(NuevaUTM);


                    UFModel UFactiva = db.UFModel.SingleOrDefault(x => x.EstaActiva == true);
                    UFactiva.EstaActiva = false;

                    UFModel NuevaUF = new UFModel()
                    {
                        Nombre = UFactiva.Nombre,
                        Fecha = Utiles.ToDD_MM_AAAA_Multi(Request.Fecha),
                        Valor = Convert.ToInt32(Request.MontoUF),
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

        public static bool ActualizarAFP(remuneracionesContext db, RequestAFP Request)
        {
            bool Result = false;        
            try{
                if(Request != null)
                {
                    //revisar esto para cuando se cambien todos los valores
                    List<AfpModel> AFPactiva = db.AfpModel.Where(x => x.EstaActiva == true).ToList();
                    AFPactiva.Select(x => { x.EstaActiva = false; return x; });

                    AfpModel NuevosDatosAfp = new AfpModel()
                    {
                        NombreAfp = Request.NombreAFP,
                        DependientesTasaAfp = Convert.ToDecimal(Request.PorcentajeTasaAFP),
                        IndependientesTasaAfp = Convert.ToDecimal(Request.PorcentajeTasaAFP),
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

        public static bool ActualizarTopes(remuneracionesContext db, RequestTopes Request)
        {
            bool Result = false;
            try{
                if(Request != null)
                {
                    List<RentasTopasImpModel> TopesActivos = db.RentasTopasImpModel.Where(x => x.EstaActiva == true).ToList();
                    TopesActivos.Select(x => { x.EstaActiva = false; return x; } ).ToList();

                    RentasTopasImpModel NuevosTopes = new RentasTopasImpModel()
                    {
                        NombreTipoRenta = Request.NombreTope,
                    };
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

        public static bool ActualizarDatosSalud(remuneracionesContext db)
        {
            bool Result = false;
            return Result;
        }

        public static bool ActualizarAFC(remuneracionesContext db)
        {
            bool Result = false;
            List<AFCModel> AFCactiva = db.AFCModel.Where(x => x.EstaActivo == true).ToList();
            AFCactiva.Select(x => { x.EstaActivo = false; return x; });
            return Result;
        }
    }
}