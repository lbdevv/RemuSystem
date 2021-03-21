using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BackEndRemuneraciones.Models.ModelosVariables;
using BackEndRemuneraciones.Models.Liquidacion.ImpuestoUnico;
using  BackEndRemuneraciones.Models.Empleado.Prevision;
using BackEndRemuneraciones.Models.Data;

namespace BackEndRemuneraciones.Helpers
{
    public class UtilesLiquidacion{
        public static decimal DePorcentajeAdecimal(decimal Valor)
        {
            decimal ValorARetornar = (Valor / 100);
            return ValorARetornar;
        }
        public static decimal DePorcentajeAdecimal(double Valor)
        {
            decimal ValorARetornar = ((decimal)Valor / 100);
            return ValorARetornar;
        }
        public static decimal DeDecimalAPorcentaje(decimal Valor){
            decimal ValorARetornar = (Valor * 100);
            return ValorARetornar;
        }
    }

    public class CalculosLiquidacion
    {
        public static decimal TopeGratificacionLegalAnual()
        {
            decimal SueldoMinimoActual = IMMModel.ObtenerSueldoMinimoActual();
            decimal ValorTopeIMM = (decimal)(4.75 * 100);
            decimal TopeAnual = Math.Round((ValorTopeIMM * SueldoMinimoActual) / 100);
            return TopeAnual;
        }

        public static decimal TopeGratificacionLegalMensual()
        {
            decimal SueldoMinimoActual = IMMModel.ObtenerSueldoMinimoActual();
            decimal ValorTopeIMM = (decimal)(4.75 * 100);
            decimal TopeMensual = Math.Round(((ValorTopeIMM * SueldoMinimoActual) / 100) / 12);
            return TopeMensual;
        }
        public static decimal CalcularGratificacionLegal(decimal SueldoBase, decimal HorasExtras, decimal MontoBono)
        {
            decimal SueldoMinimoActual = IMMModel.ObtenerSueldoMinimoActual();
            decimal TopeGratMensual = TopeGratificacionLegalMensual();
            decimal Total = SueldoBase + HorasExtras + MontoBono;
            decimal Gratificacion = Math.Round((25 * Total) / 100);
            if (TopeGratMensual >= Gratificacion)
                return Gratificacion;
            else
                return Math.Round(TopeGratMensual);
        }
        public static decimal CalculoAFPIndefinido(decimal TasaDependientes, decimal SueldoBase, decimal AFPTope)
        {
            decimal CalculoDescuento = SueldoBase * TasaDependientes;
            if(CalculoDescuento <= AFPTope)
                return Math.Round(CalculoDescuento);
            else
                return Math.Round(AFPTope);
        }

        public static string VistaPorcentajeLiquidacion(decimal TasaDependientes, decimal CalculoDescuento, string NombreAfp)
        {
            decimal VistaPorcentaje = Math.Round(TasaDependientes * 100, 2);
            string NombreDescuento = "AFP:" + " " + NombreAfp + "{ " + VistaPorcentaje.ToString() + "%" + " }";
            return NombreDescuento;
        }

        public static decimal CalcularImponibleTributable(decimal TotalImponible, decimal TotalDescuentos)
        {
            if (TotalImponible <= 0 && TotalDescuentos <= 0) return 0;
            decimal ImponibleTributable = TotalImponible - TotalDescuentos;
            return Math.Round(ImponibleTributable);
        }

        public static decimal ProcesarMontoPactadoIsapre(PrevisionEmpleado PrevisionEmp, decimal MontoUFActual)
        {
            decimal Monto = 0;

            if(PrevisionEmp.Tipo == TipoMontoPactado.PESO)
            {
                Monto =  PrevisionEmp.MontoPactadoIsapre;
            }
            else if(PrevisionEmp.Tipo  == TipoMontoPactado.UF)
            {
                Monto = PrevisionEmp.MontoPactadoIsapre *  MontoUFActual;
            }
            else if(PrevisionEmp.Tipo ==  TipoMontoPactado.PORCENTAJE)
            {
                //Por avergiguar
            }

            return  Monto;
        }

        public static decimal MontoIsapreAdicional(decimal MontoFonasa, decimal MontoIsapre)
        {
            decimal Monto =  0;
            if(MontoIsapre > MontoFonasa)
                Monto = Math.Abs(MontoIsapre - MontoFonasa);

            return Monto;
        }

        public static decimal CalculoImpuestoUnico(List<ImpuestoUnico> InfoImpuestoUnicoActual, decimal TotalImponibleTributable)
        {
            decimal ResultadoImpuestoUnico = 0;

            ImpuestoUnico TramoAlQuePertence = InfoImpuestoUnicoActual.SingleOrDefault(x => x.RangoDesde <= TotalImponibleTributable &&
                                                                                            x.RangoHasta >= TotalImponibleTributable);

            if (TramoAlQuePertence != null) ResultadoImpuestoUnico = (TotalImponibleTributable * TramoAlQuePertence.FactorExento) - TramoAlQuePertence.CandidadRebaja;
        
            return Math.Round(ResultadoImpuestoUnico);
        }
        public static bool EstaAfectaAimpuestos(List<ImpuestoUnico> InfoImpuestoUnicoActual, decimal TotalImponibleTributable)
        {
            bool EstaAfectaAImpuestos = false;
            if (InfoImpuestoUnicoActual != null)
            {
                decimal RangoMinimo = InfoImpuestoUnicoActual.Min(x => x.RangoDesde);
                if (TotalImponibleTributable > RangoMinimo)
                    EstaAfectaAImpuestos = true;
            }
            return EstaAfectaAImpuestos;
        }
        public static decimal CalculoHoraOrdinaria(decimal SueldoBase, int DiasDelMes, int DiasDelasSemanasDelMes, int HorasDeTrabajo)
        {
            decimal Resultado = Math.Round(((SueldoBase / DiasDelMes) * DiasDelasSemanasDelMes) / HorasDeTrabajo);
            return Resultado;
        }
        public static decimal CalculoHorasExtras(decimal ValorHoraDeTrabajo)
        {
            decimal PorcentajeAgregadoHorasExtras = 50;
            decimal ValorCalculo = UtilesLiquidacion.DePorcentajeAdecimal(PorcentajeAgregadoHorasExtras);
            decimal Resultado = Math.Round((ValorHoraDeTrabajo * ValorCalculo));
            return Resultado;
        }

        public static decimal CalculoFonasa(decimal TotalHaberesImponibles, decimal PorcentajeFonasa = 7)
        {
            decimal PorcentajeFonasaDecimal = UtilesLiquidacion.DePorcentajeAdecimal(PorcentajeFonasa);
            decimal ResultadoCalculo = Math.Round((TotalHaberesImponibles * PorcentajeFonasaDecimal));
            return ResultadoCalculo;
        }
        public static decimal CalculoSeguroDeCesantia(decimal TotalHaberesImponibles, decimal ValorPorcentajeSC, decimal TopeSC){
            decimal ResultadoCalculoTrabajador = (TotalHaberesImponibles * ValorPorcentajeSC);
            if(ResultadoCalculoTrabajador <= TopeSC)
                return Math.Round(ResultadoCalculoTrabajador);
            else
                return Math.Round(TopeSC);
        }
        
        public static Tuple<decimal, decimal> CalculoSeguroDeCensantiaTuple(decimal MontoCalculoSC, decimal TotalHaberesImponibles)
        {
            double ValorPorcentajeSC = 0.60; //Sacar este calculo de una consulta a la db
            double ValorPorcentajeSCempresa = 2.4; // Sacar este de una consulta a la db
            decimal ValorCalculoCesantia = UtilesLiquidacion.DePorcentajeAdecimal(ValorPorcentajeSC);
            decimal ValorcalculoCesantiaEmpresa = UtilesLiquidacion.DePorcentajeAdecimal(ValorPorcentajeSCempresa);
            decimal ResultadoCalculoTrabajador = (TotalHaberesImponibles * ValorCalculoCesantia);
            decimal ResultadoCalculoEmpleador = (TotalHaberesImponibles * ValorcalculoCesantiaEmpresa);

            return Tuple.Create(ResultadoCalculoEmpleador, ResultadoCalculoTrabajador);
        }

    }
}