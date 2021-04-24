using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndRemuneraciones.Models.Data;

namespace BackEndRemuneraciones.Models
{
    public class AsigFamiliarTramo
    {
        public int Id { get; set; }
        public DateTime FechaPrevision { get; set; }
        public bool EstaActiva { get; set; } 
        public char Tramo { get; set; }
        public decimal Monto { get; set; }
        public decimal TopeCompararConRenta { get; set; }

            public static object ObtenerTramos(remuneracionesContext db){
                object lstTramosFamiliares = new object();
                lstTramosFamiliares = db.AsigFamiliarTramo.Select(x => new { id = x.Id, tramo = x.Tramo }).ToList();
                
                return lstTramosFamiliares;
            }
    }


}
