using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndRemuneraciones.Models.Data;

namespace BackEndRemuneraciones.Models
{
    public class RegionModel {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public static List<RegionModel> ObtenerRegiones(){
            List<RegionModel> LstRegiones = new List<RegionModel>();
             using (remuneracionesContext db = new remuneracionesContext()){
                 LstRegiones = db.RegionModels.ToList();
             }
             return LstRegiones;
        }

        public static List<ComunaModel> ObtenerRegionYComuna(int id){

            RegionModel Region = new RegionModel();
            List<ComunaModel> Comunas = new List<ComunaModel>();
             using (remuneracionesContext db = new remuneracionesContext()){
                 Region = db.RegionModels.SingleOrDefault(x => x.Id == id);
                 if(Region != null){
                     Comunas = db.ComunaModels.Where(x => x.RegionId == Region.Id).Select(x => new ComunaModel{ Id = x.Id, Nombre = x.Nombre}).ToList();
                 }
             }
             return Comunas;
        }


    }
}