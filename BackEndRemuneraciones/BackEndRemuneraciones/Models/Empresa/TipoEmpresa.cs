using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndRemuneraciones.Models.Empresa.RequestEmpresa;
using BackEndRemuneraciones.Models.Data;
using BackEndRemuneraciones.Models.Empleado.Ficha;
using Microsoft.EntityFrameworkCore;

namespace BackEndRemuneraciones.Models.Empresa
{
    public class TipoEmpresa{
        public int Id {get;set;}
        public string Nombre {get;set;}


        public static List<TipoEmpresa> GetTipoEmpresas(remuneracionesContext db){
            List<TipoEmpresa> LstTipoEmpresa = new List<TipoEmpresa>();

            LstTipoEmpresa = db.TipoEmpresa.ToList();
            
            return LstTipoEmpresa;
        }
    }
}