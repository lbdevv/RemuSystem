using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndRemuneraciones.Models.Empleado.Condiciones
{
    public class SueldoEmpleado
    {
        public int Id { get; set; }
        public string TipoPago { get; set; } = "No se";
        public decimal SueldoBase { get; set; }
        public decimal MontoGratificacion { get; set; } = 0;
        public decimal AsignMovilizacion { get; set; }
        public decimal AsignColacion { get; set; }
        public decimal AnticipoPactado { get; set; } = 0;
        public string FormaPago { get; set; } = "Transferencia";
        public int CuentaCorriente { get; set; } = 123;

    }
}
