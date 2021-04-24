using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndRemuneraciones.Models
{
    public class RentasMinImponibles
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string NombreCaso { get; set; }
        public decimal Monto { get; set; }
        public TipoTope TipoTopeMinImp { get; set; }
        public bool EstaActiva { get; set; }
    }

    public enum TipoTipeMinImp
    {
        TRABAJADOR_DEP_E_INDEP = 1,
        MENOR_Y_MAYOR = 2,
        TRABAJADOR_CASA_PARTICULAR = 3,
        FINES_NO_REMUNERACION = 4
    }
}
