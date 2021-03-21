using System;
using System.Collections.Generic;
using System.Linq;
using BackEndRemuneraciones.Models.Data;
using BackEndRemuneraciones.Models.Liquidacion;
using BackEndRemuneraciones.Models.Liquidacion.Haberes;
using BackEndRemuneraciones.Models.Liquidacion.Descuentos;
using BackEndRemuneraciones.Services.Request;
using BackEndRemuneraciones.Models.Liquidacion.HaberesYdescuentos;

namespace BackEndRemuneraciones.Services
{
    public class ServiciosHyD
    {
        public static bool AgregarHaber(RequestCreateHaber DataHaber)
        {
            bool Result = false;
            using (var db = new remuneracionesContext())
            {
                try
                {
                    if (DataHaber != null)
                    {
                        int CategoriaHaber = Convert.ToInt32(DataHaber.TipoHaber);
                        var ObjHaber = new ColeccionHaberes()
                        {
                            Categoria_id = (CategoriaHaberes)CategoriaHaber,
                            Nombre = DataHaber.NombreHaber,
                            ValorCalculo = Convert.ToDecimal(DataHaber.MontoHaber),
                            EmpresaId = 1
                        };

                        db.ColeccionHaberes.Add(ObjHaber);
                        db.SaveChanges();
                        Result = true;
                    }
                }
                catch (Exception)
                {
                    Result = false;
                }

            }
            return Result;
        }

        public static bool AgregarDescuento(RequestCreateDescuento DataDescuento)
        {
            bool Result = false;
            using (var db = new remuneracionesContext())
            {
                try
                {
                    if (DataDescuento != null)
                    {
                        var NuevoDescuento = new ColeccionDescuentos()
                        {
                            Nombre = DataDescuento.NombreDescuento,
                            ValorCalculo = Convert.ToDecimal(DataDescuento.MontoDescuento),
                            EmpresaId = 1
                        };
                        db.ColeccionDescuentos.Add(NuevoDescuento);
                        db.SaveChanges();
                        Result = true;
                    }
                }
                catch (Exception)
                {
                    Result = false;
                }
            }
            return Result;
        }
        public static bool AsignarHoDEmp(RequestAsignarHoD Request)
        {
            bool Result = false;

            using (var db = new remuneracionesContext())
            {
                try
                {
                    var LstHyD = new List<HaberesYDescuentosEmpleado>();
                    if (Request.IdsHaberesAsignados.Count() > 0 && Request.IdsHaberesAsignados.Any(x => x != "Selecciona"))
                    {
                        foreach (string IdHaber in Request.IdsHaberesAsignados)
                        {
                            var Haber = db.ColeccionHaberes.SingleOrDefault(x => x.Id == Convert.ToInt32(IdHaber));

                            if (Haber != null)
                            {
                                var ItemAsignacion = new HaberesYDescuentosEmpleado()
                                {
                                    EmpresaId = 1,
                                    EmpleadoId = Convert.ToInt32(Request.EmpleadoId),
                                    HaberOdescuentoId = Haber.Id,
                                    TipoHoD = TipoHaberODescuento.HABER,
                                    Monto = Haber.ValorCalculo
                                };
                                LstHyD.Add(ItemAsignacion);
                            }
                        }
                    }
                    if (Request.IdsDescuentosAsignados.Count() > 0 && Request.IdsDescuentosAsignados.Any(x => x != "Selecciona"))
                    {
                        foreach (string IdDescuento in Request.IdsDescuentosAsignados)
                        {
                            var Descuento = db.ColeccionDescuentos.SingleOrDefault(x => x.Id == Convert.ToInt32(IdDescuento));
                            if (Descuento != null)
                            {
                                var ItemAsignacion = new HaberesYDescuentosEmpleado()
                                {
                                    EmpresaId = 1,
                                    EmpleadoId = Convert.ToInt32(Request.EmpleadoId),
                                    HaberOdescuentoId = Descuento.Id,
                                    TipoHoD = TipoHaberODescuento.DESCUENTO,
                                    Monto = Descuento.ValorCalculo
                                };
                                LstHyD.Add(ItemAsignacion);
                            }
                        }
                    }

                    db.HaberesYDescuentosEmpleado.AddRange(LstHyD);
                    db.SaveChanges();
                    Result = true;

                }
                catch (Exception)
                {
                    Result = false;
                }
            }

            return Result;
        }

        public static Tuple<List<HaberesYDescuentos>, List<HaberesYDescuentos>> ObtenerHyDempresa()
        {
            var LstHyD = new List<HaberesYDescuentos>();
            var LstHaberes = new List<HaberesYDescuentos>();
            var LstDescuentos = new List<HaberesYDescuentos>();

            using (var db = new remuneracionesContext())
            {
                try
                {
                    var lstHaberes = db.ColeccionHaberes.Where(x => x.EmpresaId == 1).ToList();
                    var lstDescuentos = db.ColeccionDescuentos.Where(x => x.EmpresaId == 1).ToList();

                    foreach (var ItemHaber in lstHaberes)
                    {
                        var CategoriaHaber = (CategoriaHaberes)ItemHaber.Categoria_id;
                        var ObjHyD = new HaberesYDescuentos()
                        {
                            Id = ItemHaber.Id,
                            Nombre = ItemHaber.Nombre,
                            Monto = ItemHaber.ValorCalculo,
                            Tipo = TipoHaberODescuento.HABER.ToString(),
                            CategoriaHaber = CategoriaHaber.ToString()
                        };
                        LstHyD.Add(ObjHyD);
                    }
                    foreach (var ItemDescuento in lstDescuentos)
                    {
                        var ObjHyD = new HaberesYDescuentos()
                        {
                            Id = ItemDescuento.Id,
                            Nombre = ItemDescuento.Nombre,
                            Monto = ItemDescuento.ValorCalculo,
                            Tipo = TipoHaberODescuento.DESCUENTO.ToString(),
                            CategoriaHaber = CategoriaHaberes.NODETERMINADO.ToString()
                        };
                        LstHyD.Add(ObjHyD);
                    }

                    LstHaberes = LstHyD.Where(x => x.Tipo == TipoHaberODescuento.HABER.ToString()).ToList();
                    LstDescuentos = LstHyD.Where(x => x.Tipo == TipoHaberODescuento.DESCUENTO.ToString()).ToList();
                }
                catch (Exception)
                {
                    return null;
                }

            }
            return Tuple.Create(LstHaberes, LstDescuentos);
        }

        public static Tuple<List<ColeccionHaberes>, List<ColeccionDescuentos>> ObtenerHyDEmpleado(int EmpleadoId)
        {

            List<ColeccionHaberes> EmpH = new List<ColeccionHaberes>();
            List<ColeccionDescuentos> EmpD = new List<ColeccionDescuentos>();

            using (var db = new remuneracionesContext())
            {
                try
                {
                    List<int> EmpHaberes = db.HaberesYDescuentosEmpleado.Where(x => x.EmpleadoId == EmpleadoId && x.TipoHoD == TipoHaberODescuento.HABER).Select(x => x.HaberOdescuentoId).ToList();
                    List<int> EmpDescuentos = db.HaberesYDescuentosEmpleado.Where(x =>  x.EmpleadoId == EmpleadoId && x.TipoHoD == TipoHaberODescuento.DESCUENTO).Select(x => x.HaberOdescuentoId).ToList();

                    foreach (int ItemIdHaber in EmpHaberes)
                    {
                        var Haber = new ColeccionHaberes();
                        Haber = db.ColeccionHaberes.SingleOrDefault(x => x.Id == ItemIdHaber);
                        if (Haber != null)
                            EmpH.Add(Haber);
                    }
                    foreach (int ItemIdDescuento in EmpDescuentos)
                    {
                        var Descuento = new ColeccionDescuentos();
                        Descuento = db.ColeccionDescuentos.SingleOrDefault(x => x.Id == ItemIdDescuento);
                        if (Descuento != null)
                            EmpD.Add(Descuento);
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }

            }

            return Tuple.Create(EmpH, EmpD);
        }
    }

}