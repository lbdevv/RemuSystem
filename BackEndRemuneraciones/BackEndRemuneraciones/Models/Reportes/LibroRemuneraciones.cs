using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndRemuneraciones.Models.Data;
using BackEndRemuneraciones.Models.Empleado.Ficha;
using BackEndRemuneraciones.Models.Empresa;

namespace BackEndRemuneraciones.Models.Reportes
{
    public class LibroRemuneraciones
    {
        public int Id { get; set; }
        public int EmpleadoId { get; set; }
        public Tbempleados Empleado { get; set; }
        public decimal GratLegal { get; set; }  //Revisar
        public decimal OtrosImp { get; set; }
        public decimal TotalImp { get; set; }
        public decimal TotalNoImp { get; set; }
        public decimal TotalHaberes { get; set; }
        public decimal Prevision { get; set; } //AFP
        public decimal Salud { get; set; }
        public decimal ImpUnico { get; set; }
        public decimal SegCesantia { get; set; }
        public decimal DescLegales { get; set; }
        public decimal DescVariables { get; set; }
        public decimal TotalDescuentos { get; set; }
        public decimal OtrDescuentosLegales { get; set; }
        public decimal AsigFamiliar { get; set; }
        public decimal OtrosNoImp { get; set; }
        public decimal TotalLiquido { get; set; } 
    }
}