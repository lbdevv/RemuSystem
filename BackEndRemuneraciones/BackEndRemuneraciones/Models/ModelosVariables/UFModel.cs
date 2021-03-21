using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndRemuneraciones.Models.Data;

namespace BackEndRemuneraciones.Models.ModelosVariables
{
    public class UFModel{
        public int Id {get;set;}
        public string Nombre {get;set;}
        public DateTime Fecha {get;set;}
        public decimal Valor {get;set;}
        public bool EstaActiva {get;set;} = false;
        public static UFModel ObtenerUFActiva(){

            UFModel UFActiva = new UFModel();
            using(remuneracionesContext db = new remuneracionesContext())
            {
                UFActiva = db.UFModel.SingleOrDefault(x => x.Fecha.Month == DateTime.Now.Month &&
                                                           x.Fecha.Year == DateTime.Now.Year &&
                                                           x.EstaActiva == true);
            }
            return UFActiva;
        }


    }
}