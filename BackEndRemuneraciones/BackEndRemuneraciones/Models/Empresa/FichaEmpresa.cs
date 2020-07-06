using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndRemuneraciones.Models.Empresa.RequestEmpresa;
using BackEndRemuneraciones.Models.Data;


namespace BackEndRemuneraciones.Models.Empresa
{
    public class FichaEmpresa
    {
        public int Id { get; set; }
        public string Rut { get; set; }
        public bool Principal { get; set; }
        public string RazonSocial { get; set; }
        public int TipoEmpresa { get; set; }
        public string Giro { get; set; }
        public string Direccion { get; set; }
        public string RepresentanteLegal { get; set; }
        public string RutRepresentanteLegal { get; set; }
        public int? CajaCompensacion { get; set; }
        public decimal MutualPorcentajeDescuento { get; set; }
        public int Comuna { get; set; }
        public int Telefono { get; set; }
        public int BancoPagoNomina { get; set; }
        public bool Vigente { get; set; }
        public int FormaPagoGratif { get; set; }
        public int FormPagoMoviColacion { get; set; }



        public static int InsertarEmpresa(FichaEmpresaRequestModel Empresa)
        {
            int Result = 0;

            FichaEmpresa ObjAInsertar = new FichaEmpresa();
            using (remuneracionesContext db = new remuneracionesContext())
            {
                ObjAInsertar.Rut = Empresa.Rut;
                ObjAInsertar.Principal = Empresa.Principal;
                ObjAInsertar.RazonSocial = Empresa.RazonSocial;
                ObjAInsertar.TipoEmpresa = Convert.ToInt32(Empresa.TipoEmpresa);
                ObjAInsertar.Giro = Empresa.Giro;
                ObjAInsertar.Direccion = Empresa.Direccion;
                ObjAInsertar.RepresentanteLegal = Empresa.RepresentanteLegal;
                ObjAInsertar.RutRepresentanteLegal = Empresa.RutRepresentanteLegal;
                ObjAInsertar.CajaCompensacion = Convert.ToInt32(Empresa.CajaCompensacion);
                ObjAInsertar.MutualPorcentajeDescuento = Convert.ToDecimal(Empresa.MutualPorcentajeDescuento);
                ObjAInsertar.Comuna = Convert.ToInt32(Empresa.Comuna);
                ObjAInsertar.Telefono = Convert.ToInt32(Empresa.Telefono);
                ObjAInsertar.BancoPagoNomina = Convert.ToInt32(Empresa.BancoPagoNomina);
                ObjAInsertar.Vigente = Empresa.Vigente;
                ObjAInsertar.FormaPagoGratif = Convert.ToInt32(Empresa.FormaPagoGratif);
                ObjAInsertar.FormPagoMoviColacion = Convert.ToInt32(Empresa.FormPagoMoviColacion);

                db.FichaEmpresa.Add(ObjAInsertar);
                Result = db.SaveChanges();
                
            }

            return Result;
        }

        public static List<FichaEmpresa> ObtenerListadoEmpresas()
        {
            List<FichaEmpresa> lstEmpresas = new List<FichaEmpresa>();
            using (remuneracionesContext db = new remuneracionesContext())
            {
                lstEmpresas = db.FichaEmpresa.ToList();
            }

            return lstEmpresas;
        }

        public static FichaEmpresa ObtenerEmpresa(int IdEmpresa)
        {
            FichaEmpresa EmpresaEcontrada = new FichaEmpresa();
            using (remuneracionesContext db = new remuneracionesContext())
            {
                EmpresaEcontrada = db.FichaEmpresa.SingleOrDefault(Empresa => Empresa.Id == IdEmpresa);
            }

            return EmpresaEcontrada;
        }


    }
}
