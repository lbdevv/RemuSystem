using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using BackEndRemuneraciones.Models.Empleado.Ficha;
using BackEndRemuneraciones.Models.Empresa;

namespace BackEndRemuneraciones.Models.Empleado.Condiciones
{
    public class ContratoEmpleado
    {
        public int Id { get; set; }
        public string Empleador { get; set; } = "Test";
        public virtual CargosModel Cargo { get; set; }
        public int CargoId { get; set; }
        TipoContrato TipoContrato { get; set; } = TipoContrato.CONTRATO_INDEFINIDO;
        public DateTime ContratoDesde { get; set; } = DateTime.Now;
        public DateTime ContratoHasta { get; set; } = DateTime.Now;
        public string Antiguedad { get; set; } = "Un Año";
        public string Jefe { get; set; } = "TestJefe";
        public int HorasDeJornada { get; set; } = 45;
    }

    public enum TipoContrato
    {
        [Description("Contrato Indefinido")]
        CONTRATO_INDEFINIDO = 1,
        [Description("Contrato Plazo Fijo")]
        CONTRATO_PLAZO_FIJO = 2,
        [Description("Contrato Por Obra")]
        CONTRATO_POR_OBRA = 3,
        [Description("Contrato Extranjero")]
        CONTRATO_EXTRANJERO = 4
    }
}
