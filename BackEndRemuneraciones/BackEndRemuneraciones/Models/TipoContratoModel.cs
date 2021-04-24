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

        public static List<TipoContratoModel> ObtenerListaContratos(remuneracionesContext db){
            List<TipoContratoModel> LstContratos = new List<TipoContratoModel>();
            
            LstContratos = db.TipoContratoModel.ToList();
             
             return LstContratos;
        }

        public static bool VerificarEsIndefinido(int id, remuneracionesContext db){
            bool Result = false;
            TipoContratoModel ContratoConsultado = new TipoContratoModel();

            ContratoConsultado = db.TipoContratoModel.SingleOrDefault(x => x.Id == id);
            if(ContratoConsultado != null && ContratoConsultado.Nombre == "Contrato Plazo Fijo")
                Result = true;
            else
                Result = false;
            
            
            return Result;
        }
    }
}