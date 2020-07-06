using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using BackEndRemuneraciones.Models.Request;
using BackEndRemuneraciones.Models.Empleado.Ficha;
using BackEndRemuneraciones.Helpers;

namespace BackEndRemuneraciones.Controllers.Empleados
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class EmpleadoController : ControllerBase
    {
        [HttpGet("LstEmpleados")]
        public IActionResult GetLstEmpleados()
        {
               var lstEmpleados = Tbempleados.ListarEmpleados();
               return Ok(lstEmpleados);
        }

        [HttpPost("AgregarEmpleado")]
        public IActionResult InsertarEmpleado(TbEmpeladoRequestModel NuevoEmp)
        {
            var Insertar = Tbempleados.InsertarEmpleado(NuevoEmp);
            return Ok(Insertar);
        }

        [HttpPut("ActualizarFichaEmp")]
        public IActionResult ActualizarEmpleado(int IdEmp)  
        {
            var Result = false;
            var EmpAactualizar = Tbempleados.ObtenerEmpleado(IdEmp);

            if(EmpAactualizar != null) { 
                Result = Tbempleados.ActualizarEmpleado(EmpAactualizar);
            }

            return Ok(Result);
        }
        
        [HttpGet("GetEmpleado/{id}")]
        public IActionResult ObtenerEmpleado(int id)
        {
            var Empleado = Tbempleados.ObtenerEmpleado(id);
            return Ok(Empleado);
        }

        [HttpPut("DesactivarEmpleado/{id}")]
        public IActionResult DarDeBajaEmpleado(int IdEmp)
        {
            var EmpAdarDeBaja = Tbempleados.ObtenerEmpleado(IdEmp);
            return Ok(EmpAdarDeBaja);
        }

        [HttpPost("CargarEmpleadosExcel")]
        public IActionResult CargarEmpleado(List<IFormFile> lstEmpleados)
        {
            int Result = 0;
            var ExcelEmp = Utiles.LeerExcel(lstEmpleados);
            if(ExcelEmp.Count() > 0) { 
                  Result = Tbempleados.AgregarEmpDesdeExcel(ExcelEmp);
            }
            return Ok(Result);
        }

    }
}