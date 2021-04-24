using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndRemuneraciones.Models.Data;

namespace BackEndRemuneraciones.Models
{
    public class AfpModel
    {
        public int Id { get; set; }
        public DateTime FechaPrevision { get; set; }
        public bool EstaActiva { get; set; } 
        public string NombreAfp { get; set; }
        public decimal DependientesTasaAfp { get; set; }
        public decimal DependientesSis { get; set; }
        public decimal IndependientesTasaAfp { get; set; }

        public static List<AfpParaSelect> ObtenerAfps(remuneracionesContext db){

            List<AfpParaSelect> LstAfp = new List<AfpParaSelect>();
            LstAfp = db.AfpModel.Select(x => new AfpParaSelect { Id = x.Id, Nombre = x.NombreAfp }).ToList();

            return LstAfp;
        }

        public static List<string> NombresAfp(remuneracionesContext db)
        {
            List<string> NombresAfp = db.AfpModel.Select(x => x.NombreAfp).ToList();
    
            return NombresAfp;
        }

    }

    public class AfpParaSelect{
        public int Id { get; set;}
        public string Nombre {get;set;}
    }
}
