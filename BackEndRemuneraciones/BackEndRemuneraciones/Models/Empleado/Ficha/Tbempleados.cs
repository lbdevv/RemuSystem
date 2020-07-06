using BackEndRemuneraciones.Models.Request;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using BackEndRemuneraciones.Models.Data;
using BackEndRemuneraciones.Helpers;
using BackEndRemuneraciones.Models.Empleado.Condiciones;
using BackEndRemuneraciones.Models.Empleado.Prevision;

namespace BackEndRemuneraciones.Models.Empleado.Ficha
{
    public partial class Tbempleados
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Rut { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Nacionalidad { get; set; }
        public int Sexo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool EstaDisponible { get; set; } = true;
        public int Ciudad { get; set; }
        public int Comuna { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string EstadoCivil { get; set; }
        
        

        public static List<Tbempleados> ListarEmpleados()
        {
            List<Tbempleados> lstEmpleados = new List<Tbempleados>();
            using (remuneracionesContext db = new remuneracionesContext())
            {
                lstEmpleados = db.Tbempleados.ToList();
            }

            return lstEmpleados;
        }


        public static bool InsertarEmpleado(TbEmpeladoRequestModel NuevoEmp)
        {
            bool Result = false;

            using(remuneracionesContext db = new remuneracionesContext()) { 
        
                Tbempleados InsertEmpleado = new Tbempleados();

                InsertEmpleado.Nombre = NuevoEmp.Nombre;
                InsertEmpleado.Apellido = NuevoEmp.Apellido;
                InsertEmpleado.Rut = NuevoEmp.Rut;
                InsertEmpleado.Sexo = NuevoEmp.Sexo;

                db.Tbempleados.Add(InsertEmpleado);
                db.SaveChanges();

                Result = true;
            }


            return Result;
        }

        public static Tbempleados ObtenerEmpleado(int IdEmp)
        {
            using(remuneracionesContext db = new remuneracionesContext())
            {
                var EmpActualizar = db.Tbempleados.SingleOrDefault(Emp => Emp.Id == IdEmp);

                return EmpActualizar;
            }
        }

        public static bool ActualizarEmpleado(Tbempleados Emp)
        {
            bool Result = false;
            using(remuneracionesContext db = new remuneracionesContext())
            {
                db.Tbempleados.Update(Emp);
                db.SaveChanges();
                Result = true;
            }

            return Result;
        }

        public static bool DarDeBajaempleado(Tbempleados Emp)
        {
            bool Result = false;

            using(remuneracionesContext db = new remuneracionesContext())
            {
                Emp.EstaDisponible = false;
                db.Tbempleados.Update(Emp);
                db.SaveChanges();
                Result = true;
            }

            return Result;
        }

        public static int AgregarEmpDesdeExcel(List<List<string>> ExcelEmp)
        {
            int Result = 0;
            ExcelEmp.RemoveAt(0);
          
            foreach (List<string> Columna in ExcelEmp)
            {
                remuneracionesContext db = new remuneracionesContext();

                string AFPExcel = Columna[23];
                var BuscaAFP = db.AfpModel.SingleOrDefault(AFP => AFP.NombreAfp == AFPExcel);

                int AFP = 0;
                if (BuscaAFP != null) {
                    AFP = BuscaAFP.Id;
                }

                string Rut = Columna[0];
                string Nombre = Columna[1];
                string Apellido = Columna[2];
                string Nacionalidad = Columna[7];
                int Telefono = Convert.ToInt32(Columna[9]);
                string Cargo = Columna[17];

                decimal SueldoBase = Convert.ToDecimal(Columna[30]);
                decimal Movilizacion = Convert.ToDecimal(Columna[31]);
                decimal Colacion = Convert.ToDecimal(Columna[32]);

                DateTime FechaNacimiento = Utiles.ToDD_MM_AAAA_Multi(Columna[3]);

                Tbempleados EmpleadoAInsertar = new Tbempleados();
                SueldoEmpleado EmpleadoSueldo = new SueldoEmpleado();
                ContratoEmpleado EmpleadoContrato = new ContratoEmpleado();
                PrevisionEmpleado EmpleadoPrevision = new PrevisionEmpleado();

                EmpleadoAInsertar.Rut = Rut;
                EmpleadoAInsertar.Nombre = Nombre;
                EmpleadoAInsertar.Apellido = Apellido;
                EmpleadoAInsertar.FechaNacimiento = FechaNacimiento;
                EmpleadoAInsertar.Nacionalidad = Nacionalidad;
                EmpleadoAInsertar.Telefono = Telefono;
                db.Tbempleados.Add(EmpleadoAInsertar);

                EmpleadoSueldo.SueldoBase = SueldoBase;
                EmpleadoSueldo.AsignMovilizacion = Movilizacion;
                EmpleadoSueldo.AsignColacion = Colacion;
                db.SueldoEmpleado.Add(EmpleadoSueldo);

                EmpleadoContrato.Cargo = Cargo;
                db.ContratoEmpleado.Add(EmpleadoContrato);

                EmpleadoPrevision.Afp = AFP;
                db.PrevisionEmpleado.Add(EmpleadoPrevision);

                Result = db.SaveChanges();
                
            }


            return Result;
        }
      


    }
}
