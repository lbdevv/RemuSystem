using System;
using System.Collections.Generic;
using System.Linq;
using BackEndRemuneraciones.Models.Data;
using BackEndRemuneraciones.Models.Liquidacion;
using BackEndRemuneraciones.Models.Reportes;
using Microsoft.EntityFrameworkCore;


namespace BackEndRemuneraciones.Services
{
    public class ServiciosReportes
    {
         public static List<LibroRemuneraciones> ObtenerLibroRemuneraciones(remuneracionesContext db)
        {
            List<LibroRemuneraciones> LstLibroRemuneraciones = new List<LibroRemuneraciones>();
    
            try{
                LstLibroRemuneraciones = db.LibroRemuneraciones.Include(e => e.Empleado)
                                                                .Include(c => c.Empleado.ContratoEmp)
                                                                .Include(s => s.Empleado.SueldoEmp).ToList();
            }
            catch(Exception ex)
            {
                throw new Exception();
            }
            

            return LstLibroRemuneraciones;
        }
    }
}