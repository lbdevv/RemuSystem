using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using BackEndRemuneraciones.Models.ModelosVariables;

namespace BackEndRemuneraciones.Controllers.DatosGlobales
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class GeneralesController : ControllerBase
    {

        [HttpGet("ObtenerDatosGlobales")]
        public IActionResult GetDatosGlobales()
        {
                var DatosUF = UFModel.ObtenerUFActiva();
                var DatosUTM = UTMModel.ObtenerUTMActiva();
                var DatosIMM = IMMModel.ObtenerObjetoIMM();
                var DatosGlobales = new DatosGlobalesModel(DatosUF,DatosUTM,DatosIMM);
                return Ok(DatosGlobales);
        }

    }
}