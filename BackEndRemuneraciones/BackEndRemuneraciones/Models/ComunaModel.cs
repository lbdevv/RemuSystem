using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndRemuneraciones.Models.Data;

namespace BackEndRemuneraciones.Models
{
    public class ComunaModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int RegionId { get; set; }
        public virtual RegionModel Region { get; set; }


        public static List<ComunaModel> ObtenerComunas(remuneracionesContext db)
        {
            List<ComunaModel> Comunas = new List<ComunaModel>();
            Comunas = db.ComunaModels.ToList();
            
            return Comunas;
        }

    }
}