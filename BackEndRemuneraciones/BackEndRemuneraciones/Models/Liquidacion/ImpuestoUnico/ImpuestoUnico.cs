using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndRemuneraciones.Models.Liquidacion.ImpuestoUnico
{
    public class ImpuestoUnico{
        public int  Id  { get; set; }
        public DateTime Fecha  { get; set; }
        public decimal RangoDesde { get; set; }
        public decimal RangoHasta { get; set; }
        public decimal FactorExento { get; set; }
        public decimal CandidadRebaja { get; set; }
        public string TasaImpuestoEfectivaMaxXtramoRenta { get; set; }
        public bool EstaActiva { get; set; }

    }
}