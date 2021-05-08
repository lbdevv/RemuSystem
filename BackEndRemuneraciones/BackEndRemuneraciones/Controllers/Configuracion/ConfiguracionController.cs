using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using BackEndRemuneraciones.Models.ModelosVariables;
using BackEndRemuneraciones.Models;
using BackEndRemuneraciones.Services;
using BackEndRemuneraciones.Services.RequestConfigServices;

namespace BackEndRemuneraciones.Controllers.Configuracion
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class ConfiguracionController : ControllerBase
    {
        private Models.Data.remuneracionesContext _db;

        public ConfiguracionController(Models.Data.remuneracionesContext db) => _db = db;

        [HttpPost("InsertarNuevosIE")]
        public IActionResult InsertNuevosIE(RequestIE Request)
        {
            var Result = ServiciosConfigParametros.ActualizarIndicadoresEconomicos(Request, _db);
            return Ok(Result);
        }

        [HttpPost("InsertarNuevosTopes")]
        public IActionResult InsertNuevosTopes(RequestTopes request)
        {
            var Result = ServiciosConfigParametros.ActualizarTopes(request,_db);
            return Ok(Result);
        }
        [HttpGet("GetTopesActivos")]
        public IActionResult ObtenerTopesActivos()
        {
            var TopesActivos = ServiciosConfigParametros.ObtenerTopesActivos(_db);
            return Ok(TopesActivos);
        }

        [HttpGet("GetTipoTopes")]
        public IActionResult ObtenerTipoTopes()
        {
            var TopesLst = Enum.GetValues(typeof(TipoTope))
                                .Cast<TipoTope>()
                                .Select(v => v.ToString())
                                .ToList();

            return Ok(TopesLst);
        }

        [HttpPost("InsertarNuevasAPV")]
        public IActionResult InsertNuevasAPV()
        {
            return Ok();
        }
        [HttpPost("InsertarNuevasAFP")]
        public IActionResult InsertNuevasAFP(RequestAFP request)
        {
            var Result = ServiciosConfigParametros.ActualizarAFP(request, _db);
            return Ok(); 
        }
        [HttpPost("InsertarNuevosDatosSalud")]
        public IActionResult InsertNuevosDatosSalud()
        {
            return Ok();
        }
    }
}