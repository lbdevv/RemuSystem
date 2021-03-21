using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndRemuneraciones.Models.Data;
using BackEndRemuneraciones.Models.Empresa;
using BackEndRemuneraciones.Models.Liquidacion;
using BackEndRemuneraciones.Models.Liquidacion.Haberes;
using BackEndRemuneraciones.Models.Liquidacion.Descuentos;

namespace BackEndRemuneraciones.Services.Request
{
    public class RequestAsignarHoD{
        public string EmpleadoId { get; set; }
        public List<string> IdsHaberesAsignados { get; set; }
        public List<string> IdsDescuentosAsignados { get; set; }
    }
}