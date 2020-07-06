using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndRemuneraciones.Models.Empleado.Condiciones
{
    public class BeneficiosEmpleado
    {
        public int Id { get; set; }
        public int DiasAddVacaciones { get; set; }
        public int CantidadDiasAdmin { get; set; }
        public int MesesImponiblesReconocidos { get; set; }
        public int MesesImponiblesRecDesde { get; set; }
        public bool PagaLosPrimeros3DiasDeLicencia { get; set; }
        public bool MantieneLaRentaLiquidaLicencia { get; set; }
        public string BeneficiosAdicionales { get; set; }
    }
}
