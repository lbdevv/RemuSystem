using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndRemuneraciones.Reponse.Cliente
{
    public class Respuesta
    {
        public string Mensaje { get; set; }
        public int Exito { get; set; }
        public object Data { get; set; }
    }
}
