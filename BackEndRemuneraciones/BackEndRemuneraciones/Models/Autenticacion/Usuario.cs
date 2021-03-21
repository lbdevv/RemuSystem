using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndRemuneraciones.Models.Empresa;

namespace BackEndRemuneraciones.Models.Autenticacion
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Contrasena { get; set; }
        public string Nombre { get; set; }
        public PerfilUsuario Perfil { get; set; }
        public virtual List<FichaEmpresa> EmpresasUsuario { get; set; }
    }

    public enum PerfilUsuario{
        SUPER_ADMIN = 1,
        EMPRESA = 2,
        EMPLEADO = 3,
        VISITA = 4
    }
}
