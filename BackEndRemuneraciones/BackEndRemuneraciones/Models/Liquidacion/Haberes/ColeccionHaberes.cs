using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndRemuneraciones.Models.Empresa;

namespace BackEndRemuneraciones.Models.Liquidacion.Haberes
{
    public class ColeccionHaberes
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public FichaEmpresa Empresa { get; set; }
        public CategoriaHaberes Categoria_id { get; set; }
        public string Nombre { get; set; }
        public decimal ValorCalculo { get; set; }

    }

    public enum CategoriaHaberes{
        NODETERMINADO = 0,
        IMPONIBLE = 1,
        NOIMPONIBLE = 2,
        VARIABLE = 3
    }
}
