using BackEndRemuneraciones.Models.Empresa;
using BackEndRemuneraciones.Models.Empleado.Ficha;


namespace BackEndRemuneraciones.Models.Liquidacion
{
    public class HaberesYDescuentosEmpleado{

        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public FichaEmpresa Empresa  { get; set; }
        public int EmpleadoId { get; set; }
        public Tbempleados Empleado { get; set; }
        public int HaberOdescuentoId { get; set; }
        public TipoHaberODescuento TipoHoD { get; set; }
        //Ver la posibilidad de incluir la relacion de la tabla descuentos
        public decimal Monto { get; set; }

        //Sobre todo revisar si realmente sirve tener las tablas haberes y descuentos (las colecciones) separadas
    }

    public enum TipoHaberODescuento{
        HABER = 1,
        DESCUENTO = 2
    }

    public enum TipoProcesoHyD
    {
        VALOR_ESTATICO = 1,
        VALOR_VARIABLE = 2
    }



}