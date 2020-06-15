using System;
using System.Collections.Generic;

namespace BackEndRemuneraciones.Models
{
    public partial class Tbempleados
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Rut { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Nacionalidad { get; set; }
        public int Sexo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool EstaDisponible { get; set; }
        public int Ciudad { get; set; }
        public int Comuna { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string EstadoCivil { get; set; }
    }
}
