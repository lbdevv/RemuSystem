using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndRemuneraciones.Models.Data;

namespace BackEndRemuneraciones.Models.ModelosVariables
{
    public class DatosGlobalesModel{
        public UFModel UF {get;set;}
        public UTMModel UTM {get;set;}
        public IMMModel IMM {get;set;}  

        public DatosGlobalesModel(UFModel UF, UTMModel UTM, IMMModel IMM ){
            this.UF = UF;
            this.UTM = UTM;
            this.IMM = IMM;
        }
    }
}