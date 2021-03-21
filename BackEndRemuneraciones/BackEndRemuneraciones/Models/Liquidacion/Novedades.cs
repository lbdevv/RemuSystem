using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndRemuneraciones.Models.Empresa;
using BackEndRemuneraciones.Models.Empleado.Ficha;

namespace BackEndRemuneraciones.Models.Liquidacion
{
    public class Novedades{ 
        public int Id { get; set; }
        public int EmpleadoId { get; set; }
        public Tbempleados Empleado { get; set; }
        public string NombreNovedad { get; set; }
        public decimal MontoNovedad { get; set; }
    }
}