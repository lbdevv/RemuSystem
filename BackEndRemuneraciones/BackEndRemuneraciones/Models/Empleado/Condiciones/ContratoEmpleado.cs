using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndRemuneraciones.Models.Empleado.Condiciones
{
    public class ContratoEmpleado
    {
        public int Id { get; set; }
        public string Empleador { get; set; } = "Test";
        public string Cargo { get; set; }
        public DateTime ContratoDesde { get; set; } = DateTime.Now;
        public DateTime ContratoHasta { get; set; } = DateTime.Now;
        public string Antiguedad { get; set; } = "Un Año";
        public string Jefe { get; set; } = "TestJefe";
        public int HorasDeJornada { get; set; } = 45;
    }
}
