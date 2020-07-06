using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndRemuneraciones.Models.Empleado.Prevision
{
    public class PrevisionEmpleado
    {
        public int Id { get; set; }
        public int Afp { get; set; }
        public int Isapre { get; set; } = 0;
        public int TramoAsignFamiliar { get; set; } = 0;
        public bool AdscribeSeguroCesantia { get; set; } = false;
        public bool EsPensionado { get; set; } = false;
        public string TrabajoPesaNomPuesto { get; set; } = "No";
        public int CodigoINE { get; set; } = 123;
    }
}
