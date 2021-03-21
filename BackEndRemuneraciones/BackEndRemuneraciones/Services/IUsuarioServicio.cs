using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndRemuneraciones.Models.Autenticacion.Request;
using BackEndRemuneraciones.Reponse;
using BackEndRemuneraciones.Reponse.Cliente;


namespace BackEndRemuneraciones.Services
{
    public interface IUsuarioServicio
    {   
        UsuarioResponse Autenticacion(AutenticacionRequest Model);
        
    }
}
