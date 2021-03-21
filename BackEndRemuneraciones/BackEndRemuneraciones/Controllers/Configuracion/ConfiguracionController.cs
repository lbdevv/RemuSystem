using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using BackEndRemuneraciones.Models.ModelosVariables;

namespace BackEndRemuneraciones.Controllers.Configuracion
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class ConfiguracionController : ControllerBase
    {

        [HttpPost("InsertarNuevosIE")]
        public IActionResult InsertNuevosIE()
        {
            return Ok();
        }

        [HttpPost("InsertarNuevosTopes")]
        public IActionResult InsertNuevosTopes()
        {
            return Ok();
        }

        [HttpPost("InsertarNuevasAPV")]
        public IActionResult InsertNuevasAPV()
        {
            return Ok();
        }
        [HttpPost("InsertarNuevasAFP")]
        public IActionResult InsertNuevasAFP()
        {
            return Ok();
        }
        [HttpPost("InsertarNuevosDatosSalud")]
        public IActionResult InsertNuevosDatosSalud()
        {
            return Ok();
        }
    }
}