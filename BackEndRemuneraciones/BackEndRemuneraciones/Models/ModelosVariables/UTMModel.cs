using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndRemuneraciones.Models.Data;

namespace BackEndRemuneraciones.Models.ModelosVariables
{
    public class UTMModel{
        public int Id {get;set;}
        public string Nombre {get;set;}
        public DateTime Fecha {get;set;}
        public decimal Valor {get;set;}
        public bool EstaActiva {get;set;} = false;

        public static UTMModel ObtenerUTMActiva(){

            UTMModel UTMActiva = new UTMModel();
            using(remuneracionesContext db = new remuneracionesContext())
            {
                UTMActiva = db.UTMModel.SingleOrDefault(x => x.Fecha.Month == DateTime.Now.Month && x.Fecha.Year == DateTime.Now.Year && x.EstaActiva == true);
            }

            return UTMActiva;
        }
    }
}