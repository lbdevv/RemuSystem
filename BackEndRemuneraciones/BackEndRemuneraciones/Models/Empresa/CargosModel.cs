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
    public class CargosModel{
        public int Id {get;set;}
        public string Nombre {get;set;}
        public string Detalle {get;set;}

        public static int AgregarCargo(CargosModel ObjCargoAgregar){
            int Result = 0;
            using(remuneracionesContext db = new remuneracionesContext())
            {
              db.CargosModel.Add(ObjCargoAgregar);
              Result = db.SaveChanges(); //SaveChanges Retorna un 0 o un 1 dependiendo de lo que haya pasado con la inserción de datos.
            }

            return Result;
        }

        public static List<CargosModel> ObtenerCargos(){
            List<CargosModel> LstCargos = new List<CargosModel>();
           using(remuneracionesContext db = new remuneracionesContext())
            {
                LstCargos = db.CargosModel.ToList();
            }
            
            return LstCargos;
        }
    }


}