using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndRemuneraciones.Models.LoginApp
{
    public class RegisterModel
    {
        public int Id { get; set; }
        public string Rut { get; set; }
        public string Email { get; set; }
        public string Contrasena { get; set; }
        public DateTime FechaCreacion { get; set; }

    }
}
