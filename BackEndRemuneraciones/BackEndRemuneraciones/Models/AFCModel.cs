using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndRemuneraciones.Models.Data;

namespace BackEndRemuneraciones.Models
{
    public class AFCModel{
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Contrato { get; set; }
        public decimal FinanciamientoEmpleador { get; set; }
        public decimal FinanciamientoEmpleado { get; set; }
        public bool EstaActivo { get; set; }

    }
}