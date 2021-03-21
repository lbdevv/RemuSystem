using System;

namespace BackEndRemuneraciones.Services.Request
{
    public class RequestCreateHaber{
        public string TipoHaber { get; set; }
        public string NombreHaber { get; set; }
        public string MontoHaber { get; set; }
    }
    public class RequestCreateDescuento{
        public string NombreDescuento { get; set; }
        public string MontoDescuento { get; set; }
    }
}