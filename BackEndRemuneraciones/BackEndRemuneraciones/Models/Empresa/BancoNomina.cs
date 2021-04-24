using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndRemuneraciones.Models.Data;

namespace BackEndRemuneraciones.Models.Empresa
{
    public class BancoNomina
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public static List<BancoNomina> ObtenerTodosLosBancos(remuneracionesContext db)
        {
            List<BancoNomina> lstBanco = new List<BancoNomina>();


            lstBanco = db.BancoNomina.ToList();
            

            return lstBanco;
        }
    }

    public class CajaCompensacion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }


        public static List<CajaCompensacion> ObtenerLstCajaCompensacion(remuneracionesContext db)
        {
            List<CajaCompensacion> lstCajas = new List<CajaCompensacion>();

            lstCajas = db.CajaCompensacion.ToList();
            
            return lstCajas; 
        }
    }
}
