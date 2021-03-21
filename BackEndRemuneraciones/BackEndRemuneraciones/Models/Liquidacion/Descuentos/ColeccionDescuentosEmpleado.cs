using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndRemuneraciones.Models.Empleado.Ficha;

namespace BackEndRemuneraciones.Models.Liquidacion.Descuentos
{
    public class ColeccionDescuentosEmpleado
    {
        public int Id { get; set; }
        public int TbEmpleado_id { get; set; }
        public virtual Tbempleados Empleado { get; set; }
        public int ColeccionDescuentos_id { get; set; }
        public virtual ColeccionDescuentos Descuentos { get; set; }

    }
}
