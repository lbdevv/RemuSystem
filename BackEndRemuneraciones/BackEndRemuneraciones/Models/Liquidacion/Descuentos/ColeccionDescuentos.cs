using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndRemuneraciones.Models.Empresa;

namespace BackEndRemuneraciones.Models.Liquidacion.Descuentos
{
    public class ColeccionDescuentos
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public FichaEmpresa Empresa { get; set; }
        public string Nombre { get; set; }
        public decimal ValorCalculo { get; set; }
    }
}
