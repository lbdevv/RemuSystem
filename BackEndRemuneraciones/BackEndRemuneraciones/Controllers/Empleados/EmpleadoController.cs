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
using BackEndRemuneraciones.Services.Request;
using BackEndRemuneraciones.Services;

namespace BackEndRemuneraciones.Controllers.Empleados
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class EmpleadoController : ControllerBase
    {
        private Models.Data.remuneracionesContext _db;

        public EmpleadoController(Models.Data.remuneracionesContext db) => _db = db;


        [HttpGet("LstEmpleados")]


        public IActionResult GetLstEmpleados()
        {
               var lstEmpleados = Tbempleados.ListarEmpleados(_db);
               return Ok(lstEmpleados);
        }

        [HttpPost("AgregarEmpleado")]
        public IActionResult InsertarEmpleado(FichaEmpleadoRequestModel NewEmp)
        {
            var ResultEmpleadoAgregado = Tbempleados.InsertarEmpleado(NewEmp); 

        
            
            return Ok(ResultEmpleadoAgregado);
        }
        
        [HttpGet("GetEmpleado/{id}")]
        public IActionResult ObtenerEmpleado(int id)
        {
            var Empleado = Tbempleados.ObtenerLiquidacionEmpleado(id);
            return Ok(Empleado);
        }

        [HttpPost("CargarLiquidacion/{id}")]
        public IActionResult GenerarLiquidacion(int id)
        {
            bool Result = Tbempleados.AgregarLiquidacion(id);
            return Ok(Result);
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
        [HttpGet("EmpleadoLstHyD")]
        public IActionResult ListaHyDEmpleado(){
            var LstHyD = ServiciosHyD.ObtenerHyDEmpleado(1);
            return Ok(LstHyD);
        }

    }
}