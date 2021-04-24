using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndRemuneraciones.Models.Empleado.Prevision
{
    public class PrevisionEmpleado
    {
        public int Id { get; set; }
        public int AFPId { get; set; }
        public virtual AfpModel AFP { get; set; }
        public virtual IsapreModel? Isapre { get; set; }
        public int IsapreId { get; set; } = 0;
        public decimal MontoPactadoIsapre { get; set; }
        public TipoMontoPactado Tipo { get; set; } = TipoMontoPactado.PESO;
        public int TramoAsignFamiliar { get; set; } = 0;
        public bool AdscribeSeguroCesantia { get; set; } = false;
        public bool EsPensionado { get; set; } = false;
        public string TrabajoPesaNomPuesto { get; set; } = "No";
        public int CodigoINE { get; set; } = 123;
    }

    public enum TipoMontoPactado
    {
        PESO = 1, //Se usa el monto directo
        UF = 2, //Para este calcular monto
        PORCENTAJE = 3 //Para este calcular monto

    }
}
