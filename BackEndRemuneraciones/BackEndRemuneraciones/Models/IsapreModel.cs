using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndRemuneraciones.Models.Data;

namespace BackEndRemuneraciones.Models
{

    public class IsapreModel{
        public int Id { get;set; }
        public string Nombre { get;set; }

        public static List<IsapreModel> ObtenerIsapres(remuneracionesContext db){
            List<IsapreModel> LstIsapres = new List<IsapreModel>();
            LstIsapres = db.IsapreModel.ToList();
            
            return LstIsapres;
        }
    }
}