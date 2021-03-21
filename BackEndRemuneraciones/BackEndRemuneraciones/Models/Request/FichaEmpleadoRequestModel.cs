using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndRemuneraciones.Models.Request
{
    public class FichaEmpleadoRequestModel
    {   
        public string EstaVigente {get;set;}
        public string Rut { get; set; }
        public string RazonSocial {get;set;}

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sexo { get; set; }
        public string FechaNacimiento { get; set; }
        public string EstadoCivil { get; set; }
        public string Nacionalidad {get;set;}
        public string EmailPersonal {get;set;}
        public string EmailCorporativo {get;set;}
        public string Telefono {get;set;}
        public string Calle {get;set;}
        public string NumCasa {get;set;}
        public string Departamento{get;set;}
        public string RegionId {get;set;}
        public string ComunaId {get;set;}

        //Condiciones
        public string Cargo {get;set;}
        public string CentroCosto {get;set;}
        public string TipoContrato {get;set;}
        public string ContratoDesde {get;set;}
        public string ContratoHasta {get;set;}
        public string SueldoBase {get;set;}
        public string AsignMovilizacion {get;set;}
        public string AsignColacion {get;set;}
        public string BancoId {get;set;}
        public string TipoCuentaId {get;set;}
        public string NumCuenta {get;set;}

        //Prevision
        public string AFPId {get;set;}
        public string IsapreId {get;set;}
        public string UnidadId {get;set;}
        public string TramoId {get;set;}
        public string IsapreTipoMonto {get;set;}
        public string IsapreMonto {get;set;}
        public string ApvTipoMonto {get;set;}
        public string ApvMonto {get;set;}
        public string IApv {get;set;}
    }



}
