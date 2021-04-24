using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using BackEndRemuneraciones.Models.Empresa;
using BackEndRemuneraciones.Models.Empresa.RequestEmpresa;
using BackEndRemuneraciones.Models;
using BackEndRemuneraciones.Services;
using BackEndRemuneraciones.Services.Request;

namespace BackEndRemuneraciones.Controllers.Empresa
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class EmpresaController : ControllerBase
    {
        private Models.Data.remuneracionesContext _db;
        public EmpresaController(Models.Data.remuneracionesContext db) => _db = db;

        [HttpPost("AgregarEmpresa")]
        public IActionResult InsertarEmpresa(FichaEmpresaRequestModel Empresa)
        {
            var Result = FichaEmpresa.InsertarEmpresa(Empresa, _db);
            return Ok(Result);
        }

        [HttpGet("GetBancos")]
        public IActionResult ObtenerLstBancos()
        {
            var Bancos = BancoNomina.ObtenerTodosLosBancos(_db);
            
            return Ok(Bancos);
        }

        [HttpGet("GetLstCajasCompensacion")]
        public IActionResult ObtenerLstCajas()
        {
            var Cajas = CajaCompensacion.ObtenerLstCajaCompensacion(_db);
            return Ok(Cajas);
        }

        [HttpGet("lstEmpresas")]
        public IActionResult ListaEmpresas()
        {
            var lstEmpresas = FichaEmpresa.ObtenerListadoEmpresas(_db);
            return Ok(lstEmpresas);
        }

        [HttpGet("lstTipoEmpresas")]
        public IActionResult ListaTipoEmpresas(){
            var lstTipoEmpresas = TipoEmpresa.GetTipoEmpresas(_db);
            return Ok(lstTipoEmpresas);
        }

        [HttpGet("ObtenerEmpresa/{id}")]
        public IActionResult ObtenerUnaEmpresa(int id)
        {
            var EmpresaEncontrada = FichaEmpresa.ObtenerEmpresa(id,_db);
            return Ok(EmpresaEncontrada);
        }

        [HttpGet("LstAfps")]
        public IActionResult ObtenerAfps(){

            var LstAfp = AfpModel.ObtenerAfps(_db);

            return Ok(LstAfp);
        }
        [HttpGet("LstIsapres")]
        public IActionResult ObtenerIsapres(){
            var LstIsapres = IsapreModel.ObtenerIsapres(_db);

            return Ok(LstIsapres);
        }
        
        [HttpGet("LstContratos")]
        public IActionResult ObtenerContratos(){
            var LstContratos = TipoContratoModel.ObtenerListaContratos(_db);
            return Ok(LstContratos);
        }

        [HttpGet("LstRegiones")]
        public IActionResult ObtenerListadoRegion(){
            var Regiones = RegionModel.ObtenerRegiones(_db);
            return Ok(Regiones);
        }

        [HttpGet("RegionesYComunas/{id}")]
        public IActionResult ObtenerRegionYComunaPorId(int id){
        
            var RegionYComunas = RegionModel.ObtenerRegionYComuna(id, _db);
            return Ok(RegionYComunas);
        }
        [HttpGet("LstComunas")]
        public IActionResult ObtenerSoloComunas(){
            var Comunas = ComunaModel.ObtenerComunas(_db);
            return Ok(Comunas);
        }
        [HttpPost("CargoAgregar")]
        public IActionResult AgregarCargo(CargosModel Cargo){

            var ResInsercionCargo = CargosModel.AgregarCargo(Cargo, _db);

            return Ok(ResInsercionCargo);
        }

        [HttpGet("ObtenerCargos")]
        public IActionResult GetCargos(){

            var LstCargos = CargosModel.ObtenerCargos(_db);
            return Ok(LstCargos);
        }
        [HttpGet("VerificaTipoContrato/{id}")]
        public IActionResult VerificarTipoContrato(int id){
            
            var esIndefinido = TipoContratoModel.VerificarEsIndefinido(id, _db);
            return Ok(esIndefinido);
        }

        [HttpGet("ObtenerTramosFamiliares")]
        public IActionResult GetTramosFamiliar(){
            var LstTramos = AsigFamiliarTramo.ObtenerTramos(_db);
            return Ok(LstTramos);
        }

        [HttpGet("ObtenerIApv")]
        public IActionResult GetLstInstitucionesApv(){
            var LstIApv = InstitucionesApvModel.ObtenerInstitucionesApv(_db);
            return Ok(LstIApv);
        }
        [HttpPost("AgregarHaber")]
        public IActionResult InsertarHaber(RequestCreateHaber Request){
            bool InsertResult = ServiciosHyD.AgregarHaber(Request, _db);
            return Ok(InsertResult);
        }
        [HttpPost("AgregarDescuento")]
        public IActionResult InsertarDescuento(RequestCreateDescuento Request)
        {
            bool InsertResult = ServiciosHyD.AgregarDescuento(Request, _db);
            return Ok(InsertResult);
        }
        [HttpGet("GetHyDempresa")]
        public IActionResult ObtenerHyDempresa(){
            var LstHyD = ServiciosHyD.ObtenerHyDempresa(_db);
            return Ok(LstHyD);
        }
        [HttpPost("AsignarHoD")]
        public IActionResult AsignarHaberesOdescuentosEmpleado(RequestAsignarHoD Request)
        {
            var ResultInsert = ServiciosHyD.AsignarHoDEmp(Request, _db);
            return Ok(ResultInsert);
        }
        [HttpGet("GetLibroRemuneraciones")]
        public IActionResult ObtenerLibroRemu()
        {
            var LibroRemuneraciones = ServiciosReportes.ObtenerLibroRemuneraciones(_db);
            
            return Ok(LibroRemuneraciones);
        }
    }
}