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

        public static List<BancoNomina> ObtenerTodosLosBancos()
        {
            List<BancoNomina> lstBanco = new List<BancoNomina>();

            using (remuneracionesContext db = new remuneracionesContext())
            {
                lstBanco = db.BancoNomina.ToList();
            }

            return lstBanco;
        }
    }

    public class CajaCompensacion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }


        public static List<CajaCompensacion> ObtenerLstCajaCompensacion()
        {
            List<CajaCompensacion> lstCajas = new List<CajaCompensacion>();
            using(remuneracionesContext db = new remuneracionesContext())
            {
                lstCajas = db.CajaCompensacion.ToList();
            }
            return lstCajas; 
        }
    }
}
