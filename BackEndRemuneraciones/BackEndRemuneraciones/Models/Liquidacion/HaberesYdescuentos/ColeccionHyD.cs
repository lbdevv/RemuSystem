using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndRemuneraciones.Models.Empleado.Ficha;
using BackEndRemuneraciones.Models.Liquidacion.Haberes;
using BackEndRemuneraciones.Models.Liquidacion.Descuentos;
using BackEndRemuneraciones.Models.Liquidacion;

namespace BackEndRemuneraciones.Models.Liquidacion.HaberesYdescuentos
{
    public class HaberesYDescuentos{
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Monto { get; set; }
        public string Tipo { get; set; }
        public string CategoriaHaber { get; set; }
    }
}