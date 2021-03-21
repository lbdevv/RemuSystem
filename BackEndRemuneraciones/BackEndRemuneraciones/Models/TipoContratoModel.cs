using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndRemuneraciones.Models.Data;

namespace BackEndRemuneraciones.Models
{
    public class TipoContratoModel{
        public int Id {get;set;}
        public string Nombre {get;set;}

        public static List<TipoContratoModel> ObtenerListaContratos(){
            List<TipoContratoModel> LstContratos = new List<TipoContratoModel>();
             using (remuneracionesContext db = new remuneracionesContext()){
                 LstContratos = db.TipoContratoModel.ToList();
             }
             return LstContratos;
        }

        public static bool VerificarEsIndefinido(int id){
            bool Result = false;
            TipoContratoModel ContratoConsultado = new TipoContratoModel();

            using(remuneracionesContext db = new remuneracionesContext()){    
                ContratoConsultado = db.TipoContratoModel.SingleOrDefault(x => x.Id == id);
                if(ContratoConsultado != null && ContratoConsultado.Nombre == "Contrato Plazo Fijo"){
                    Result = true;
                }else{
                    Result = false;
                }
            }
            return Result;
        }
    }
}