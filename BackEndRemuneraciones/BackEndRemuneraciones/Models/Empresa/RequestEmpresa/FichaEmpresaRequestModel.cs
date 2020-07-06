using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndRemuneraciones.Models.Empresa.RequestEmpresa
{
    public class FichaEmpresaRequestModel
    {
        public string Rut { get; set; }
        public bool Principal { get; set; }
        public string RazonSocial { get; set; }
        public string TipoEmpresa { get; set; }
        public string Giro { get; set; }
        public string Direccion { get; set; }
        public string RepresentanteLegal { get; set; }
        public string RutRepresentanteLegal { get; set; }
        public string CajaCompensacion { get; set; }
        public string MutualPorcentajeDescuento { get; set; }
        public string Comuna { get; set; }
        public string Telefono { get; set; }
        public string BancoPagoNomina { get; set; }
        public bool Vigente { get; set; }
        public string FormaPagoGratif { get; set; }
        public string FormPagoMoviColacion { get; set; }
    }
}
