using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndRemuneraciones.Models
{
    public class RentasTopasImpModel
    {
        public int Id { get; set; }
        public string NombreTipoRenta { get; set; }
        public decimal UFCLP { get; set; }
        public TipoTope Tope_id { get; set; }
        public bool EstaActiva { get; set; }
        public DateTime Fecha { get; set; } 

    }

    public enum TipoTope{
        AFP = 1,
        IPS = 2,
        SEGURO_CESANTIA = 3
    }
}
