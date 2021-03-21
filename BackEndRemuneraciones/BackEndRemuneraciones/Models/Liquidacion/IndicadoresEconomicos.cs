using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndRemuneraciones.Models.ModelosVariables;

namespace BackEndRemuneraciones.Models.Liquidacion
{
    public class IndicadoresEconomicos{
        public UFModel UF { get; set; }
        public UTMModel UTM { get; set; }
        public IMMModel SueldoMinimo { get; set; }
    }
}