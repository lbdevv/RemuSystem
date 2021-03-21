using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndRemuneraciones.Models.Empleado.Condiciones;

namespace BackEndRemuneraciones.Models.Liquidacion
{
    public class InfoEmpleadoEmpresa
    {
        public string EmpleadoId { get; set; }
        public string NombreEmpleado { get; set; }
        public string RutEmpleado { get; set; }
        public string FechaIngresoEmpleado { get; set; }
        public string CargoEmpleado { get; set; }
        public string RazonSocialEmpresa { get; set; }
        public string RutEmpresa { get; set; }
        public string DireccionEmpresa { get; set; }
    }
}
