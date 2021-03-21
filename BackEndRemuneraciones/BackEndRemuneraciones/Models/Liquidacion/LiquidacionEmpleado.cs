using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndRemuneraciones.Models.Liquidacion
{
    public class LiquidacionEmpleado
    {
        public InfoEmpleadoEmpresa InfoEmpleado { get; set; }
        public string FechaLiquidacion { get; set; }
        public IndicadoresEconomicos indicadoresEco { get; set; }
        public List<HaberImponible> lstHaberImponible { get; set; }
        public List<HaberNoImponible> lstHaberNoImponible { get; set; }
        public string MesLiquidacion { get; set; }
        public decimal TotalHaberes {get;set;}
        public decimal TotalDescuentos { get; set; }
        public decimal TotalHaberesImp { get; set; }
        public decimal TotalHaberesNoImp { get; set; }
        public decimal TotalLiquido { get; set; }
        public int HorasTrabajadas  { get; set; }
        public int DiasTrabajados { get; set; }
        public List<DescuentosLiquidacion> lstDescuentos { get; set; }
     
    }
}
