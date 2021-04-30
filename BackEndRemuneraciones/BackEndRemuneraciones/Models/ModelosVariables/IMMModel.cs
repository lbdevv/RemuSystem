using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndRemuneraciones.Models.Data;

namespace BackEndRemuneraciones.Models.ModelosVariables
{
    public class IMMModel{
        public int Id {get;set;}
        public string Nombre {get;set;}
        public DateTime Fecha {get;set;}
        public decimal Valor {get;set;}
        public bool EstaActiva {get;set;} = false;


        public static IMMModel ObtenerObjetoIMM(remuneracionesContext db){
            IMMModel SueldoMinActivo = new IMMModel();
                SueldoMinActivo = db.IMMModel.SingleOrDefault(x => x.EstaActiva == true);
            
            return SueldoMinActivo;
        }
        public static decimal ObtenerSueldoMinimoActual(remuneracionesContext db){
            IMMModel SueldoMinActivo = new IMMModel();

                SueldoMinActivo = db.IMMModel.SingleOrDefault(x => x.EstaActiva == true);
            
            return SueldoMinActivo.Valor;
        }

    
    }
}