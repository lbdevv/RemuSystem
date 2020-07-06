using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using BackEndRemuneraciones.Models.Empresa;
using BackEndRemuneraciones.Models.Empresa.RequestEmpresa;

namespace BackEndRemuneraciones.Controllers.Empresa
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class EmpresaController : ControllerBase
    {
        [HttpPost("AgregarEmpresa")]
        public IActionResult InsertarEmpresa(FichaEmpresaRequestModel Empresa)
        {
            var Result = FichaEmpresa.InsertarEmpresa(Empresa);
            return Ok(Result);
        }

        [HttpGet("GetBancos")]
        public IActionResult ObtenerLstBancos()
        {
            var Bancos = BancoNomina.ObtenerTodosLosBancos();
            
            return Ok(Bancos);
        }

        [HttpGet("GetLstCajasCompensacion")]
        public IActionResult ObtenerLstCajas()
        {
            var Cajas = CajaCompensacion.ObtenerLstCajaCompensacion();
            return Ok(Cajas);
        }

        [HttpPut("lstEmpresas")]
        public IActionResult ListaEmpresas()
        {
            var lstEmpresas = FichaEmpresa.ObtenerListadoEmpresas();
            return Ok(lstEmpresas);
        }

        [HttpGet("ObtenerEmpresa")]
        public IActionResult ObtenerUnaEmpresa(int IdEmpresa)
        {
            var EmpresaEncontrada = FichaEmpresa.ObtenerEmpresa(IdEmpresa);
            return Ok(EmpresaEncontrada);
        }
    }
}