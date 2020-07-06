using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndRemuneraciones.Models
{
    public class AfpModel
    {
        public int Id { get; set; }
        public string NombreAfp { get; set; }
        public decimal DependientesTasaAfp { get; set; }
        public decimal DependientesSis { get; set; }
        public decimal IndependientesTasaAfp { get; set; }

    }
}
