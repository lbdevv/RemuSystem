using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndRemuneraciones.Models.Empresa;
using BackEndRemuneraciones.Models.Empleado.Ficha;

namespace BackEndRemuneraciones.Models.Liquidacion
{
    public class LiquidacionesGeneradas{
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public FichaEmpresa Empresa { get; set; }
        public int CargosId { get; set; }
        public CargosModel Cargos { get; set; }
        public int EmpleadoId { get; set; }
        public Tbempleados Empelado { get; set; }
        public DateTime FechaLiquidacion { get; set; }
        public decimal TotalImponibles { get; set; }
        public decimal TotalNoImponibles { get; set; }
        public decimal TotalDescuentosLegales { get; set; }
        public decimal TotalDescuentosPersonales { get; set; }
        public decimal TotalHaberes { get; set; }
        public decimal TotalDescuentos { get; set; } 
    }


}