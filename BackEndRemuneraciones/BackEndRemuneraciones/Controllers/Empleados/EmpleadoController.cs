using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using BackEndRemuneraciones.Models;

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
            using(remuneracionesContext db = new remuneracionesContext())
            {
               List<Tbempleados> lst = db.Tbempleados.ToList();
               return Ok(lst);
            }
            
        }
    }
}