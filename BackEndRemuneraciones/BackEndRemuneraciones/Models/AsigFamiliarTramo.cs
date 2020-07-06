using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndRemuneraciones.Models
{
    public class AsigFamiliarTramo
    {
        public int Id { get; set; }
        public char Tramo { get; set; }
        public decimal Monto { get; set; }
        public decimal TopeCompararConRenta { get; set; }
    }
}
