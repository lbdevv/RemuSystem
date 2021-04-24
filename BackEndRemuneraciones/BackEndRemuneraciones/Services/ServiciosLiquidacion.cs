using System;
using System.Collections.Generic;
using System.Linq;
using BackEndRemuneraciones.Models.Data;
using BackEndRemuneraciones.Models.Liquidacion;
using BackEndRemuneraciones.Models.Reportes;


namespace BackEndRemuneraciones.Services
{
    public class ServiciosLiquidacion
    {
        public static bool InsertarLiquidacion(LiquidacionEmpleado Liquidacion, remuneracionesContext db)
        {
            bool Result = false;
            LibroRemuneraciones ObjLibroRemu = new LibroRemuneraciones();
            try
            {
                LibroRemuneraciones EmpLibro = db.LibroRemuneraciones.Where(x => x.EmpleadoId == Convert.ToInt32(Liquidacion.InfoEmpleado.EmpleadoId)).FirstOrDefault();

                List<string> LstAfps = db.AfpModel.Select(x => x.NombreAfp).ToList();
                decimal MontoAfp = 0;
                foreach (var ItemToSearch in Liquidacion.lstDescuentos)
                {
                    foreach (string ItemAfp in LstAfps)
                    {
                        if (ItemToSearch.NombreDescuento.Contains(ItemAfp))
                            MontoAfp = ItemToSearch.MontoDescuento;
                    }
                }

                var ImpuestoUnico = Liquidacion.lstDescuentos.SingleOrDefault(x => x.NombreDescuento == "Impuesto Único");

                if (ImpuestoUnico != null)
                {
                    ObjLibroRemu.ImpUnico = ImpuestoUnico.MontoDescuento;
                }

                ObjLibroRemu.EmpleadoId = Convert.ToInt32(Liquidacion.InfoEmpleado.EmpleadoId);
                ObjLibroRemu.SegCesantia = Liquidacion.lstDescuentos.SingleOrDefault(x => x.NombreDescuento == "Seguro de Cesantia").MontoDescuento;
                ObjLibroRemu.Salud = Liquidacion.lstDescuentos.SingleOrDefault(x => x.NombreDescuento == "Fonasa" || x.NombreDescuento == "Isapre").MontoDescuento;
                ObjLibroRemu.GratLegal = Liquidacion.lstHaberImponible.SingleOrDefault(x => x.NombreHaber == "Gratificación").MontoHaber;
                ObjLibroRemu.AsigFamiliar = 0; //Revisar logica e incluir
                ObjLibroRemu.DescLegales = Liquidacion.TotalDescuentos;
                ObjLibroRemu.TotalHaberes = Liquidacion.TotalHaberes;
                ObjLibroRemu.TotalDescuentos = Liquidacion.TotalDescuentos;
                ObjLibroRemu.TotalImp = Liquidacion.TotalHaberesImp;
                ObjLibroRemu.TotalNoImp = Liquidacion.TotalHaberesNoImp;
                ObjLibroRemu.Prevision = MontoAfp;
                ObjLibroRemu.DescVariables = Liquidacion.TotalDescuentos;
                ObjLibroRemu.OtrDescuentosLegales = Liquidacion.TotalDescuentos;
                ObjLibroRemu.OtrosImp = Liquidacion.TotalHaberesImp;
                ObjLibroRemu.OtrosNoImp = Liquidacion.TotalHaberesNoImp;
                ObjLibroRemu.TotalLiquido = Liquidacion.TotalLiquido;

                db.LibroRemuneraciones.Add(ObjLibroRemu);
                db.SaveChanges();
                Result = true;
                    
            }
            catch (Exception ex)
            {
                Result = false;
            }
        
            return Result;
        }


    }

}