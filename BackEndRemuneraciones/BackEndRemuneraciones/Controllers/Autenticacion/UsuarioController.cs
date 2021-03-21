using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BackEndRemuneraciones.Models.Autenticacion.Request;
using Microsoft.AspNetCore.Cors;
using BackEndRemuneraciones.Services;
using BackEndRemuneraciones.Reponse.Cliente;

namespace BackEndRemuneraciones.Controllers.Autenticacion
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioServicio _usuarioServicio;

        public UsuarioController(IUsuarioServicio usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }
        
        [HttpPost("Login")]
        public IActionResult Autentificar([FromBody]AutenticacionRequest Model)
        {
            Respuesta respuesta = new Respuesta();
            var usuarioResponse = _usuarioServicio.Autenticacion(Model);
            if (usuarioResponse == null)
            {
                respuesta.Exito = 0;
                respuesta.Mensaje = "Usuario o contraseña incorrecta";
                return BadRequest(respuesta);
            }
            respuesta.Mensaje = "Logeado con éxito";
            respuesta.Exito = 1;
            respuesta.Data = usuarioResponse;

            return Ok(respuesta);
        }
    }
}