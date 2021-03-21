using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndRemuneraciones.Models.Empleado.Ficha;

namespace BackEndRemuneraciones.Models.Liquidacion.Haberes
{
    public class ColeccionHaberesEmpleado
    {
        public int Id { get; set; }
        public int TbEmpelado_id { get; set; }
        public virtual Tbempleados Empleado { get; set; }
        public int ColeccionHaberes_id { get; set; }
        public virtual ColeccionHaberes Haberes { get; set; }

    }
}
